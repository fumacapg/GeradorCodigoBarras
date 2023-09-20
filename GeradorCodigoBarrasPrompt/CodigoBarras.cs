using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCodigoBarrasPrompt
{
    public static class CodigoBarras
    {
        public static string GerarCodigoNumerico(string sequencia)
        {
            int[] numbers = new int[8] { 8, 6, 4, 2, 3, 5, 9, 7 };
            int total = 0;
            int digito;
            int resto;
            string letra = Config.Valor;
            

            for (int i = 0; i < numbers.Length; i++)
            {
              
                total += Convert.ToInt16(sequencia[i].ToString()) * numbers[i];

            }

            resto = total % 11;

            switch (resto)
            {
                case 0:
                    digito = 5; 
                    break;
                case 1:
                    digito = 0;
                    break;
                default:
                    digito = 11 - resto;
                    break;
            }
            
            return letra + sequencia.ToString() + digito.ToString();

        }
       
    }
    
}
