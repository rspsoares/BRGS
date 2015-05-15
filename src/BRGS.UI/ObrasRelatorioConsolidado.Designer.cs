namespace BRGS.UI
{
    partial class ObrasRelatorioConsolidado
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.lbAte = new System.Windows.Forms.Label();
            this.optNao = new System.Windows.Forms.RadioButton();
            this.optSim = new System.Windows.Forms.RadioButton();
            this.chkDataPagamento = new System.Windows.Forms.CheckBox();
            this.cbLicitacao = new System.Windows.Forms.ComboBox();
            this.chkLicitacao = new System.Windows.Forms.CheckBox();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.btVisualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpAte);
            this.groupBox1.Controls.Add(this.dtpDe);
            this.groupBox1.Controls.Add(this.lbAte);
            this.groupBox1.Controls.Add(this.optNao);
            this.groupBox1.Controls.Add(this.optSim);
            this.groupBox1.Controls.Add(this.chkDataPagamento);
            this.groupBox1.Controls.Add(this.cbLicitacao);
            this.groupBox1.Controls.Add(this.chkLicitacao);
            this.groupBox1.Controls.Add(this.cbClientes);
            this.groupBox1.Controls.Add(this.chkCliente);
            this.groupBox1.Location = new System.Drawing.Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpAte
            // 
            this.dtpAte.Enabled = false;
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(232, 67);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(99, 20);
            this.dtpAte.TabIndex = 6;
            // 
            // dtpDe
            // 
            this.dtpDe.Enabled = false;
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(99, 67);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(99, 20);
            this.dtpDe.TabIndex = 5;
            // 
            // lbAte
            // 
            this.lbAte.AutoSize = true;
            this.lbAte.Location = new System.Drawing.Point(204, 71);
            this.lbAte.Name = "lbAte";
            this.lbAte.Size = new System.Drawing.Size(22, 13);
            this.lbAte.TabIndex = 42;
            this.lbAte.Text = "até";
            // 
            // optNao
            // 
            this.optNao.AutoSize = true;
            this.optNao.Location = new System.Drawing.Point(147, 91);
            this.optNao.Name = "optNao";
            this.optNao.Size = new System.Drawing.Size(45, 17);
            this.optNao.TabIndex = 9;
            this.optNao.Text = "Não";
            this.optNao.UseVisualStyleBackColor = true;
            // 
            // optSim
            // 
            this.optSim.AutoSize = true;
            this.optSim.Checked = true;
            this.optSim.Location = new System.Drawing.Point(99, 90);
            this.optSim.Name = "optSim";
            this.optSim.Size = new System.Drawing.Size(42, 17);
            this.optSim.TabIndex = 8;
            this.optSim.TabStop = true;
            this.optSim.Text = "Sim";
            this.optSim.UseVisualStyleBackColor = true;
            // 
            // chkDataPagamento
            // 
            this.chkDataPagamento.AutoSize = true;
            this.chkDataPagamento.Location = new System.Drawing.Point(10, 67);
            this.chkDataPagamento.Name = "chkDataPagamento";
            this.chkDataPagamento.Size = new System.Drawing.Size(80, 17);
            this.chkDataPagamento.TabIndex = 4;
            this.chkDataPagamento.Text = "Data Pagto";
            this.chkDataPagamento.UseVisualStyleBackColor = true;
            this.chkDataPagamento.CheckedChanged += new System.EventHandler(this.chkDataPagamento_CheckedChanged);
            // 
            // cbLicitacao
            // 
            this.cbLicitacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLicitacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLicitacao.Enabled = false;
            this.cbLicitacao.FormattingEnabled = true;
            this.cbLicitacao.Location = new System.Drawing.Point(146, 35);
            this.cbLicitacao.Name = "cbLicitacao";
            this.cbLicitacao.Size = new System.Drawing.Size(370, 21);
            this.cbLicitacao.TabIndex = 3;
            // 
            // chkLicitacao
            // 
            this.chkLicitacao.AutoSize = true;
            this.chkLicitacao.Enabled = false;
            this.chkLicitacao.Location = new System.Drawing.Point(31, 37);
            this.chkLicitacao.Name = "chkLicitacao";
            this.chkLicitacao.Size = new System.Drawing.Size(109, 17);
            this.chkLicitacao.TabIndex = 2;
            this.chkLicitacao.Text = "Número Licitação";
            this.chkLicitacao.UseVisualStyleBackColor = true;
            this.chkLicitacao.CheckedChanged += new System.EventHandler(this.chkLicitacao_CheckedChanged);
            // 
            // cbClientes
            // 
            this.cbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClientes.Enabled = false;
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(99, 10);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(551, 21);
            this.cbClientes.TabIndex = 1;
            this.cbClientes.SelectedIndexChanged += new System.EventHandler(this.cbClientes_SelectedIndexChanged);
            this.cbClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbClientes_KeyDown);
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Location = new System.Drawing.Point(10, 12);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(58, 17);
            this.chkCliente.TabIndex = 0;
            this.chkCliente.Text = "Cliente";
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // btVisualizar
            // 
            this.btVisualizar.Location = new System.Drawing.Point(583, 120);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btVisualizar.TabIndex = 3;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.UseVisualStyleBackColor = true;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Paga:";
            // 
            // ObrasRelatorioConsolidado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 148);
            this.Controls.Add(this.btVisualizar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ObrasRelatorioConsolidado";
            this.Text = "ObrasRelatorioConsolidado";
            this.Load += new System.EventHandler(this.ObrasRelatorioConsolidado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbLicitacao;
        private System.Windows.Forms.CheckBox chkLicitacao;
        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.Label lbAte;
        private System.Windows.Forms.RadioButton optNao;
        private System.Windows.Forms.RadioButton optSim;
        private System.Windows.Forms.CheckBox chkDataPagamento;
        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.Label label1;
    }
}