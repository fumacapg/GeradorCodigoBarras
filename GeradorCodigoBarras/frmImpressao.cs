using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorCodigoBarras
{
    public partial class frmImpressao : Form
    {
        public frmImpressao()
        {
            InitializeComponent();
            txtEtiqueta.Text = (Config.Etiqueta != "" && Config.Etiqueta.Length == 11) ? Config.Etiqueta.Substring(0, 10) + "-" + Config.Etiqueta.Substring(10, 1) : Config.Etiqueta;
        }

        public delegate void Executa();

        private void button1_Click(object sender, EventArgs e)
        {
            Executa exec = new Executa(EnviarImpressora);
            exec();
        }

        private void EnviarImpressora()
        {
            try
            {
                string seq = Config.Sequecial;
                long qtd = Convert.ToInt64(txtQtde.Text);
                List<string> resultado = new List<string>();
                long x = Convert.ToInt64(seq);
                for (int i = 0; i < qtd; i++)
                {
                    resultado.Add(CodigoBarras.GerarCodigoNumerico(x.ToString().PadLeft(8, '0')));
                    x++;
                }
                seq = x.ToString();

                using (System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt", false))
                {
                    file.WriteLine("Registrando a emissão de " + qtd + " etiquetas.");
                }

                ComunicacaoImpressora obj = new ComunicacaoImpressora(Config.IP, Convert.ToInt32(Config.Porta));

                foreach (string item in resultado)
                {
                    //obj.SendSimplificado(item);                    
                    obj.SendCompleto(item);
                    txtEtiqueta.Text = item;
                    Config.Etiqueta = item;
                }
                Config.Sequecial = seq.PadLeft(8, '0');
                Config.Salvar();
                MessageBox.Show("Final da impressão");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro de execução");
            }
        }
    }
}
