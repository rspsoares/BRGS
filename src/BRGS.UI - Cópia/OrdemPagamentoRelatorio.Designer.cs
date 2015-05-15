namespace BRGS.UI
{
    partial class OrdemPagamentoRelatorio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.optDescendente = new System.Windows.Forms.RadioButton();
            this.optAscendente = new System.Windows.Forms.RadioButton();
            this.cbLicitacao = new System.Windows.Forms.ComboBox();
            this.chkLicitacao = new System.Windows.Forms.CheckBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.cbNomeEvento = new System.Windows.Forms.ComboBox();
            this.cbFavorecido = new System.Windows.Forms.ComboBox();
            this.chkNomeEvento = new System.Windows.Forms.CheckBox();
            this.chkFavorecido = new System.Windows.Forms.CheckBox();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.lbAte = new System.Windows.Forms.Label();
            this.optNao = new System.Windows.Forms.RadioButton();
            this.optSim = new System.Windows.Forms.RadioButton();
            this.chkPaga = new System.Windows.Forms.CheckBox();
            this.chkDataVencimento = new System.Windows.Forms.CheckBox();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.chkEmpresa = new System.Windows.Forms.CheckBox();
            this.btVisualizar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbResumido = new System.Windows.Forms.RadioButton();
            this.rbAgrupado = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.cbLicitacao);
            this.groupBox1.Controls.Add(this.chkLicitacao);
            this.groupBox1.Controls.Add(this.cbCliente);
            this.groupBox1.Controls.Add(this.chkCliente);
            this.groupBox1.Controls.Add(this.cbNomeEvento);
            this.groupBox1.Controls.Add(this.cbFavorecido);
            this.groupBox1.Controls.Add(this.chkNomeEvento);
            this.groupBox1.Controls.Add(this.chkFavorecido);
            this.groupBox1.Controls.Add(this.dtpAte);
            this.groupBox1.Controls.Add(this.dtpDe);
            this.groupBox1.Controls.Add(this.lbAte);
            this.groupBox1.Controls.Add(this.optNao);
            this.groupBox1.Controls.Add(this.optSim);
            this.groupBox1.Controls.Add(this.chkPaga);
            this.groupBox1.Controls.Add(this.chkDataVencimento);
            this.groupBox1.Controls.Add(this.cbEmpresa);
            this.groupBox1.Controls.Add(this.chkEmpresa);
            this.groupBox1.Location = new System.Drawing.Point(4, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 203);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.optDescendente);
            this.panel1.Controls.Add(this.optAscendente);
            this.panel1.Location = new System.Drawing.Point(376, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 30);
            this.panel1.TabIndex = 32;
            // 
            // optDescendente
            // 
            this.optDescendente.AutoSize = true;
            this.optDescendente.Enabled = false;
            this.optDescendente.Location = new System.Drawing.Point(102, 2);
            this.optDescendente.Name = "optDescendente";
            this.optDescendente.Size = new System.Drawing.Size(89, 17);
            this.optDescendente.TabIndex = 1;
            this.optDescendente.Text = "Descendente";
            this.optDescendente.UseVisualStyleBackColor = true;
            // 
            // optAscendente
            // 
            this.optAscendente.AutoSize = true;
            this.optAscendente.Checked = true;
            this.optAscendente.Enabled = false;
            this.optAscendente.Location = new System.Drawing.Point(3, 2);
            this.optAscendente.Name = "optAscendente";
            this.optAscendente.Size = new System.Drawing.Size(82, 17);
            this.optAscendente.TabIndex = 0;
            this.optAscendente.TabStop = true;
            this.optAscendente.Text = "Ascendente";
            this.optAscendente.UseVisualStyleBackColor = true;
            // 
            // cbLicitacao
            // 
            this.cbLicitacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLicitacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLicitacao.Enabled = false;
            this.cbLicitacao.FormattingEnabled = true;
            this.cbLicitacao.Location = new System.Drawing.Point(158, 71);
            this.cbLicitacao.Name = "cbLicitacao";
            this.cbLicitacao.Size = new System.Drawing.Size(351, 21);
            this.cbLicitacao.TabIndex = 31;
            // 
            // chkLicitacao
            // 
            this.chkLicitacao.AutoSize = true;
            this.chkLicitacao.Enabled = false;
            this.chkLicitacao.Location = new System.Drawing.Point(43, 73);
            this.chkLicitacao.Name = "chkLicitacao";
            this.chkLicitacao.Size = new System.Drawing.Size(109, 17);
            this.chkLicitacao.TabIndex = 30;
            this.chkLicitacao.Text = "Número Licitação";
            this.chkLicitacao.UseVisualStyleBackColor = true;
            this.chkLicitacao.CheckedChanged += new System.EventHandler(this.chkLicitacao_CheckedChanged);
            // 
            // cbCliente
            // 
            this.cbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCliente.Enabled = false;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(138, 44);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(439, 21);
            this.cbCliente.TabIndex = 29;
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbCliente_SelectedIndexChanged);
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Location = new System.Drawing.Point(8, 46);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(124, 17);
            this.chkCliente.TabIndex = 28;
            this.chkCliente.Text = "Cliente / Contratante";
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // cbNomeEvento
            // 
            this.cbNomeEvento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNomeEvento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNomeEvento.Enabled = false;
            this.cbNomeEvento.FormattingEnabled = true;
            this.cbNomeEvento.Location = new System.Drawing.Point(138, 125);
            this.cbNomeEvento.Name = "cbNomeEvento";
            this.cbNomeEvento.Size = new System.Drawing.Size(439, 21);
            this.cbNomeEvento.TabIndex = 27;
            // 
            // cbFavorecido
            // 
            this.cbFavorecido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFavorecido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFavorecido.Enabled = false;
            this.cbFavorecido.FormattingEnabled = true;
            this.cbFavorecido.Location = new System.Drawing.Point(138, 98);
            this.cbFavorecido.Name = "cbFavorecido";
            this.cbFavorecido.Size = new System.Drawing.Size(439, 21);
            this.cbFavorecido.TabIndex = 26;
            // 
            // chkNomeEvento
            // 
            this.chkNomeEvento.AutoSize = true;
            this.chkNomeEvento.Location = new System.Drawing.Point(8, 127);
            this.chkNomeEvento.Name = "chkNomeEvento";
            this.chkNomeEvento.Size = new System.Drawing.Size(91, 17);
            this.chkNomeEvento.TabIndex = 25;
            this.chkNomeEvento.Text = "Nome Evento";
            this.chkNomeEvento.UseVisualStyleBackColor = true;
            this.chkNomeEvento.CheckedChanged += new System.EventHandler(this.chkNomeEvento_CheckedChanged);
            // 
            // chkFavorecido
            // 
            this.chkFavorecido.AutoSize = true;
            this.chkFavorecido.Location = new System.Drawing.Point(8, 100);
            this.chkFavorecido.Name = "chkFavorecido";
            this.chkFavorecido.Size = new System.Drawing.Size(126, 17);
            this.chkFavorecido.TabIndex = 24;
            this.chkFavorecido.Text = "Favorecido / Fornec.";
            this.chkFavorecido.UseVisualStyleBackColor = true;
            this.chkFavorecido.CheckedChanged += new System.EventHandler(this.chkFavorecido_CheckedChanged);
            // 
            // dtpAte
            // 
            this.dtpAte.Enabled = false;
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(271, 152);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(99, 20);
            this.dtpAte.TabIndex = 23;
            // 
            // dtpDe
            // 
            this.dtpDe.Enabled = false;
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(138, 152);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(99, 20);
            this.dtpDe.TabIndex = 22;
            // 
            // lbAte
            // 
            this.lbAte.AutoSize = true;
            this.lbAte.Location = new System.Drawing.Point(243, 155);
            this.lbAte.Name = "lbAte";
            this.lbAte.Size = new System.Drawing.Size(22, 13);
            this.lbAte.TabIndex = 21;
            this.lbAte.Text = "até";
            // 
            // optNao
            // 
            this.optNao.AutoSize = true;
            this.optNao.Enabled = false;
            this.optNao.Location = new System.Drawing.Point(186, 178);
            this.optNao.Name = "optNao";
            this.optNao.Size = new System.Drawing.Size(45, 17);
            this.optNao.TabIndex = 12;
            this.optNao.Text = "Não";
            this.optNao.UseVisualStyleBackColor = true;
            // 
            // optSim
            // 
            this.optSim.AutoSize = true;
            this.optSim.Enabled = false;
            this.optSim.Location = new System.Drawing.Point(138, 178);
            this.optSim.Name = "optSim";
            this.optSim.Size = new System.Drawing.Size(42, 17);
            this.optSim.TabIndex = 11;
            this.optSim.Text = "Sim";
            this.optSim.UseVisualStyleBackColor = true;
            // 
            // chkPaga
            // 
            this.chkPaga.AutoSize = true;
            this.chkPaga.Location = new System.Drawing.Point(8, 178);
            this.chkPaga.Name = "chkPaga";
            this.chkPaga.Size = new System.Drawing.Size(51, 17);
            this.chkPaga.TabIndex = 10;
            this.chkPaga.Text = "Paga";
            this.chkPaga.UseVisualStyleBackColor = true;
            this.chkPaga.CheckedChanged += new System.EventHandler(this.chkPaga_CheckedChanged);
            // 
            // chkDataVencimento
            // 
            this.chkDataVencimento.AutoSize = true;
            this.chkDataVencimento.Location = new System.Drawing.Point(8, 155);
            this.chkDataVencimento.Name = "chkDataVencimento";
            this.chkDataVencimento.Size = new System.Drawing.Size(108, 17);
            this.chkDataVencimento.TabIndex = 2;
            this.chkDataVencimento.Text = "Data Vencimento";
            this.chkDataVencimento.UseVisualStyleBackColor = true;
            this.chkDataVencimento.CheckedChanged += new System.EventHandler(this.chkDataVencimento_CheckedChanged);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEmpresa.Enabled = false;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(138, 17);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(439, 21);
            this.cbEmpresa.TabIndex = 1;
            this.cbEmpresa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEmpresa_KeyDown);
            // 
            // chkEmpresa
            // 
            this.chkEmpresa.AutoSize = true;
            this.chkEmpresa.Location = new System.Drawing.Point(8, 19);
            this.chkEmpresa.Name = "chkEmpresa";
            this.chkEmpresa.Size = new System.Drawing.Size(67, 17);
            this.chkEmpresa.TabIndex = 0;
            this.chkEmpresa.Text = "Empresa";
            this.chkEmpresa.UseVisualStyleBackColor = true;
            this.chkEmpresa.CheckedChanged += new System.EventHandler(this.chkEmpresa_CheckedChanged);
            // 
            // btVisualizar
            // 
            this.btVisualizar.Location = new System.Drawing.Point(512, 276);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btVisualizar.TabIndex = 2;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.UseVisualStyleBackColor = true;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(4, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 55);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Relatório";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rbResumido, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbAgrupado, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(577, 36);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // rbResumido
            // 
            this.rbResumido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbResumido.AutoSize = true;
            this.rbResumido.Location = new System.Drawing.Point(396, 9);
            this.rbResumido.Name = "rbResumido";
            this.rbResumido.Size = new System.Drawing.Size(72, 17);
            this.rbResumido.TabIndex = 2;
            this.rbResumido.TabStop = true;
            this.rbResumido.Text = "Resumido";
            this.rbResumido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbResumido.UseVisualStyleBackColor = true;
            // 
            // rbAgrupado
            // 
            this.rbAgrupado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbAgrupado.AutoSize = true;
            this.rbAgrupado.Checked = true;
            this.rbAgrupado.Location = new System.Drawing.Point(108, 9);
            this.rbAgrupado.Name = "rbAgrupado";
            this.rbAgrupado.Size = new System.Drawing.Size(71, 17);
            this.rbAgrupado.TabIndex = 1;
            this.rbAgrupado.TabStop = true;
            this.rbAgrupado.Text = "Agrupado";
            this.rbAgrupado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAgrupado.UseVisualStyleBackColor = true;
            // 
            // OrdemPagamentoRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 304);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btVisualizar);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrdemPagamentoRelatorio";
            this.Text = "OrdemPagamentoRelatorio";
            this.Load += new System.EventHandler(this.OrdemPagamentoRelatorio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEmpresa;
        private System.Windows.Forms.CheckBox chkDataVencimento;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.RadioButton optNao;
        private System.Windows.Forms.RadioButton optSim;
        private System.Windows.Forms.CheckBox chkPaga;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.Label lbAte;
        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rbResumido;
        private System.Windows.Forms.RadioButton rbAgrupado;
        private System.Windows.Forms.CheckBox chkNomeEvento;
        private System.Windows.Forms.CheckBox chkFavorecido;
        private System.Windows.Forms.ComboBox cbNomeEvento;
        private System.Windows.Forms.ComboBox cbFavorecido;
        private System.Windows.Forms.CheckBox chkLicitacao;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.ComboBox cbLicitacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton optDescendente;
        private System.Windows.Forms.RadioButton optAscendente;
    }
}