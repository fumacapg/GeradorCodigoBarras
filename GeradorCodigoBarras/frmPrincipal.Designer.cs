namespace GeradorCodigoBarras
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.smiImpressao = new System.Windows.Forms.ToolStripMenuItem();
            this.smiConfiguracao = new System.Windows.Forms.ToolStripMenuItem();
            this.smiSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiImpressao,
            this.smiConfiguracao,
            this.smiSobre});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(334, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // smiImpressao
            // 
            this.smiImpressao.Name = "smiImpressao";
            this.smiImpressao.Size = new System.Drawing.Size(73, 20);
            this.smiImpressao.Text = "Impressão";
            this.smiImpressao.Click += new System.EventHandler(this.smiImpressao_Click);
            // 
            // smiConfiguracao
            // 
            this.smiConfiguracao.Name = "smiConfiguracao";
            this.smiConfiguracao.Size = new System.Drawing.Size(91, 20);
            this.smiConfiguracao.Text = "Configuração";
            this.smiConfiguracao.Click += new System.EventHandler(this.smiConfiguracao_Click);
            // 
            // smiSobre
            // 
            this.smiSobre.Name = "smiSobre";
            this.smiSobre.Size = new System.Drawing.Size(49, 20);
            this.smiSobre.Text = "Sobre";
            this.smiSobre.Click += new System.EventHandler(this.smiSobre_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(334, 312);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmPrincipal";
            this.Text = "Gerador de Código de Barras";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem smiImpressao;
        private System.Windows.Forms.ToolStripMenuItem smiConfiguracao;
        private System.Windows.Forms.ToolStripMenuItem smiSobre;
    }
}



