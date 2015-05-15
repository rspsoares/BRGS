namespace BRGS.UI
{
    partial class VeiculoManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VeiculoManutencao));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDataVencimentoDPVAT = new System.Windows.Forms.DateTimePicker();
            this.tbdataVencimentoIPVA = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkPossuiSeguro = new System.Windows.Forms.CheckBox();
            this.tbDataVencimentoSeguro = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.tbSeguradora = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRenavam = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRastreador = new System.Windows.Forms.TextBox();
            this.tbCor = new System.Windows.Forms.TextBox();
            this.chkSemParar = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbChassi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbModelo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPlaca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvAbastecimentos = new BRGS.Util.SortedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gvManutencoes = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAbastecimentos)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvManutencoes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDataVencimentoDPVAT);
            this.groupBox1.Controls.Add(this.tbdataVencimentoIPVA);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.chkPossuiSeguro);
            this.groupBox1.Controls.Add(this.tbDataVencimentoSeguro);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbSeguradora);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbRenavam);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbRastreador);
            this.groupBox1.Controls.Add(this.tbCor);
            this.groupBox1.Controls.Add(this.chkSemParar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbChassi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbModelo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbAno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPlaca);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbDescricao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 241);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbDataVencimentoDPVAT
            // 
            this.tbDataVencimentoDPVAT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataVencimentoDPVAT.Location = new System.Drawing.Point(110, 215);
            this.tbDataVencimentoDPVAT.Name = "tbDataVencimentoDPVAT";
            this.tbDataVencimentoDPVAT.Size = new System.Drawing.Size(98, 20);
            this.tbDataVencimentoDPVAT.TabIndex = 23;
            // 
            // tbdataVencimentoIPVA
            // 
            this.tbdataVencimentoIPVA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbdataVencimentoIPVA.Location = new System.Drawing.Point(6, 215);
            this.tbdataVencimentoIPVA.Name = "tbdataVencimentoIPVA";
            this.tbdataVencimentoIPVA.Size = new System.Drawing.Size(98, 20);
            this.tbdataVencimentoIPVA.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(107, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Data Venc. DPVAT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Data Venc. IPVA";
            // 
            // chkPossuiSeguro
            // 
            this.chkPossuiSeguro.AutoSize = true;
            this.chkPossuiSeguro.Location = new System.Drawing.Point(6, 136);
            this.chkPossuiSeguro.Name = "chkPossuiSeguro";
            this.chkPossuiSeguro.Size = new System.Drawing.Size(98, 17);
            this.chkPossuiSeguro.TabIndex = 9;
            this.chkPossuiSeguro.Text = "Possui seguro?";
            this.chkPossuiSeguro.UseVisualStyleBackColor = true;
            this.chkPossuiSeguro.CheckedChanged += new System.EventHandler(this.chkPossuiSeguro_CheckedChanged);
            // 
            // tbDataVencimentoSeguro
            // 
            this.tbDataVencimentoSeguro.Enabled = false;
            this.tbDataVencimentoSeguro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataVencimentoSeguro.Location = new System.Drawing.Point(188, 172);
            this.tbDataVencimentoSeguro.Name = "tbDataVencimentoSeguro";
            this.tbDataVencimentoSeguro.Size = new System.Drawing.Size(101, 20);
            this.tbDataVencimentoSeguro.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(185, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Data Vencimento";
            // 
            // tbSeguradora
            // 
            this.tbSeguradora.Enabled = false;
            this.tbSeguradora.Location = new System.Drawing.Point(30, 172);
            this.tbSeguradora.MaxLength = 50;
            this.tbSeguradora.Name = "tbSeguradora";
            this.tbSeguradora.Size = new System.Drawing.Size(152, 20);
            this.tbSeguradora.TabIndex = 10;
            this.tbSeguradora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSeguradora_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Seguradora";
            // 
            // tbRenavam
            // 
            this.tbRenavam.Location = new System.Drawing.Point(158, 71);
            this.tbRenavam.MaxLength = 20;
            this.tbRenavam.Name = "tbRenavam";
            this.tbRenavam.Size = new System.Drawing.Size(119, 20);
            this.tbRenavam.TabIndex = 5;
            this.tbRenavam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRenavam_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Renavam";
            // 
            // tbRastreador
            // 
            this.tbRastreador.Location = new System.Drawing.Point(6, 110);
            this.tbRastreador.MaxLength = 30;
            this.tbRastreador.Name = "tbRastreador";
            this.tbRastreador.Size = new System.Drawing.Size(151, 20);
            this.tbRastreador.TabIndex = 7;
            this.tbRastreador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRastreador_KeyDown);
            // 
            // tbCor
            // 
            this.tbCor.Location = new System.Drawing.Point(338, 32);
            this.tbCor.MaxLength = 30;
            this.tbCor.Name = "tbCor";
            this.tbCor.Size = new System.Drawing.Size(102, 20);
            this.tbCor.TabIndex = 2;
            this.tbCor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCor_KeyDown);
            // 
            // chkSemParar
            // 
            this.chkSemParar.AutoSize = true;
            this.chkSemParar.Location = new System.Drawing.Point(163, 112);
            this.chkSemParar.Name = "chkSemParar";
            this.chkSemParar.Size = new System.Drawing.Size(75, 17);
            this.chkSemParar.TabIndex = 8;
            this.chkSemParar.Text = "Sem Parar";
            this.chkSemParar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Rastreador";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cor";
            // 
            // tbChassi
            // 
            this.tbChassi.Location = new System.Drawing.Point(283, 71);
            this.tbChassi.MaxLength = 30;
            this.tbChassi.Name = "tbChassi";
            this.tbChassi.Size = new System.Drawing.Size(157, 20);
            this.tbChassi.TabIndex = 6;
            this.tbChassi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbChassi_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Chassi";
            // 
            // tbModelo
            // 
            this.tbModelo.Location = new System.Drawing.Point(82, 71);
            this.tbModelo.MaxLength = 6;
            this.tbModelo.Name = "tbModelo";
            this.tbModelo.Size = new System.Drawing.Size(70, 20);
            this.tbModelo.TabIndex = 4;
            this.tbModelo.Text = "0";
            this.tbModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbModelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbModelo_KeyDown);
            this.tbModelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbModelo_KeyPress);
            this.tbModelo.Leave += new System.EventHandler(this.tbModelo_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Modelo";
            // 
            // tbAno
            // 
            this.tbAno.Location = new System.Drawing.Point(6, 71);
            this.tbAno.MaxLength = 6;
            this.tbAno.Name = "tbAno";
            this.tbAno.Size = new System.Drawing.Size(70, 20);
            this.tbAno.TabIndex = 3;
            this.tbAno.Text = "0";
            this.tbAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbAno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAno_KeyDown);
            this.tbAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAno_KeyPress);
            this.tbAno.Leave += new System.EventHandler(this.tbAno_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ano";
            // 
            // tbPlaca
            // 
            this.tbPlaca.Location = new System.Drawing.Point(253, 32);
            this.tbPlaca.MaxLength = 10;
            this.tbPlaca.Name = "tbPlaca";
            this.tbPlaca.Size = new System.Drawing.Size(79, 20);
            this.tbPlaca.TabIndex = 1;
            this.tbPlaca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPlaca_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Placa";
            // 
            // tbDescricao
            // 
            this.tbDescricao.Location = new System.Drawing.Point(6, 32);
            this.tbDescricao.MaxLength = 50;
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(241, 20);
            this.tbDescricao.TabIndex = 0;
            this.tbDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDescricao_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Veículo";
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(393, 285);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 1;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(2, 285);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 2;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(466, 278);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(458, 252);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados do veículo";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(458, 252);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Abastecimentos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvAbastecimentos);
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 243);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // gvAbastecimentos
            // 
            this.gvAbastecimentos.AllowUserToAddRows = false;
            this.gvAbastecimentos.AllowUserToDeleteRows = false;
            this.gvAbastecimentos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvAbastecimentos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvAbastecimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAbastecimentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4});
            this.gvAbastecimentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAbastecimentos.Location = new System.Drawing.Point(3, 16);
            this.gvAbastecimentos.Name = "gvAbastecimentos";
            this.gvAbastecimentos.ReadOnly = true;
            this.gvAbastecimentos.RowHeadersVisible = false;
            this.gvAbastecimentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAbastecimentos.Size = new System.Drawing.Size(440, 224);
            this.gvAbastecimentos.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "Data";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 55;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Motorista";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.HeaderText = "Valor";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 56;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(458, 252);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Manutenções";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gvManutencoes);
            this.groupBox3.Location = new System.Drawing.Point(6, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 243);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // gvManutencoes
            // 
            this.gvManutencoes.AllowUserToAddRows = false;
            this.gvManutencoes.AllowUserToDeleteRows = false;
            this.gvManutencoes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvManutencoes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvManutencoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvManutencoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.gvManutencoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvManutencoes.Location = new System.Drawing.Point(3, 16);
            this.gvManutencoes.Name = "gvManutencoes";
            this.gvManutencoes.ReadOnly = true;
            this.gvManutencoes.RowHeadersVisible = false;
            this.gvManutencoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvManutencoes.Size = new System.Drawing.Size(440, 224);
            this.gvManutencoes.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Data";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 55;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 56;
            // 
            // VeiculoManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 316);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VeiculoManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Veículos";
            this.Load += new System.EventHandler(this.VeiculoManutencao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvAbastecimentos)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvManutencoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.TextBox tbPlaca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSemParar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbChassi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbModelo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker tbDataVencimentoSeguro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbSeguradora;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRenavam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRastreador;
        private System.Windows.Forms.TextBox tbCor;
        private System.Windows.Forms.CheckBox chkPossuiSeguro;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Util.SortedDataGridView gvAbastecimentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DateTimePicker tbDataVencimentoDPVAT;
        private System.Windows.Forms.DateTimePicker tbdataVencimentoIPVA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private Util.SortedDataGridView gvManutencoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}