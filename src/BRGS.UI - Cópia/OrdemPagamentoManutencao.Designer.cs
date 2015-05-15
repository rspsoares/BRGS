namespace BRGS.UI
{
    partial class OrdemPagamentoManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdemPagamentoManutencao));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btExcluir = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDadosBancarios = new System.Windows.Forms.ComboBox();
            this.tbDataCriacao = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.tbNumeroOP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbObservacaoCancelada = new System.Windows.Forms.TextBox();
            this.chkCancelada = new System.Windows.Forms.CheckBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDataSolicitacao = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbObservacao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSolicitante = new System.Windows.Forms.TextBox();
            this.cbFavorecido = new System.Windows.Forms.ComboBox();
            this.cbObra = new System.Windows.Forms.ComboBox();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btPagamento = new System.Windows.Forms.Button();
            this.btRemover = new System.Windows.Forms.Button();
            this.lbTotal = new System.Windows.Forms.Label();
            this.chkGerarParcelamento = new System.Windows.Forms.CheckBox();
            this.tbDataVencimento = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.gvItens = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cbDespesa = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbCentroCusto = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cbUEN = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.cbAutorizado = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvItens)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btExcluir);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.btGravar);
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 486);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(6, 458);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 11;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(815, 443);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(807, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados principais";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAutorizado);
            this.groupBox2.Controls.Add(this.cbDadosBancarios);
            this.groupBox2.Controls.Add(this.tbDataCriacao);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbNumeroOP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbObservacaoCancelada);
            this.groupBox2.Controls.Add(this.chkCancelada);
            this.groupBox2.Controls.Add(this.lbStatus);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dtpDataSolicitacao);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbObservacao);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbSolicitante);
            this.groupBox2.Controls.Add(this.cbFavorecido);
            this.groupBox2.Controls.Add(this.cbObra);
            this.groupBox2.Controls.Add(this.cbEmpresa);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(795, 412);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cbDadosBancarios
            // 
            this.cbDadosBancarios.FormattingEnabled = true;
            this.cbDadosBancarios.Location = new System.Drawing.Point(384, 112);
            this.cbDadosBancarios.Name = "cbDadosBancarios";
            this.cbDadosBancarios.Size = new System.Drawing.Size(405, 21);
            this.cbDadosBancarios.TabIndex = 5;
            this.cbDadosBancarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbDadosBancarios_KeyPress);
            // 
            // tbDataCriacao
            // 
            this.tbDataCriacao.Enabled = false;
            this.tbDataCriacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDataCriacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataCriacao.Location = new System.Drawing.Point(95, 32);
            this.tbDataCriacao.Name = "tbDataCriacao";
            this.tbDataCriacao.Size = new System.Drawing.Size(106, 20);
            this.tbDataCriacao.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(92, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "Data Criação";
            // 
            // tbNumeroOP
            // 
            this.tbNumeroOP.Enabled = false;
            this.tbNumeroOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumeroOP.Location = new System.Drawing.Point(6, 32);
            this.tbNumeroOP.Name = "tbNumeroOP";
            this.tbNumeroOP.Size = new System.Drawing.Size(83, 20);
            this.tbNumeroOP.TabIndex = 0;
            this.tbNumeroOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Número OP";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 306);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "Motivo Cancelamento";
            // 
            // tbObservacaoCancelada
            // 
            this.tbObservacaoCancelada.Enabled = false;
            this.tbObservacaoCancelada.Location = new System.Drawing.Point(25, 322);
            this.tbObservacaoCancelada.MaxLength = 250;
            this.tbObservacaoCancelada.Multiline = true;
            this.tbObservacaoCancelada.Name = "tbObservacaoCancelada";
            this.tbObservacaoCancelada.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservacaoCancelada.Size = new System.Drawing.Size(764, 51);
            this.tbObservacaoCancelada.TabIndex = 10;
            // 
            // chkCancelada
            // 
            this.chkCancelada.AutoSize = true;
            this.chkCancelada.Location = new System.Drawing.Point(6, 286);
            this.chkCancelada.Name = "chkCancelada";
            this.chkCancelada.Size = new System.Drawing.Size(77, 17);
            this.chkCancelada.TabIndex = 45;
            this.chkCancelada.Text = "Cancelada";
            this.chkCancelada.UseVisualStyleBackColor = true;
            this.chkCancelada.Click += new System.EventHandler(this.chkCancelada_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(6, 389);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(23, 13);
            this.lbStatus.TabIndex = 42;
            this.lbStatus.Text = "    ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Status";
            // 
            // dtpDataSolicitacao
            // 
            this.dtpDataSolicitacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataSolicitacao.Location = new System.Drawing.Point(6, 152);
            this.dtpDataSolicitacao.Name = "dtpDataSolicitacao";
            this.dtpDataSolicitacao.Size = new System.Drawing.Size(98, 20);
            this.dtpDataSolicitacao.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Data Solicitação";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Autorizado por";
            // 
            // tbObservacao
            // 
            this.tbObservacao.Location = new System.Drawing.Point(6, 230);
            this.tbObservacao.MaxLength = 250;
            this.tbObservacao.Multiline = true;
            this.tbObservacao.Name = "tbObservacao";
            this.tbObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservacao.Size = new System.Drawing.Size(783, 50);
            this.tbObservacao.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Observação";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(381, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Conta bancária";
            // 
            // tbSolicitante
            // 
            this.tbSolicitante.Enabled = false;
            this.tbSolicitante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSolicitante.Location = new System.Drawing.Point(109, 152);
            this.tbSolicitante.MaxLength = 50;
            this.tbSolicitante.Name = "tbSolicitante";
            this.tbSolicitante.Size = new System.Drawing.Size(681, 20);
            this.tbSolicitante.TabIndex = 7;
            // 
            // cbFavorecido
            // 
            this.cbFavorecido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFavorecido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFavorecido.FormattingEnabled = true;
            this.cbFavorecido.Location = new System.Drawing.Point(6, 112);
            this.cbFavorecido.Name = "cbFavorecido";
            this.cbFavorecido.Size = new System.Drawing.Size(371, 21);
            this.cbFavorecido.TabIndex = 4;
            this.cbFavorecido.SelectedIndexChanged += new System.EventHandler(this.cbFavorecido_SelectedIndexChanged);
            this.cbFavorecido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFavorecido_KeyDown);
            // 
            // cbObra
            // 
            this.cbObra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbObra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbObra.FormattingEnabled = true;
            this.cbObra.Location = new System.Drawing.Point(384, 72);
            this.cbObra.Name = "cbObra";
            this.cbObra.Size = new System.Drawing.Size(405, 21);
            this.cbObra.TabIndex = 3;
            this.cbObra.SelectedIndexChanged += new System.EventHandler(this.cbObra_SelectedIndexChanged);
            this.cbObra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbObra_KeyDown);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(6, 72);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(372, 21);
            this.cbEmpresa.TabIndex = 2;
            this.cbEmpresa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEmpresa_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Solicitante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Favorecido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(380, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Etapa Obra";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Empresa";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(807, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Itens da O.P.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Controls.Add(this.chkGerarParcelamento);
            this.groupBox4.Controls.Add(this.tbDataVencimento);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.gvItens);
            this.groupBox4.Controls.Add(this.btAdicionar);
            this.groupBox4.Controls.Add(this.tbValor);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.cbDespesa);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.cbCentroCusto);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.cbUEN);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Location = new System.Drawing.Point(6, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(795, 408);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.Controls.Add(this.btPagamento, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btRemover, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbTotal, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 372);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(783, 30);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // btPagamento
            // 
            this.btPagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPagamento.Location = new System.Drawing.Point(352, 3);
            this.btPagamento.Name = "btPagamento";
            this.btPagamento.Size = new System.Drawing.Size(75, 23);
            this.btPagamento.TabIndex = 32;
            this.btPagamento.Text = "Pagamento";
            this.btPagamento.UseVisualStyleBackColor = true;
            this.btPagamento.Click += new System.EventHandler(this.btPagamento_Click);
            // 
            // btRemover
            // 
            this.btRemover.Location = new System.Drawing.Point(3, 3);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(75, 23);
            this.btRemover.TabIndex = 24;
            this.btRemover.Text = "Remover";
            this.btRemover.UseVisualStyleBackColor = true;
            this.btRemover.Click += new System.EventHandler(this.btRemover_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.Black;
            this.lbTotal.Location = new System.Drawing.Point(580, 3);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(200, 23);
            this.lbTotal.TabIndex = 33;
            this.lbTotal.Text = "Total: R$ 0,00";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkGerarParcelamento
            // 
            this.chkGerarParcelamento.AutoSize = true;
            this.chkGerarParcelamento.Location = new System.Drawing.Point(211, 154);
            this.chkGerarParcelamento.Name = "chkGerarParcelamento";
            this.chkGerarParcelamento.Size = new System.Drawing.Size(120, 17);
            this.chkGerarParcelamento.TabIndex = 5;
            this.chkGerarParcelamento.Text = "Gerar Parcelamento";
            this.chkGerarParcelamento.UseVisualStyleBackColor = true;
            // 
            // tbDataVencimento
            // 
            this.tbDataVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataVencimento.Location = new System.Drawing.Point(6, 152);
            this.tbDataVencimento.Name = "tbDataVencimento";
            this.tbDataVencimento.Size = new System.Drawing.Size(113, 20);
            this.tbDataVencimento.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Data Venc.";
            // 
            // gvItens
            // 
            this.gvItens.AllowUserToAddRows = false;
            this.gvItens.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvItens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column1,
            this.Column3,
            this.Column8,
            this.Column4,
            this.Column2,
            this.Column5,
            this.Column7,
            this.Column6,
            this.Column9,
            this.Column10});
            this.gvItens.Location = new System.Drawing.Point(5, 179);
            this.gvItens.MultiSelect = false;
            this.gvItens.Name = "gvItens";
            this.gvItens.ReadOnly = true;
            this.gvItens.RowHeadersVisible = false;
            this.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvItens.Size = new System.Drawing.Size(784, 187);
            this.gvItens.TabIndex = 22;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "idUEN";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "idCentroCusto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "idDespesa";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "UEN";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "C. Custo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "Despesa";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "idObraGastoRealizado";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "Data Venc";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 83;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column8.HeaderText = "Valor";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 56;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.HeaderText = "Data Pagto";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 86;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "Valor Pago";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 84;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "idOrdemPagamentoItem";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "idUsuarioPagamento";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column6.HeaderText = "Pago por";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 75;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Multa";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Desconto";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // btAdicionar
            // 
            this.btAdicionar.Location = new System.Drawing.Point(713, 150);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(76, 23);
            this.btAdicionar.TabIndex = 6;
            this.btAdicionar.Text = "Adicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // tbValor
            // 
            this.tbValor.Location = new System.Drawing.Point(125, 152);
            this.tbValor.MaxLength = 10;
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(80, 20);
            this.tbValor.TabIndex = 4;
            this.tbValor.Text = "0,00";
            this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValor_KeyDown);
            this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
            this.tbValor.Leave += new System.EventHandler(this.tbValor_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(122, 136);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 13);
            this.label23.TabIndex = 19;
            this.label23.Text = "Valor (R$)";
            // 
            // cbDespesa
            // 
            this.cbDespesa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDespesa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDespesa.FormattingEnabled = true;
            this.cbDespesa.Location = new System.Drawing.Point(5, 112);
            this.cbDespesa.Name = "cbDespesa";
            this.cbDespesa.Size = new System.Drawing.Size(784, 21);
            this.cbDespesa.TabIndex = 2;
            this.cbDespesa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDespesa_KeyDown);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(5, 96);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 13);
            this.label24.TabIndex = 17;
            this.label24.Text = "Despesa";
            // 
            // cbCentroCusto
            // 
            this.cbCentroCusto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCentroCusto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCentroCusto.FormattingEnabled = true;
            this.cbCentroCusto.Location = new System.Drawing.Point(5, 72);
            this.cbCentroCusto.Name = "cbCentroCusto";
            this.cbCentroCusto.Size = new System.Drawing.Size(784, 21);
            this.cbCentroCusto.TabIndex = 1;
            this.cbCentroCusto.SelectedIndexChanged += new System.EventHandler(this.cbCentroCusto_SelectedIndexChanged);
            this.cbCentroCusto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCentroCusto_KeyDown);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(3, 56);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 13);
            this.label25.TabIndex = 15;
            this.label25.Text = "Centro Custo";
            // 
            // cbUEN
            // 
            this.cbUEN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUEN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUEN.FormattingEnabled = true;
            this.cbUEN.Location = new System.Drawing.Point(6, 32);
            this.cbUEN.Name = "cbUEN";
            this.cbUEN.Size = new System.Drawing.Size(783, 21);
            this.cbUEN.TabIndex = 0;
            this.cbUEN.SelectedIndexChanged += new System.EventHandler(this.cbUEN_SelectedIndexChanged);
            this.cbUEN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbUEN_KeyDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(2, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(191, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "Unidade Estratégica de Negócio";
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(746, 458);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 10;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // cbAutorizado
            // 
            this.cbAutorizado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAutorizado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAutorizado.FormattingEnabled = true;
            this.cbAutorizado.Location = new System.Drawing.Point(6, 191);
            this.cbAutorizado.Name = "cbAutorizado";
            this.cbAutorizado.Size = new System.Drawing.Size(783, 21);
            this.cbAutorizado.TabIndex = 8;
            this.cbAutorizado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAutorizado_KeyDown);
            // 
            // OrdemPagamentoManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 494);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrdemPagamentoManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Ordens de Pagamentos";
            this.Load += new System.EventHandler(this.OrdemPagamentoManutencao_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvItens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbObservacao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSolicitante;
        private System.Windows.Forms.ComboBox cbFavorecido;
        private System.Windows.Forms.ComboBox cbObra;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private Util.SortedDataGridView gvItens;
        private System.Windows.Forms.Button btAdicionar;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbDespesa;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbCentroCusto;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbUEN;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DateTimePicker dtpDataSolicitacao;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.CheckBox chkCancelada;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbObservacaoCancelada;
        private System.Windows.Forms.DateTimePicker tbDataVencimento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkGerarParcelamento;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Button btPagamento;
        private System.Windows.Forms.Button btRemover;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DateTimePicker tbDataCriacao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbNumeroOP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDadosBancarios;
        private System.Windows.Forms.ComboBox cbAutorizado;
    }
}