namespace GeradorCodigoBarras
{
    partial class frmConfiguracao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracao));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDelay = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPorta = new System.Windows.Forms.MaskedTextBox();
            this.txtIP = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.MaskedTextBox();
            this.txtSequencial = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sequencial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Valor da Série";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDelay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPorta);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(23, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 142);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impressora";
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(9, 98);
            this.txtDelay.Mask = "00,00";
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(100, 20);
            this.txtDelay.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Delay de envio em segundos";
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(202, 54);
            this.txtPorta.Mask = "0000";
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(52, 20);
            this.txtPorta.TabIndex = 21;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(9, 54);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(187, 20);
            this.txtIP.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Porta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "IP";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(163, 227);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 40);
            this.btnSalvar.TabIndex = 17;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(26, 41);
            this.txtValor.Mask = "00";
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(70, 20);
            this.txtValor.TabIndex = 18;
            // 
            // txtSequencial
            // 
            this.txtSequencial.Location = new System.Drawing.Point(177, 41);
            this.txtSequencial.Mask = "00000000";
            this.txtSequencial.Name = "txtSequencial";
            this.txtSequencial.Size = new System.Drawing.Size(100, 20);
            this.txtSequencial.TabIndex = 19;
            // 
            // frmConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 272);
            this.Controls.Add(this.txtSequencial);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfiguracao";
            this.Text = "Configuração";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.MaskedTextBox txtPorta;
        private System.Windows.Forms.MaskedTextBox txtIP;
        private System.Windows.Forms.MaskedTextBox txtValor;
        private System.Windows.Forms.MaskedTextBox txtSequencial;
        private System.Windows.Forms.MaskedTextBox txtDelay;
        private System.Windows.Forms.Label label3;
    }
}