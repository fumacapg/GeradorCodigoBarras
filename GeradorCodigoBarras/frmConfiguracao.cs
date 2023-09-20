using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GeradorCodigoBarras
{
    public partial class frmConfiguracao : Form
    {
        public frmConfiguracao()
        {
            InitializeComponent();
            //Config.Load();
            txtValor.Text = Config.Valor;
            txtSequencial.Text = Config.Sequecial;
            txtIP.Text = Config.IP;
            txtPorta.Text = Config.Porta;
            txtDelay.Text = Config.Delay == null || Config.Delay == "" ? "0" : Config.Delay.Replace(",", ".");
        }


        public static string CaminhoDadosXML(string caminho)
        {
            if (caminho.IndexOf("\\bin\\Debug") != 0)
            {
                caminho = caminho.Replace("\\bin\\Debug", "");
            }
            return caminho;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Config.Valor = txtValor.Text;
                Config.Sequecial = txtSequencial.Text;
                Config.IP = txtIP.Text;
                Config.Porta = txtPorta.Text;
                Config.Delay = txtDelay.Text.Replace(".", ",");
                Config.Salvar();
                MessageBox.Show("Dados salvos com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
    }
}
