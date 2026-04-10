namespace BRGS.UI
{
    partial class GeradorManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeradorManutencao));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbAcessorios = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDataCompra = new System.Windows.Forms.DateTimePicker();
            this.tbNotaFiscal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLicitacao = new System.Windows.Forms.ComboBox();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.tbLotado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbModelo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.tbCombustivel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMarca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumeroSerie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbManutencaoData = new System.Windows.Forms.DateTimePicker();
            this.tbManutencaoValor = new System.Windows.Forms.TextBox();
            this.lbIdContaBancaria = new System.Windows.Forms.Label();
            this.btManutencaoRemover = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.gvManutencoes = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btManutencaoAdd = new System.Windows.Forms.Button();
            this.tbManutencaoDescricao = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btGravar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvManutencoes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 351);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(645, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados cadastrais";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbAcessorios);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpDataCompra);
            this.groupBox1.Controls.Add(this.tbNotaFiscal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbLicitacao);
            this.groupBox1.Controls.Add(this.cbClientes);
            this.groupBox1.Controls.Add(this.tbLotado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbModelo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbEmpresa);
            this.groupBox1.Controls.Add(this.tbCombustivel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbMarca);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbNumeroSerie);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 313);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Acessórios";
            // 
            // tbAcessorios
            // 
            this.tbAcessorios.Location = new System.Drawing.Point(6, 229);
            this.tbAcessorios.Multiline = true;
            this.tbAcessorios.Name = "tbAcessorios";
            this.tbAcessorios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAcessorios.Size = new System.Drawing.Size(621, 73);
            this.tbAcessorios.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(525, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Data Compra";
            // 
            // dtpDataCompra
            // 
            this.dtpDataCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataCompra.Location = new System.Drawing.Point(528, 190);
            this.dtpDataCompra.Name = "dtpDataCompra";
            this.dtpDataCompra.Size = new System.Drawing.Size(99, 20);
            this.dtpDataCompra.TabIndex = 11;
            // 
            // tbNotaFiscal
            // 
            this.tbNotaFiscal.Location = new System.Drawing.Point(433, 190);
            this.tbNotaFiscal.Name = "tbNotaFiscal";
            this.tbNotaFiscal.Size = new System.Drawing.Size(89, 20);
            this.tbNotaFiscal.TabIndex = 10;
            this.tbNotaFiscal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNotaFiscal_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Nota Fiscal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Pregão";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Cliente";
            // 
            // cbLicitacao
            // 
            this.cbLicitacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLicitacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLicitacao.FormattingEnabled = true;
            this.cbLicitacao.Location = new System.Drawing.Point(6, 150);
            this.cbLicitacao.Name = "cbLicitacao";
            this.cbLicitacao.Size = new System.Drawing.Size(421, 21);
            this.cbLicitacao.TabIndex = 7;
            this.cbLicitacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLicitacao_KeyDown);
            // 
            // cbClientes
            // 
            this.cbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(6, 110);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(621, 21);
            this.cbClientes.TabIndex = 6;
            this.cbClientes.SelectedIndexChanged += new System.EventHandler(this.cbClientes_SelectedIndexChanged);
            this.cbClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbClientes_KeyDown);
            // 
            // tbLotado
            // 
            this.tbLotado.Location = new System.Drawing.Point(433, 151);
            this.tbLotado.Name = "tbLotado";
            this.tbLotado.Size = new System.Drawing.Size(194, 20);
            this.tbLotado.TabIndex = 8;
            this.tbLotado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLotado_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(430, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Lotado";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 173);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Empresa";
            // 
            // tbModelo
            // 
            this.tbModelo.Location = new System.Drawing.Point(405, 32);
            this.tbModelo.MaxLength = 30;
            this.tbModelo.Name = "tbModelo";
            this.tbModelo.Size = new System.Drawing.Size(222, 20);
            this.tbModelo.TabIndex = 2;
            this.tbModelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbModelo_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(402, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Modelo";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(6, 189);
            this.cbEmpresa.MaxLength = 2;
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(421, 21);
            this.cbEmpresa.TabIndex = 9;
            this.cbEmpresa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEmpresa_KeyDown);
            // 
            // tbCombustivel
            // 
            this.tbCombustivel.Location = new System.Drawing.Point(6, 71);
            this.tbCombustivel.MaxLength = 30;
            this.tbCombustivel.Name = "tbCombustivel";
            this.tbCombustivel.Size = new System.Drawing.Size(194, 20);
            this.tbCombustivel.TabIndex = 3;
            this.tbCombustivel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCombustivel_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Combustível";
            // 
            // tbMarca
            // 
            this.tbMarca.Location = new System.Drawing.Point(206, 32);
            this.tbMarca.MaxLength = 30;
            this.tbMarca.Name = "tbMarca";
            this.tbMarca.Size = new System.Drawing.Size(193, 20);
            this.tbMarca.TabIndex = 1;
            this.tbMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMarca_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Marca";
            // 
            // tbNumeroSerie
            // 
            this.tbNumeroSerie.Location = new System.Drawing.Point(6, 32);
            this.tbNumeroSerie.MaxLength = 30;
            this.tbNumeroSerie.Name = "tbNumeroSerie";
            this.tbNumeroSerie.Size = new System.Drawing.Size(194, 20);
            this.tbNumeroSerie.TabIndex = 0;
            this.tbNumeroSerie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNumeroSerie_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número Série";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(645, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manutenções";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbManutencaoData);
            this.groupBox6.Controls.Add(this.tbManutencaoValor);
            this.groupBox6.Controls.Add(this.lbIdContaBancaria);
            this.groupBox6.Controls.Add(this.btManutencaoRemover);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.btManutencaoAdd);
            this.groupBox6.Controls.Add(this.tbManutencaoDescricao);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(629, 313);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
            // 
            // tbManutencaoData
            // 
            this.tbManutencaoData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbManutencaoData.Location = new System.Drawing.Point(6, 33);
            this.tbManutencaoData.Name = "tbManutencaoData";
            this.tbManutencaoData.Size = new System.Drawing.Size(114, 20);
            this.tbManutencaoData.TabIndex = 0;
            // 
            // tbManutencaoValor
            // 
            this.tbManutencaoValor.Location = new System.Drawing.Point(126, 33);
            this.tbManutencaoValor.Name = "tbManutencaoValor";
            this.tbManutencaoValor.Size = new System.Drawing.Size(86, 20);
            this.tbManutencaoValor.TabIndex = 1;
            this.tbManutencaoValor.Text = "0,00";
            this.tbManutencaoValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbManutencaoValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbManutencaoValor_KeyDown);
            this.tbManutencaoValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbManutencaoValor_KeyPress);
            this.tbManutencaoValor.Leave += new System.EventHandler(this.tbManutencaoValor_Leave);
            // 
            // lbIdContaBancaria
            // 
            this.lbIdContaBancaria.AutoSize = true;
            this.lbIdContaBancaria.Location = new System.Drawing.Point(102, 16);
            this.lbIdContaBancaria.Name = "lbIdContaBancaria";
            this.lbIdContaBancaria.Size = new System.Drawing.Size(13, 13);
            this.lbIdContaBancaria.TabIndex = 63;
            this.lbIdContaBancaria.Text = "0";
            this.lbIdContaBancaria.Visible = false;
            // 
            // btManutencaoRemover
            // 
            this.btManutencaoRemover.Location = new System.Drawing.Point(9, 284);
            this.btManutencaoRemover.Name = "btManutencaoRemover";
            this.btManutencaoRemover.Size = new System.Drawing.Size(75, 23);
            this.btManutencaoRemover.TabIndex = 5;
            this.btManutencaoRemover.Text = "Remover";
            this.btManutencaoRemover.UseVisualStyleBackColor = true;
            this.btManutencaoRemover.Click += new System.EventHandler(this.btManutencaoRemover_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.gvManutencoes);
            this.groupBox8.Location = new System.Drawing.Point(6, 59);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(613, 219);
            this.groupBox8.TabIndex = 60;
            this.groupBox8.TabStop = false;
            // 
            // gvManutencoes
            // 
            this.gvManutencoes.AllowUserToAddRows = false;
            this.gvManutencoes.AllowUserToDeleteRows = false;
            this.gvManutencoes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvManutencoes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvManutencoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvManutencoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.gvManutencoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvManutencoes.Location = new System.Drawing.Point(3, 16);
            this.gvManutencoes.MultiSelect = false;
            this.gvManutencoes.Name = "gvManutencoes";
            this.gvManutencoes.ReadOnly = true;
            this.gvManutencoes.RowHeadersVisible = false;
            this.gvManutencoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvManutencoes.Size = new System.Drawing.Size(607, 200);
            this.gvManutencoes.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "idManutencao";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Data";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 55;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 56;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Descricao";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // btManutencaoAdd
            // 
            this.btManutencaoAdd.Location = new System.Drawing.Point(544, 31);
            this.btManutencaoAdd.Name = "btManutencaoAdd";
            this.btManutencaoAdd.Size = new System.Drawing.Size(75, 23);
            this.btManutencaoAdd.TabIndex = 3;
            this.btManutencaoAdd.Text = "Adicionar";
            this.btManutencaoAdd.UseVisualStyleBackColor = true;
            this.btManutencaoAdd.Click += new System.EventHandler(this.btManutencaoAdd_Click);
            // 
            // tbManutencaoDescricao
            // 
            this.tbManutencaoDescricao.Location = new System.Drawing.Point(218, 33);
            this.tbManutencaoDescricao.MaxLength = 100;
            this.tbManutencaoDescricao.Name = "tbManutencaoDescricao";
            this.tbManutencaoDescricao.Size = new System.Drawing.Size(320, 20);
            this.tbManutencaoDescricao.TabIndex = 2;
            this.tbManutencaoDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbManutencaoDescricao_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(215, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Descrição";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(123, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(36, 13);
            this.label33.TabIndex = 56;
            this.label33.Text = "Valor";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(3, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(34, 13);
            this.label34.TabIndex = 55;
            this.label34.Text = "Data";
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(7, 359);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 7;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(581, 359);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 6;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // GeradorManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 387);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeradorManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenção de Geradores";
            this.Load += new System.EventHandler(this.GeradorManutencao_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvManutencoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbAcessorios;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDataCompra;
        private System.Windows.Forms.TextBox tbNotaFiscal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLicitacao;
        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.TextBox tbLotado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbModelo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.TextBox tbCombustivel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumeroSerie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker tbManutencaoData;
        private System.Windows.Forms.TextBox tbManutencaoValor;
        private System.Windows.Forms.Label lbIdContaBancaria;
        private System.Windows.Forms.Button btManutencaoRemover;
        private System.Windows.Forms.GroupBox groupBox8;
        private Util.SortedDataGridView gvManutencoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btManutencaoAdd;
        private System.Windows.Forms.TextBox tbManutencaoDescricao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btGravar;
    }
}