namespace BRGS.UI
{
    partial class OrdemPagamentoConsulta
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
            this.btNova = new System.Windows.Forms.Button();
            this.btVisualizar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvOrdensPagamentos = new BRGS.Util.SortedDataGridView();
            this.idOrdemPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroLicitacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.cbPesquisaCampo = new System.Windows.Forms.ComboBox();
            this.tbPesquisaValor = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrdensPagamentos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btNova
            // 
            this.btNova.Location = new System.Drawing.Point(6, 360);
            this.btNova.Name = "btNova";
            this.btNova.Size = new System.Drawing.Size(75, 23);
            this.btNova.TabIndex = 11;
            this.btNova.Text = "Nova OP";
            this.btNova.UseVisualStyleBackColor = true;
            this.btNova.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btVisualizar
            // 
            this.btVisualizar.Location = new System.Drawing.Point(1029, 360);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btVisualizar.TabIndex = 10;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.UseVisualStyleBackColor = true;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvOrdensPagamentos);
            this.groupBox2.Location = new System.Drawing.Point(3, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1104, 297);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // gvOrdensPagamentos
            // 
            this.gvOrdensPagamentos.AllowUserToAddRows = false;
            this.gvOrdensPagamentos.AllowUserToDeleteRows = false;
            this.gvOrdensPagamentos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvOrdensPagamentos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvOrdensPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrdensPagamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idOrdemPagamento,
            this.Column7,
            this.NomeCliente,
            this.Column2,
            this.Column3,
            this.NumeroLicitacao,
            this.Evento,
            this.Status,
            this.Column4,
            this.Column5,
            this.Vencimento});
            this.gvOrdensPagamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvOrdensPagamentos.Location = new System.Drawing.Point(3, 16);
            this.gvOrdensPagamentos.Name = "gvOrdensPagamentos";
            this.gvOrdensPagamentos.ReadOnly = true;
            this.gvOrdensPagamentos.RowHeadersVisible = false;
            this.gvOrdensPagamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvOrdensPagamentos.Size = new System.Drawing.Size(1098, 278);
            this.gvOrdensPagamentos.TabIndex = 0;
            this.gvOrdensPagamentos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvOrdensPagamentos_MouseDoubleClick);
            // 
            // idOrdemPagamento
            // 
            this.idOrdemPagamento.HeaderText = "idOrdemPagamento";
            this.idOrdemPagamento.MinimumWidth = 2;
            this.idOrdemPagamento.Name = "idOrdemPagamento";
            this.idOrdemPagamento.ReadOnly = true;
            this.idOrdemPagamento.Visible = false;
            this.idOrdemPagamento.Width = 2;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column7.HeaderText = "Número OP";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 87;
            // 
            // NomeCliente
            // 
            this.NomeCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NomeCliente.HeaderText = "Empresa";
            this.NomeCliente.Name = "NomeCliente";
            this.NomeCliente.ReadOnly = true;
            this.NomeCliente.Width = 73;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Cliente";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Evento";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // NumeroLicitacao
            // 
            this.NumeroLicitacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumeroLicitacao.HeaderText = "Favorecido";
            this.NumeroLicitacao.Name = "NumeroLicitacao";
            this.NumeroLicitacao.ReadOnly = true;
            // 
            // Evento
            // 
            this.Evento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Evento.DefaultCellStyle = dataGridViewCellStyle2;
            this.Evento.HeaderText = "Valor";
            this.Evento.Name = "Evento";
            this.Evento.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 62;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.HeaderText = "Data Pagto";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 86;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Observação";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Vencimento
            // 
            this.Vencimento.HeaderText = "VencParc";
            this.Vencimento.Name = "Vencimento";
            this.Vencimento.ReadOnly = true;
            this.Vencimento.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btPesquisar);
            this.groupBox1.Controls.Add(this.cbPesquisaCampo);
            this.groupBox1.Controls.Add(this.tbPesquisaValor);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1104, 49);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro da pesquisa";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(1017, 17);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(81, 23);
            this.btPesquisar.TabIndex = 2;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
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
            this.cbPesquisaCampo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPesquisaCampo_KeyDown);
            // 
            // tbPesquisaValor
            // 
            this.tbPesquisaValor.Location = new System.Drawing.Point(146, 20);
            this.tbPesquisaValor.Name = "tbPesquisaValor";
            this.tbPesquisaValor.Size = new System.Drawing.Size(865, 20);
            this.tbPesquisaValor.TabIndex = 1;
            this.tbPesquisaValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPesquisaValor_KeyDown);
            // 
            // OrdemPagamentoConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 388);
            this.Controls.Add(this.btNova);
            this.Controls.Add(this.btVisualizar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrdemPagamentoConsulta";
            this.Text = "OrdemPagamentoConsulta";
            this.Load += new System.EventHandler(this.OrdemPagamentoConsulta_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvOrdensPagamentos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btNova;
        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private Util.SortedDataGridView gvOrdensPagamentos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.ComboBox cbPesquisaCampo;
        private System.Windows.Forms.TextBox tbPesquisaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdemPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroLicitacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vencimento;
    }
}