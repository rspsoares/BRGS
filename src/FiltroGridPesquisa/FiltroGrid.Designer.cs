namespace FiltroGridPesquisa
{
    partial class FiltroGrid
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.cbPesquisaCampo = new System.Windows.Forms.ComboBox();
            this.tbPesquisaValor = new System.Windows.Forms.TextBox();
            this.tbDataInicial = new System.Windows.Forms.DateTimePicker();
            this.tbDataFinal = new System.Windows.Forms.DateTimePicker();
            this.lbDe = new System.Windows.Forms.Label();
            this.lbAte = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btPesquisar);
            this.groupBox1.Controls.Add(this.cbPesquisaCampo);
            this.groupBox1.Controls.Add(this.tbPesquisaValor);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 49);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro da pesquisa";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(476, 18);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(81, 23);
            this.btPesquisar.TabIndex = 2;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            // 
            // cbPesquisaCampo
            // 
            this.cbPesquisaCampo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPesquisaCampo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPesquisaCampo.FormattingEnabled = true;
            this.cbPesquisaCampo.Location = new System.Drawing.Point(8, 19);
            this.cbPesquisaCampo.Name = "cbPesquisaCampo";
            this.cbPesquisaCampo.Size = new System.Drawing.Size(132, 21);
            this.cbPesquisaCampo.TabIndex = 0;
            this.cbPesquisaCampo.SelectedIndexChanged += new System.EventHandler(this.cbPesquisaCampo_SelectedIndexChanged);
            // 
            // tbPesquisaValor
            // 
            this.tbPesquisaValor.Location = new System.Drawing.Point(146, 20);
            this.tbPesquisaValor.Name = "tbPesquisaValor";
            this.tbPesquisaValor.Size = new System.Drawing.Size(324, 20);
            this.tbPesquisaValor.TabIndex = 1;
            // 
            // tbDataInicial
            // 
            this.tbDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataInicial.Location = new System.Drawing.Point(118, 64);
            this.tbDataInicial.Name = "tbDataInicial";
            this.tbDataInicial.Size = new System.Drawing.Size(110, 20);
            this.tbDataInicial.TabIndex = 18;
            // 
            // tbDataFinal
            // 
            this.tbDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataFinal.Location = new System.Drawing.Point(284, 58);
            this.tbDataFinal.Name = "tbDataFinal";
            this.tbDataFinal.Size = new System.Drawing.Size(110, 20);
            this.tbDataFinal.TabIndex = 19;
            // 
            // lbDe
            // 
            this.lbDe.AutoSize = true;
            this.lbDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDe.Location = new System.Drawing.Point(57, 64);
            this.lbDe.Name = "lbDe";
            this.lbDe.Size = new System.Drawing.Size(27, 13);
            this.lbDe.TabIndex = 20;
            this.lbDe.Text = "De:";
            // 
            // lbAte
            // 
            this.lbAte.AutoSize = true;
            this.lbAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAte.Location = new System.Drawing.Point(248, 58);
            this.lbAte.Name = "lbAte";
            this.lbAte.Size = new System.Drawing.Size(30, 13);
            this.lbAte.TabIndex = 21;
            this.lbAte.Text = "Até:";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lbAte);
            this.Controls.Add(this.lbDe);
            this.Controls.Add(this.tbDataFinal);
            this.Controls.Add(this.tbDataInicial);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(572, 172);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.ComboBox cbPesquisaCampo;
        private System.Windows.Forms.TextBox tbPesquisaValor;
        private System.Windows.Forms.DateTimePicker tbDataInicial;
        private System.Windows.Forms.DateTimePicker tbDataFinal;
        private System.Windows.Forms.Label lbDe;
        private System.Windows.Forms.Label lbAte;
    }
}
