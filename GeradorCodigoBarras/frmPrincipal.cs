using System;
using System.Windows.Forms;

namespace GeradorCodigoBarras
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }        

        private void smiImpressao_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmImpressao)) {
                    form.Activate();
                    form.Refresh();
                    return;
                }
            }
            frmImpressao frm = new frmImpressao();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        private void smiConfiguracao_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmConfiguracao))
                {
                    form.Activate();
                    form.Refresh();
                    return;
                }
            }
            frmConfiguracao frm = new frmConfiguracao();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void smiSobre_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmSobre))
                {
                    form.Activate();
                    form.Refresh();
                    return;
                }
            }
            Form frm = new frmSobre();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
