namespace BRGS.UI
{
    partial class MultaOcorrenciaManutencao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultaOcorrenciaManutencao));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbGravidade = new System.Windows.Forms.TextBox();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPontos = new System.Windows.Forms.TextBox();
            this.tbInfrator = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMotoristas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbVeiculos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMultas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvUsos = new BRGS.Util.SortedDataGridView();
            this.idMulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbData = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btGravar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNumeroOP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbStatusOP = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbStatusOP);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbNumeroOP);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cbMotoristas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbVeiculos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMultas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbData);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 405);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbCodigo);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbGravidade);
            this.groupBox3.Controls.Add(this.tbValor);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbPontos);
            this.groupBox3.Controls.Add(this.tbInfrator);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(9, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(555, 64);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informações sobre a multa";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Enabled = false;
            this.tbCodigo.Location = new System.Drawing.Point(6, 38);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(56, 20);
            this.tbCodigo.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Código";
            // 
            // tbGravidade
            // 
            this.tbGravidade.Enabled = false;
            this.tbGravidade.Location = new System.Drawing.Point(313, 38);
            this.tbGravidade.Name = "tbGravidade";
            this.tbGravidade.Size = new System.Drawing.Size(152, 20);
            this.tbGravidade.TabIndex = 24;
            // 
            // tbValor
            // 
            this.tbValor.Enabled = false;
            this.tbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValor.Location = new System.Drawing.Point(471, 38);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(79, 20);
            this.tbValor.TabIndex = 23;
            this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(471, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Valor";
            // 
            // tbPontos
            // 
            this.tbPontos.Enabled = false;
            this.tbPontos.Location = new System.Drawing.Point(255, 38);
            this.tbPontos.MaxLength = 5;
            this.tbPontos.Name = "tbPontos";
            this.tbPontos.Size = new System.Drawing.Size(52, 20);
            this.tbPontos.TabIndex = 18;
            this.tbPontos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbInfrator
            // 
            this.tbInfrator.Enabled = false;
            this.tbInfrator.Location = new System.Drawing.Point(68, 38);
            this.tbInfrator.MaxLength = 20;
            this.tbInfrator.Name = "tbInfrator";
            this.tbInfrator.Size = new System.Drawing.Size(181, 20);
            this.tbInfrator.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(252, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Pontos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(313, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Gravidade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(65, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Infrator";
            // 
            // cbMotoristas
            // 
            this.cbMotoristas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMotoristas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMotoristas.FormattingEnabled = true;
            this.cbMotoristas.Location = new System.Drawing.Point(325, 140);
            this.cbMotoristas.Name = "cbMotoristas";
            this.cbMotoristas.Size = new System.Drawing.Size(239, 21);
            this.cbMotoristas.TabIndex = 3;
            this.cbMotoristas.SelectedIndexChanged += new System.EventHandler(this.cbMotoristas_SelectedIndexChanged);
            this.cbMotoristas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMotoristas_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(322, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Motorista";
            // 
            // cbVeiculos
            // 
            this.cbVeiculos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbVeiculos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbVeiculos.FormattingEnabled = true;
            this.cbVeiculos.Location = new System.Drawing.Point(118, 141);
            this.cbVeiculos.Name = "cbVeiculos";
            this.cbVeiculos.Size = new System.Drawing.Size(201, 21);
            this.cbVeiculos.TabIndex = 2;
            this.cbVeiculos.SelectedIndexChanged += new System.EventHandler(this.cbVeiculos_SelectedIndexChanged);
            this.cbVeiculos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbVeiculos_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(115, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Veículo";
            // 
            // cbMultas
            // 
            this.cbMultas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMultas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMultas.FormattingEnabled = true;
            this.cbMultas.Location = new System.Drawing.Point(9, 31);
            this.cbMultas.Name = "cbMultas";
            this.cbMultas.Size = new System.Drawing.Size(555, 21);
            this.cbMultas.TabIndex = 0;
            this.cbMultas.SelectedIndexChanged += new System.EventHandler(this.cbMultas_SelectedIndexChanged);
            this.cbMultas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMultas_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Multa";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvUsos);
            this.groupBox2.Location = new System.Drawing.Point(9, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(555, 184);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usos dos Veículos";
            // 
            // gvUsos
            // 
            this.gvUsos.AllowUserToAddRows = false;
            this.gvUsos.AllowUserToDeleteRows = false;
            this.gvUsos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvUsos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvUsos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvUsos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMulta,
            this.Descricao,
            this.Column1,
            this.Column8,
            this.Column5,
            this.Column3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvUsos.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvUsos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvUsos.Location = new System.Drawing.Point(3, 16);
            this.gvUsos.Name = "gvUsos";
            this.gvUsos.ReadOnly = true;
            this.gvUsos.RowHeadersVisible = false;
            this.gvUsos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvUsos.Size = new System.Drawing.Size(549, 165);
            this.gvUsos.TabIndex = 0;
            // 
            // idMulta
            // 
            this.idMulta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idMulta.HeaderText = "idUso";
            this.idMulta.MinimumWidth = 2;
            this.idMulta.Name = "idMulta";
            this.idMulta.ReadOnly = true;
            this.idMulta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idMulta.Width = 2;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Descricao.HeaderText = "Veículo";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 69;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "Motorista";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 75;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column8.HeaderText = "Saída";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 61;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.HeaderText = "Chegada";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 75;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Observação";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // tbData
            // 
            this.tbData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbData.Location = new System.Drawing.Point(9, 141);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(103, 20);
            this.tbData.TabIndex = 1;
            this.tbData.ValueChanged += new System.EventHandler(this.tbData_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Multa";
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(3, 412);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 1;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(499, 412);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 2;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 360);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Número OP";
            // 
            // tbNumeroOP
            // 
            this.tbNumeroOP.Enabled = false;
            this.tbNumeroOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumeroOP.Location = new System.Drawing.Point(9, 376);
            this.tbNumeroOP.Name = "tbNumeroOP";
            this.tbNumeroOP.Size = new System.Drawing.Size(100, 20);
            this.tbNumeroOP.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(112, 360);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Status OP";
            // 
            // tbStatusOP
            // 
            this.tbStatusOP.Enabled = false;
            this.tbStatusOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStatusOP.Location = new System.Drawing.Point(115, 376);
            this.tbStatusOP.Name = "tbStatusOP";
            this.tbStatusOP.Size = new System.Drawing.Size(204, 20);
            this.tbStatusOP.TabIndex = 13;
            // 
            // MultaOcorrenciaManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 442);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultaOcorrenciaManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Ocorrências de Multas";
            this.Load += new System.EventHandler(this.MultaOcorrenciaManutencao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUsos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker tbData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.ComboBox cbMultas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMotoristas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbVeiculos;
        private System.Windows.Forms.Label label3;
        private Util.SortedDataGridView gvUsos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbGravidade;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPontos;
        private System.Windows.Forms.TextBox tbInfrator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbStatusOP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbNumeroOP;
        private System.Windows.Forms.Label label10;
    }
}