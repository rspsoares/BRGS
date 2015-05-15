namespace BRGS.UI
{
    partial class FreteManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreteManutencao));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbValorTotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPrevisaoPagto = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbTotalObras = new System.Windows.Forms.Label();
            this.tbData = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btRemoverObra = new System.Windows.Forms.Button();
            this.gvObras = new BRGS.Util.SortedDataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btAdicionarObra = new System.Windows.Forms.Button();
            this.cbDespesa = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbObra = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCentroCusto = new System.Windows.Forms.ComboBox();
            this.cbUEN = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTrajeto = new System.Windows.Forms.TextBox();
            this.cbFornecedores = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbDataVenc = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDespesaPagto = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbValorPagto = new System.Windows.Forms.TextBox();
            this.cbCentroCustoPagto = new System.Windows.Forms.ComboBox();
            this.cbUENPagto = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbSaldo = new System.Windows.Forms.Label();
            this.btGerarOP = new System.Windows.Forms.Button();
            this.gvPagamentos = new BRGS.Util.SortedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btGravar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvObras)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPagamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(669, 457);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(661, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados do Frete";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNumero);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tbValorTotal);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbPrevisaoPagto);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.tbTrajeto);
            this.groupBox1.Controls.Add(this.cbFornecedores);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 422);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tbNumero
            // 
            this.tbNumero.Enabled = false;
            this.tbNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumero.Location = new System.Drawing.Point(6, 32);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(76, 20);
            this.tbNumero.TabIndex = 32;
            this.tbNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Número";
            // 
            // tbValorTotal
            // 
            this.tbValorTotal.Location = new System.Drawing.Point(115, 110);
            this.tbValorTotal.MaxLength = 20;
            this.tbValorTotal.Name = "tbValorTotal";
            this.tbValorTotal.Size = new System.Drawing.Size(86, 20);
            this.tbValorTotal.TabIndex = 3;
            this.tbValorTotal.Text = "0,00";
            this.tbValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorTotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValorTotal_KeyDown);
            this.tbValorTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorTotal_KeyPress);
            this.tbValorTotal.Leave += new System.EventHandler(this.tbValorTotal_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(112, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Valor Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Previsão de Pagto";
            // 
            // tbPrevisaoPagto
            // 
            this.tbPrevisaoPagto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbPrevisaoPagto.Location = new System.Drawing.Point(6, 110);
            this.tbPrevisaoPagto.Name = "tbPrevisaoPagto";
            this.tbPrevisaoPagto.Size = new System.Drawing.Size(103, 20);
            this.tbPrevisaoPagto.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbTotalObras);
            this.groupBox3.Controls.Add(this.tbData);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btRemoverObra);
            this.groupBox3.Controls.Add(this.gvObras);
            this.groupBox3.Controls.Add(this.btAdicionarObra);
            this.groupBox3.Controls.Add(this.cbDespesa);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cbObra);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tbValor);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbCentroCusto);
            this.groupBox3.Controls.Add(this.cbUEN);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(6, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 281);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rateio entre Obras";
            // 
            // lbTotalObras
            // 
            this.lbTotalObras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalObras.Location = new System.Drawing.Point(269, 255);
            this.lbTotalObras.Name = "lbTotalObras";
            this.lbTotalObras.Size = new System.Drawing.Size(361, 16);
            this.lbTotalObras.TabIndex = 34;
            this.lbTotalObras.Text = "Total Rateio: R$ 0,00";
            this.lbTotalObras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbData
            // 
            this.tbData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbData.Location = new System.Drawing.Point(444, 112);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(105, 20);
            this.tbData.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(441, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Data";
            // 
            // btRemoverObra
            // 
            this.btRemoverObra.Location = new System.Drawing.Point(9, 252);
            this.btRemoverObra.Name = "btRemoverObra";
            this.btRemoverObra.Size = new System.Drawing.Size(75, 23);
            this.btRemoverObra.TabIndex = 8;
            this.btRemoverObra.Text = "Remover";
            this.btRemoverObra.UseVisualStyleBackColor = true;
            this.btRemoverObra.Click += new System.EventHandler(this.btRemoverObra_Click);
            // 
            // gvObras
            // 
            this.gvObras.AllowUserToAddRows = false;
            this.gvObras.AllowUserToDeleteRows = false;
            this.gvObras.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvObras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvObras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvObras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column8,
            this.Column7,
            this.Column5,
            this.Column6});
            this.gvObras.Location = new System.Drawing.Point(9, 139);
            this.gvObras.Name = "gvObras";
            this.gvObras.ReadOnly = true;
            this.gvObras.RowHeadersVisible = false;
            this.gvObras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvObras.Size = new System.Drawing.Size(621, 107);
            this.gvObras.TabIndex = 7;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "idObra";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Obra";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "idObraGastoRealizado";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column7.HeaderText = "Despesa";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 74;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.HeaderText = "Data";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 55;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column6.HeaderText = "Valor";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 56;
            // 
            // btAdicionarObra
            // 
            this.btAdicionarObra.Location = new System.Drawing.Point(555, 110);
            this.btAdicionarObra.Name = "btAdicionarObra";
            this.btAdicionarObra.Size = new System.Drawing.Size(75, 23);
            this.btAdicionarObra.TabIndex = 6;
            this.btAdicionarObra.Text = "Adicionar";
            this.btAdicionarObra.UseVisualStyleBackColor = true;
            this.btAdicionarObra.Click += new System.EventHandler(this.btAdicionarObra_Click);
            // 
            // cbDespesa
            // 
            this.cbDespesa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDespesa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDespesa.FormattingEnabled = true;
            this.cbDespesa.Location = new System.Drawing.Point(9, 112);
            this.cbDespesa.Name = "cbDespesa";
            this.cbDespesa.Size = new System.Drawing.Size(337, 21);
            this.cbDespesa.TabIndex = 3;
            this.cbDespesa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDespesa_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Despesa";
            // 
            // cbObra
            // 
            this.cbObra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbObra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbObra.FormattingEnabled = true;
            this.cbObra.Location = new System.Drawing.Point(9, 32);
            this.cbObra.Name = "cbObra";
            this.cbObra.Size = new System.Drawing.Size(621, 21);
            this.cbObra.TabIndex = 0;
            this.cbObra.SelectedIndexChanged += new System.EventHandler(this.cbObra_SelectedIndexChanged);
            this.cbObra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbObra_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Obra";
            // 
            // tbValor
            // 
            this.tbValor.Location = new System.Drawing.Point(352, 112);
            this.tbValor.MaxLength = 20;
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(86, 20);
            this.tbValor.TabIndex = 4;
            this.tbValor.Text = "0,00";
            this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValor_KeyDown);
            this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
            this.tbValor.Leave += new System.EventHandler(this.tbValor_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(349, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Valor";
            // 
            // cbCentroCusto
            // 
            this.cbCentroCusto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCentroCusto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCentroCusto.FormattingEnabled = true;
            this.cbCentroCusto.Location = new System.Drawing.Point(352, 72);
            this.cbCentroCusto.Name = "cbCentroCusto";
            this.cbCentroCusto.Size = new System.Drawing.Size(278, 21);
            this.cbCentroCusto.TabIndex = 2;
            this.cbCentroCusto.SelectedValueChanged += new System.EventHandler(this.cbCentroCusto_SelectedValueChanged);
            this.cbCentroCusto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCentroCusto_KeyDown);
            // 
            // cbUEN
            // 
            this.cbUEN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUEN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUEN.FormattingEnabled = true;
            this.cbUEN.Location = new System.Drawing.Point(9, 72);
            this.cbUEN.Name = "cbUEN";
            this.cbUEN.Size = new System.Drawing.Size(337, 21);
            this.cbUEN.TabIndex = 1;
            this.cbUEN.SelectedValueChanged += new System.EventHandler(this.cbUEN_SelectedValueChanged);
            this.cbUEN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbUEN_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(349, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Centro de Custo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "UEN";
            // 
            // tbTrajeto
            // 
            this.tbTrajeto.Location = new System.Drawing.Point(6, 71);
            this.tbTrajeto.MaxLength = 100;
            this.tbTrajeto.Name = "tbTrajeto";
            this.tbTrajeto.Size = new System.Drawing.Size(637, 20);
            this.tbTrajeto.TabIndex = 1;
            this.tbTrajeto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTrajeto_KeyDown);
            // 
            // cbFornecedores
            // 
            this.cbFornecedores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFornecedores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFornecedores.FormattingEnabled = true;
            this.cbFornecedores.Location = new System.Drawing.Point(88, 31);
            this.cbFornecedores.Name = "cbFornecedores";
            this.cbFornecedores.Size = new System.Drawing.Size(555, 21);
            this.cbFornecedores.TabIndex = 0;
            this.cbFornecedores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFornecedores_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Trajeto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fornecedor";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(661, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pagamentos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.tbDataVenc);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbDespesaPagto);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbValorPagto);
            this.groupBox2.Controls.Add(this.cbCentroCustoPagto);
            this.groupBox2.Controls.Add(this.cbUENPagto);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lbSaldo);
            this.groupBox2.Controls.Add(this.btGerarOP);
            this.groupBox2.Controls.Add(this.gvPagamentos);
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(652, 421);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(361, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "Valor";
            // 
            // tbDataVenc
            // 
            this.tbDataVenc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataVenc.Location = new System.Drawing.Point(460, 69);
            this.tbDataVenc.Name = "tbDataVenc";
            this.tbDataVenc.Size = new System.Drawing.Size(105, 20);
            this.tbDataVenc.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(457, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Data Vencimento";
            // 
            // cbDespesaPagto
            // 
            this.cbDespesaPagto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDespesaPagto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDespesaPagto.FormattingEnabled = true;
            this.cbDespesaPagto.Location = new System.Drawing.Point(6, 69);
            this.cbDespesaPagto.Name = "cbDespesaPagto";
            this.cbDespesaPagto.Size = new System.Drawing.Size(352, 21);
            this.cbDespesaPagto.TabIndex = 2;
            this.cbDespesaPagto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDespesaPagto_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Despesa";
            // 
            // tbValorPagto
            // 
            this.tbValorPagto.Location = new System.Drawing.Point(364, 69);
            this.tbValorPagto.MaxLength = 20;
            this.tbValorPagto.Name = "tbValorPagto";
            this.tbValorPagto.Size = new System.Drawing.Size(90, 20);
            this.tbValorPagto.TabIndex = 3;
            this.tbValorPagto.Text = "0,00";
            this.tbValorPagto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorPagto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValorPagto_KeyDown);
            this.tbValorPagto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorPagto_KeyPress);
            this.tbValorPagto.Leave += new System.EventHandler(this.tbValorPagto_Leave);
            // 
            // cbCentroCustoPagto
            // 
            this.cbCentroCustoPagto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCentroCustoPagto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCentroCustoPagto.FormattingEnabled = true;
            this.cbCentroCustoPagto.Location = new System.Drawing.Point(364, 29);
            this.cbCentroCustoPagto.Name = "cbCentroCustoPagto";
            this.cbCentroCustoPagto.Size = new System.Drawing.Size(282, 21);
            this.cbCentroCustoPagto.TabIndex = 1;
            this.cbCentroCustoPagto.SelectedValueChanged += new System.EventHandler(this.cbCentroCustoPagto_SelectedValueChanged);
            this.cbCentroCustoPagto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCentroCustoPagto_KeyDown);
            // 
            // cbUENPagto
            // 
            this.cbUENPagto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUENPagto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUENPagto.FormattingEnabled = true;
            this.cbUENPagto.Location = new System.Drawing.Point(6, 29);
            this.cbUENPagto.Name = "cbUENPagto";
            this.cbUENPagto.Size = new System.Drawing.Size(352, 21);
            this.cbUENPagto.TabIndex = 0;
            this.cbUENPagto.SelectedValueChanged += new System.EventHandler(this.cbUENPagto_SelectedValueChanged);
            this.cbUENPagto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbUENPagto_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(361, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Centro de Custo";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "UEN";
            // 
            // lbSaldo
            // 
            this.lbSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSaldo.Location = new System.Drawing.Point(361, 395);
            this.lbSaldo.Name = "lbSaldo";
            this.lbSaldo.Size = new System.Drawing.Size(285, 23);
            this.lbSaldo.TabIndex = 8;
            this.lbSaldo.Text = "Saldo: R$ 0,00";
            this.lbSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btGerarOP
            // 
            this.btGerarOP.Enabled = false;
            this.btGerarOP.Location = new System.Drawing.Point(571, 67);
            this.btGerarOP.Name = "btGerarOP";
            this.btGerarOP.Size = new System.Drawing.Size(75, 23);
            this.btGerarOP.TabIndex = 5;
            this.btGerarOP.Text = "Gerar OP";
            this.btGerarOP.UseVisualStyleBackColor = true;
            this.btGerarOP.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // gvPagamentos
            // 
            this.gvPagamentos.AllowUserToAddRows = false;
            this.gvPagamentos.AllowUserToDeleteRows = false;
            this.gvPagamentos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvPagamentos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPagamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column9});
            this.gvPagamentos.Location = new System.Drawing.Point(6, 95);
            this.gvPagamentos.Name = "gvPagamentos";
            this.gvPagamentos.ReadOnly = true;
            this.gvPagamentos.RowHeadersVisible = false;
            this.gvPagamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPagamentos.Size = new System.Drawing.Size(640, 297);
            this.gvPagamentos.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Número OP";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Status";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column9.HeaderText = "Valor";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 56;
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(595, 466);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 3;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(5, 466);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 4;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // FreteManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 496);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FreteManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Fretes";
            this.Load += new System.EventHandler(this.FreteManutencao_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvObras)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPagamentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbTrajeto;
        private System.Windows.Forms.ComboBox cbFornecedores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbSaldo;
        private System.Windows.Forms.Button btGerarOP;
        private Util.SortedDataGridView gvPagamentos;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbDespesa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbObra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCentroCusto;
        private System.Windows.Forms.ComboBox cbUEN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btRemoverObra;
        private Util.SortedDataGridView gvObras;
        private System.Windows.Forms.Button btAdicionarObra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker tbPrevisaoPagto;
        private System.Windows.Forms.DateTimePicker tbData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotalObras;
        private System.Windows.Forms.TextBox tbValorTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbNumero;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker tbDataVenc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDespesaPagto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbValorPagto;
        private System.Windows.Forms.ComboBox cbCentroCustoPagto;
        private System.Windows.Forms.ComboBox cbUENPagto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button btExcluir;

    }
}