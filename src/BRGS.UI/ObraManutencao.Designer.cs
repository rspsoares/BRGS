namespace BRGS.UI
{
    partial class ObraManutencao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObraManutencao));
            this.grpInformacoes = new System.Windows.Forms.GroupBox();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbValorBruto = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbNomeEvento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumeroLicitacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTotalOPAberto = new System.Windows.Forms.Label();
            this.lbTotalNotaFiscal = new System.Windows.Forms.Label();
            this.lbTotalOPGerada = new System.Windows.Forms.Label();
            this.lbSaldoObra = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.btVisualizarEtapa = new System.Windows.Forms.Button();
            this.btNovaEtapa = new System.Windows.Forms.Button();
            this.gvEtapas = new BRGS.Util.SortedDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idObra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroLicitacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpInformacoes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEtapas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInformacoes
            // 
            this.grpInformacoes.Controls.Add(this.cbClientes);
            this.grpInformacoes.Controls.Add(this.cbEmpresa);
            this.grpInformacoes.Controls.Add(this.label15);
            this.grpInformacoes.Controls.Add(this.tbValorBruto);
            this.grpInformacoes.Controls.Add(this.label14);
            this.grpInformacoes.Controls.Add(this.tbNomeEvento);
            this.grpInformacoes.Controls.Add(this.label3);
            this.grpInformacoes.Controls.Add(this.label2);
            this.grpInformacoes.Controls.Add(this.tbNumeroLicitacao);
            this.grpInformacoes.Controls.Add(this.label1);
            this.grpInformacoes.Location = new System.Drawing.Point(5, 3);
            this.grpInformacoes.Name = "grpInformacoes";
            this.grpInformacoes.Size = new System.Drawing.Size(729, 100);
            this.grpInformacoes.TabIndex = 0;
            this.grpInformacoes.TabStop = false;
            this.grpInformacoes.Text = "Informações da Obra";
            // 
            // cbClientes
            // 
            this.cbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(6, 73);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(414, 21);
            this.cbClientes.TabIndex = 3;
            this.cbClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbClientes_KeyDown);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(6, 32);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(332, 21);
            this.cbEmpresa.TabIndex = 0;
            this.cbEmpresa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEmpresa_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Empresa";
            // 
            // tbValorBruto
            // 
            this.tbValorBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValorBruto.Location = new System.Drawing.Point(596, 32);
            this.tbValorBruto.MaxLength = 20;
            this.tbValorBruto.Name = "tbValorBruto";
            this.tbValorBruto.Size = new System.Drawing.Size(127, 20);
            this.tbValorBruto.TabIndex = 2;
            this.tbValorBruto.Text = "0,00";
            this.tbValorBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorBruto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValorBruto_KeyDown);
            this.tbValorBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorBruto_KeyPress);
            this.tbValorBruto.Leave += new System.EventHandler(this.tbValorBruto_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(653, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Valor Bruto";
            // 
            // tbNomeEvento
            // 
            this.tbNomeEvento.Location = new System.Drawing.Point(426, 74);
            this.tbNomeEvento.MaxLength = 100;
            this.tbNomeEvento.Name = "tbNomeEvento";
            this.tbNomeEvento.Size = new System.Drawing.Size(297, 20);
            this.tbNomeEvento.TabIndex = 4;
            this.tbNomeEvento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNomeEvento_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(423, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nome Evento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome Cliente";
            // 
            // tbNumeroLicitacao
            // 
            this.tbNumeroLicitacao.Location = new System.Drawing.Point(343, 32);
            this.tbNumeroLicitacao.MaxLength = 50;
            this.tbNumeroLicitacao.Name = "tbNumeroLicitacao";
            this.tbNumeroLicitacao.Size = new System.Drawing.Size(247, 20);
            this.tbNumeroLicitacao.TabIndex = 1;
            this.tbNumeroLicitacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNumeroLicitacao_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Número Licitação";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(5, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(729, 74);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Totais";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.39696F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.64177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.82296F));
            this.tableLayoutPanel1.Controls.Add(this.lbTotalOPAberto, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbTotalNotaFiscal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbTotalOPGerada, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbSaldoObra, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(723, 55);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lbTotalOPAberto
            // 
            this.lbTotalOPAberto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalOPAberto.AutoSize = true;
            this.lbTotalOPAberto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalOPAberto.Location = new System.Drawing.Point(516, 34);
            this.lbTotalOPAberto.Name = "lbTotalOPAberto";
            this.lbTotalOPAberto.Size = new System.Drawing.Size(204, 15);
            this.lbTotalOPAberto.TabIndex = 3;
            this.lbTotalOPAberto.Text = "Total OP\'s em aberto:  R$ 0,00";
            this.lbTotalOPAberto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTotalNotaFiscal
            // 
            this.lbTotalNotaFiscal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalNotaFiscal.AutoSize = true;
            this.lbTotalNotaFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalNotaFiscal.Location = new System.Drawing.Point(230, 7);
            this.lbTotalNotaFiscal.Name = "lbTotalNotaFiscal";
            this.lbTotalNotaFiscal.Size = new System.Drawing.Size(230, 15);
            this.lbTotalNotaFiscal.TabIndex = 1;
            this.lbTotalNotaFiscal.Text = "Total N.F. geradas: R$ 0,00";
            this.lbTotalNotaFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotalOPGerada
            // 
            this.lbTotalOPGerada.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalOPGerada.AutoSize = true;
            this.lbTotalOPGerada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalOPGerada.Location = new System.Drawing.Point(533, 7);
            this.lbTotalOPGerada.Name = "lbTotalOPGerada";
            this.lbTotalOPGerada.Size = new System.Drawing.Size(187, 15);
            this.lbTotalOPGerada.TabIndex = 2;
            this.lbTotalOPGerada.Text = "Total OP\'s geradas: R$ 0,00";
            this.lbTotalOPGerada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSaldoObra
            // 
            this.lbSaldoObra.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbSaldoObra.AutoSize = true;
            this.lbSaldoObra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSaldoObra.Location = new System.Drawing.Point(3, 7);
            this.lbSaldoObra.Name = "lbSaldoObra";
            this.lbSaldoObra.Size = new System.Drawing.Size(137, 15);
            this.lbSaldoObra.TabIndex = 0;
            this.lbSaldoObra.Text = "Saldo Obra: R$ 0,00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "(Valor Bruto - Total de OP\'s pagas)";
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(659, 404);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 4;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btVisualizarEtapa
            // 
            this.btVisualizarEtapa.Location = new System.Drawing.Point(645, 178);
            this.btVisualizarEtapa.Name = "btVisualizarEtapa";
            this.btVisualizarEtapa.Size = new System.Drawing.Size(75, 23);
            this.btVisualizarEtapa.TabIndex = 6;
            this.btVisualizarEtapa.Text = "Visualizar";
            this.btVisualizarEtapa.UseVisualStyleBackColor = true;
            this.btVisualizarEtapa.Click += new System.EventHandler(this.btVisualizarEtapa_Click);
            // 
            // btNovaEtapa
            // 
            this.btNovaEtapa.Location = new System.Drawing.Point(11, 178);
            this.btNovaEtapa.Name = "btNovaEtapa";
            this.btNovaEtapa.Size = new System.Drawing.Size(69, 23);
            this.btNovaEtapa.TabIndex = 5;
            this.btNovaEtapa.Text = "Nova";
            this.btNovaEtapa.UseVisualStyleBackColor = true;
            this.btNovaEtapa.Click += new System.EventHandler(this.btNovaEtapa_Click);
            // 
            // gvEtapas
            // 
            this.gvEtapas.AllowUserToAddRows = false;
            this.gvEtapas.AllowUserToDeleteRows = false;
            this.gvEtapas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvEtapas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvEtapas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEtapas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idObra,
            this.Column3,
            this.NumeroLicitacao,
            this.Evento,
            this.Column1,
            this.Column2,
            this.Column4});
            this.gvEtapas.Location = new System.Drawing.Point(11, 25);
            this.gvEtapas.Name = "gvEtapas";
            this.gvEtapas.ReadOnly = true;
            this.gvEtapas.RowHeadersVisible = false;
            this.gvEtapas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvEtapas.Size = new System.Drawing.Size(709, 144);
            this.gvEtapas.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btVisualizarEtapa);
            this.groupBox1.Controls.Add(this.gvEtapas);
            this.groupBox1.Controls.Add(this.btNovaEtapa);
            this.groupBox1.Location = new System.Drawing.Point(5, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 205);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Etapas";
            // 
            // idObra
            // 
            this.idObra.HeaderText = "idEtapa";
            this.idObra.Name = "idObra";
            this.idObra.ReadOnly = true;
            this.idObra.Visible = false;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Descrição";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // NumeroLicitacao
            // 
            this.NumeroLicitacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NumeroLicitacao.HeaderText = "Data Início";
            this.NumeroLicitacao.Name = "NumeroLicitacao";
            this.NumeroLicitacao.ReadOnly = true;
            this.NumeroLicitacao.Width = 85;
            // 
            // Evento
            // 
            this.Evento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Evento.HeaderText = "Data Término";
            this.Evento.Name = "Evento";
            this.Evento.ReadOnly = true;
            this.Evento.Width = 96;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Saldo Etapa";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Total Etapa";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 87;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.HeaderText = "Status";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 62;
            // 
            // ObraManutencao_old
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 430);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpInformacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObraManutencao_old";
            this.Text = "Gerenciador de Etapas da Obra";
            this.Load += new System.EventHandler(this.ObraManutencao_Load);
            this.grpInformacoes.ResumeLayout(false);
            this.grpInformacoes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEtapas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInformacoes;
        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbValorBruto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbNomeEvento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumeroLicitacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbTotalOPAberto;
        private System.Windows.Forms.Label lbTotalOPGerada;
        private System.Windows.Forms.Label lbTotalNotaFiscal;
        private System.Windows.Forms.Label lbSaldoObra;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.Label label4;
        private Util.SortedDataGridView gvEtapas;
        private System.Windows.Forms.Button btVisualizarEtapa;
        private System.Windows.Forms.Button btNovaEtapa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroLicitacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}