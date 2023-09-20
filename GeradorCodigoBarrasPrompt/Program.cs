using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCodigoBarrasPrompt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Digite a quantidade de peças: ");
                Int32 qtd = Convert.ToInt32(Console.ReadLine());
                string seq = Config.Sequecial;
                List<string> resultado = new List<string>();
                long x = Convert.ToInt64(seq);
                for (int i = 0; i < qtd; i++)
                {
                    resultado.Add(CodigoBarras.GerarCodigoNumerico(x.ToString().PadLeft(8, '0')));
                    x++;
                }

                DateTime dataInicio;
                DateTime dataFim;            

                ComunicacaoImpressora obj = new ComunicacaoImpressora(Config.IP, Convert.ToInt32(Config.Porta));
                foreach (string item in resultado)
                {
                    Console.WriteLine(item);
                    dataInicio = DateTime.Now;
                    obj.SendCompleto(item);
                    dataFim = DateTime.Now;
                    Config.Etiqueta = item;
                    Console.WriteLine("Tempo: " + dataFim.AddMilliseconds(-dataInicio.Millisecond).Millisecond);
                }
                Console.WriteLine("Fim");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
