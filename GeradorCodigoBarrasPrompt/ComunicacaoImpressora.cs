using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GeradorCodigoBarrasPrompt
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

        private void Send(Socket socket, byte[] buffer, int offset, int size, int timeout, bool checkRetorno)
        {
            int startTickCount = Environment.TickCount;
            int sent = 0;
            do
            {
                try
                {
                    Console.WriteLine(BitConverter.ToString(buffer));
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                    Console.WriteLine("Enviou");

                    if (checkRetorno)
                    {
                        byte[] pergunta = new byte[5];
                        pergunta[0] = (byte)Int64.Parse("41", NumberStyles.HexNumber);
                        pergunta[1] = (byte)Int64.Parse("00", NumberStyles.HexNumber);
                        pergunta[2] = (byte)Int64.Parse("01", NumberStyles.HexNumber);
                        pergunta[3] = (byte)Int64.Parse("01", NumberStyles.HexNumber);
                        //pergunta[4] = (byte)65;
                        pergunta[4] = (byte)Int64.Parse("41", NumberStyles.HexNumber);

                        byte[] resposta = new byte[1];
                        byte respostaOk = (byte)Int64.Parse("E7", NumberStyles.HexNumber);
                        int bytesSent = socket.Send(pergunta);

                        while (resposta[0] != respostaOk)
                        {
                            int bytesRec = socket.Receive(resposta);
                            Console.WriteLine(BitConverter.ToString(resposta));                            
                        }
                    }
                }                
                catch (SocketException ex)
                {
                    throw ex;  // any serious error occurr
                }
            } while (sent < size);
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
            byte[] data = WrapStringCompleto(mensagem);            
            Send(Socket, data, 0, data.Length, 10000, true);
        }
    }
}