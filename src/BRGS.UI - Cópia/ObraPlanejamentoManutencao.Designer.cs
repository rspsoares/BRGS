namespace BRGS.UI
{
    partial class ObraPlanejamentoManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObraPlanejamentoManutencao));
            this.tbValorContrato = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.tbDataTermino = new System.Windows.Forms.DateTimePicker();
            this.tbDataInicio = new System.Windows.Forms.DateTimePicker();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbPrevistoTotal = new System.Windows.Forms.Label();
            this.btRemover = new System.Windows.Forms.Button();
            this.gvPrevisao = new BRGS.Util.SortedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.tbValorPrevisto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUEN = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrevisao)).BeginInit();
            this.SuspendLayout();
            // 
            // tbValorContrato
            // 
            this.tbValorContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValorContrato.Location = new System.Drawing.Point(286, 78);
            this.tbValorContrato.MaxLength = 20;
            this.tbValorContrato.Name = "tbValorContrato";
            this.tbValorContrato.Size = new System.Drawing.Size(127, 20);
            this.tbValorContrato.TabIndex = 3;
            this.tbValorContrato.Text = "0,00";
            this.tbValorContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorContrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValorContrato_KeyDown);
            this.tbValorContrato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorContrato_KeyPress);
            this.tbValorContrato.Leave += new System.EventHandler(this.tbValorContrato_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(283, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Valor Contrato";
            // 
            // tbDescricao
            // 
            this.tbDescricao.Location = new System.Drawing.Point(9, 32);
            this.tbDescricao.MaxLength = 50;
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(535, 20);
            this.tbDescricao.TabIndex = 0;
            this.tbDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDescricao_KeyDown);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(6, 16);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(101, 13);
            this.label43.TabIndex = 22;
            this.label43.Text = "Descrição Etapa";
            // 
            // tbDataTermino
            // 
            this.tbDataTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataTermino.Location = new System.Drawing.Point(149, 78);
            this.tbDataTermino.Name = "tbDataTermino";
            this.tbDataTermino.Size = new System.Drawing.Size(131, 20);
            this.tbDataTermino.TabIndex = 2;
            // 
            // tbDataInicio
            // 
            this.tbDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataInicio.Location = new System.Drawing.Point(9, 78);
            this.tbDataInicio.Name = "tbDataInicio";
            this.tbDataInicio.Size = new System.Drawing.Size(131, 20);
            this.tbDataInicio.TabIndex = 1;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(146, 62);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(71, 13);
            this.label42.TabIndex = 19;
            this.label42.Text = "Data Término";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 62);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(60, 13);
            this.label41.TabIndex = 18;
            this.label41.Text = "Data Início";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbValorContrato);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tbDescricao);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.tbDataTermino);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.tbDataInicio);
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 293);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbPrevistoTotal);
            this.groupBox3.Controls.Add(this.btRemover);
            this.groupBox3.Controls.Add(this.gvPrevisao);
            this.groupBox3.Controls.Add(this.btAdicionar);
            this.groupBox3.Controls.Add(this.tbValorPrevisto);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbUEN);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(6, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(538, 183);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // lbPrevistoTotal
            // 
            this.lbPrevistoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrevistoTotal.ForeColor = System.Drawing.Color.Blue;
            this.lbPrevistoTotal.Location = new System.Drawing.Point(237, 154);
            this.lbPrevistoTotal.Name = "lbPrevistoTotal";
            this.lbPrevistoTotal.Size = new System.Drawing.Size(295, 23);
            this.lbPrevistoTotal.TabIndex = 14;
            this.lbPrevistoTotal.Text = "Total Previsto para a Etapa: R$ 0,00";
            this.lbPrevistoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btRemover
            // 
            this.btRemover.Location = new System.Drawing.Point(6, 154);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(75, 23);
            this.btRemover.TabIndex = 4;
            this.btRemover.Text = "Remover";
            this.btRemover.UseVisualStyleBackColor = true;
            this.btRemover.Click += new System.EventHandler(this.btRemover_Click);
            // 
            // gvPrevisao
            // 
            this.gvPrevisao.AllowUserToAddRows = false;
            this.gvPrevisao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvPrevisao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPrevisao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPrevisao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column7});
            this.gvPrevisao.Location = new System.Drawing.Point(6, 65);
            this.gvPrevisao.Name = "gvPrevisao";
            this.gvPrevisao.ReadOnly = true;
            this.gvPrevisao.RowHeadersVisible = false;
            this.gvPrevisao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPrevisao.Size = new System.Drawing.Size(526, 83);
            this.gvPrevisao.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "idUEN";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "UEN";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column7.HeaderText = "Valor";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 56;
            // 
            // btAdicionar
            // 
            this.btAdicionar.Location = new System.Drawing.Point(457, 30);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btAdicionar.TabIndex = 2;
            this.btAdicionar.Text = "Adicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // tbValorPrevisto
            // 
            this.tbValorPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValorPrevisto.Location = new System.Drawing.Point(322, 33);
            this.tbValorPrevisto.MaxLength = 20;
            this.tbValorPrevisto.Name = "tbValorPrevisto";
            this.tbValorPrevisto.Size = new System.Drawing.Size(123, 20);
            this.tbValorPrevisto.TabIndex = 1;
            this.tbValorPrevisto.Text = "0,00";
            this.tbValorPrevisto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorPrevisto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValorPrevisto_KeyDown);
            this.tbValorPrevisto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorPrevisto_KeyPress);
            this.tbValorPrevisto.Leave += new System.EventHandler(this.tbValorPrevisto_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(319, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valor Previsto";
            // 
            // cbUEN
            // 
            this.cbUEN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUEN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUEN.FormattingEnabled = true;
            this.cbUEN.Location = new System.Drawing.Point(6, 32);
            this.cbUEN.Name = "cbUEN";
            this.cbUEN.Size = new System.Drawing.Size(310, 21);
            this.cbUEN.TabIndex = 0;
            this.cbUEN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbUEN_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descrição UEN";
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(478, 301);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 2;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // ObraPlanejamentoManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 328);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObraPlanejamentoManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criação e Planejamento da Etapa";
            this.Load += new System.EventHandler(this.ObraPlanejamentoManutencao_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrevisao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbDescricao;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.DateTimePicker tbDataTermino;
        private System.Windows.Forms.DateTimePicker tbDataInicio;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox tbValorContrato;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btAdicionar;
        private System.Windows.Forms.TextBox tbValorPrevisto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUEN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPrevistoTotal;
        private System.Windows.Forms.Button btRemover;
        private Util.SortedDataGridView gvPrevisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btGravar;
    }
}