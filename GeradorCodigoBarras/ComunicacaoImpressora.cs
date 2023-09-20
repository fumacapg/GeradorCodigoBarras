using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GeradorCodigoBarras
{
    public class ComunicacaoImpressora
    {
        public ComunicacaoImpressora(string ip, int porta)
        {
            Ip = ip;
            Porta = porta;
            TcpClient = new TcpClient(Ip, Porta);
            Socket = TcpClient.Client;
        }

        public string Ip { get; set; }
        public int Porta { get; set; }
        TcpClient TcpClient { get; set; }
        Socket Socket { get; set; }

        public void SendSimplificado(string mensagem)
        {
            if (Ip == null || Ip == "")
                throw new Exception("O campo Ip está vazio!");
            if (Porta == 0)
                throw new Exception("O campo Porta está vazio ou igual a zero. Inserir uma porta válida!");

            byte[] data = WrapString(mensagem);
            Send(Socket, data, 0, data.Length, 10000, false);
        }

        private void Send(Socket socket, byte[] buffer, int offset, int size, int timeout, bool checkRetorno)
        {
            int startTickCount = Environment.TickCount;
            int sent = 0;
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt", true))
                    {
                        file.WriteLine(DateTime.Now.ToString("HH:MM:ss.fff") + " - Envio mensagem: " + BitConverter.ToString(buffer));                        
                    }
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);                

                    if (checkRetorno)
                    {
                        byte[] pergunta = new byte[5];
                        pergunta[0] = (byte)Int64.Parse("41", NumberStyles.HexNumber);
                        pergunta[1] = (byte)Int64.Parse("00", NumberStyles.HexNumber);
                        pergunta[2] = (byte)Int64.Parse("01", NumberStyles.HexNumber);
                        pergunta[3] = (byte)Int64.Parse("01", NumberStyles.HexNumber);
                        pergunta[4] = (byte)Int64.Parse("41", NumberStyles.HexNumber);

                        byte[] resposta = new byte[1];
                        byte respostaOk = (byte)Int64.Parse("E7", NumberStyles.HexNumber);
                        int bytesSent = socket.Send(pergunta);

                        while (resposta[0] != respostaOk)
                        {                            
                            int bytesRec = socket.Receive(resposta);
                        }

                        using (System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt", true))
                        {
                            file.WriteLine(DateTime.Now.ToString("HH:MM:ss.fff") + " - Recebimento resposta: " + BitConverter.ToString(resposta));
                        }
                    }
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt", true))
                        {
                            file.WriteLine("Erro");
                            file.WriteLine("Mensagem: " + ex.Message);
                            file.WriteLine("Código de Erro: " + ex.SocketErrorCode);
                        }
                        // socket buffer is probably full, wait and try again
                        Thread.Sleep(Convert.ToInt32(Convert.ToDecimal(Config.Delay) * 1000));
                    }
                    else
                        throw ex;  // any serious error occurr
                }
            } while (sent < size);
        }

        private static byte[] WrapString(string send)
        {
            byte stx = 0x02;
            byte etx = 0x03;
            int length = send.Length;
            byte[] data = new byte[length + 2];
            data[0] = stx;
            data[length + 1] = etx;
            Array.Copy(System.Text.Encoding.ASCII.GetBytes(send), 0, data, 1, length);
            return data;
        }

        private static byte[] WrapStringCompleto(string send)
        {
            byte[] codigoBarra = System.Text.Encoding.ASCII.GetBytes(send);
            byte[] numero = System.Text.Encoding.ASCII.GetBytes(send.Substring(2, 8));
            byte[] digitoNumero = System.Text.Encoding.ASCII.GetBytes(send.Substring(10, 1));
            byte inicio = (byte)Int64.Parse("99", NumberStyles.HexNumber);

            int n = 1 + 2 + 6 + codigoBarra.Length + numero.Length + digitoNumero.Length + 1;
            //int n = 1 + 2 + 2 + codigoBarra.Length + 1;

            byte[] data = new byte[n];
            data[0] = inicio;
            data[1] = (byte)Int64.Parse("00", NumberStyles.HexNumber);
            //data[2] tamanho total depois
            data[3] = (byte)Int64.Parse("12", NumberStyles.HexNumber);
            Array.Copy(codigoBarra, 0, data, 4, codigoBarra.Length);
            data[codigoBarra.Length + 4] = (byte)Int64.Parse("12", NumberStyles.HexNumber);
            data[codigoBarra.Length + 5] = (byte)Int64.Parse("12", NumberStyles.HexNumber);
            Array.Copy(numero, 0, data, codigoBarra.Length + 6, numero.Length);
            data[codigoBarra.Length + numero.Length + 6] = (byte)Int64.Parse("12", NumberStyles.HexNumber);
            data[codigoBarra.Length + numero.Length + 7] = (byte)Int64.Parse("12", NumberStyles.HexNumber);
            Array.Copy(digitoNumero, 0, data, codigoBarra.Length + numero.Length + 8, digitoNumero.Length);
            data[codigoBarra.Length + numero.Length + digitoNumero.Length + 8] = (byte)Int64.Parse("12", NumberStyles.HexNumber);
            data[2] = (byte)Int64.Parse((1 + codigoBarra.Length + 2 + numero.Length + 2 + digitoNumero.Length + 1).ToString("X"), NumberStyles.HexNumber);
            //data[2] = (byte)Int64.Parse((1 + codigoBarra.Length + 1).ToString("X"), NumberStyles.HexNumber);

            byte resultado = data[0];
            for (int i = 1; i < data.Length - 1; i++)
            {
                resultado = (byte)(resultado ^ data[i]);
            }
            data[n-1] = resultado;

            return data;
        }

        public void SendCompleto(string mensagem)
        {
            if (Ip == null || Ip == "")
                throw new Exception("O campo Ip está vazio!");
            if (Porta == 0)
                throw new Exception("O campo Porta está vazio ou igual a zero. Inserir uma porta válida!");

            byte[] data = WrapStringCompleto(mensagem);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt", true))
            {
                file.WriteLine(mensagem);
                file.WriteLine(BitConverter.ToString(data).Replace("-"," "));
            }
            Send(Socket, data, 0, data.Length, 10000, true);
        }
    }
}