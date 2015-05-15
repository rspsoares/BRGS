namespace BRGS.UI
{
    partial class EmpresaManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpresaManutencao));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbInscricaoEstadual = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbICM = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCNPJ = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEndereco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAtividade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNomeFantasia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRazaoSocial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbIdContaBancaria = new System.Windows.Forms.Label();
            this.btContaNova = new System.Windows.Forms.Button();
            this.btContaRemover = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.gvContasBancarias = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btContaAdd = new System.Windows.Forms.Button();
            this.tbConta = new System.Windows.Forms.TextBox();
            this.cbTipoConta = new System.Windows.Forms.ComboBox();
            this.tbAgencia = new System.Windows.Forms.TextBox();
            this.tbBanco = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvContasBancarias)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbInscricaoEstadual);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbICM);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbCNPJ);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbEstado);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbCidade);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbEndereco);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbAtividade);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNomeFantasia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbRazaoSocial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbInscricaoEstadual
            // 
            this.tbInscricaoEstadual.Location = new System.Drawing.Point(568, 153);
            this.tbInscricaoEstadual.MaxLength = 20;
            this.tbInscricaoEstadual.Name = "tbInscricaoEstadual";
            this.tbInscricaoEstadual.Size = new System.Drawing.Size(141, 20);
            this.tbInscricaoEstadual.TabIndex = 8;
            this.tbInscricaoEstadual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInscricaoEstadual_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(565, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Inscrição Estadual";
            // 
            // tbICM
            // 
            this.tbICM.Location = new System.Drawing.Point(447, 153);
            this.tbICM.MaxLength = 10;
            this.tbICM.Name = "tbICM";
            this.tbICM.Size = new System.Drawing.Size(115, 20);
            this.tbICM.TabIndex = 7;
            this.tbICM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbICM_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "ICM";
            // 
            // tbCNPJ
            // 
            this.tbCNPJ.Location = new System.Drawing.Point(313, 152);
            this.tbCNPJ.MaxLength = 20;
            this.tbCNPJ.Name = "tbCNPJ";
            this.tbCNPJ.Size = new System.Drawing.Size(128, 20);
            this.tbCNPJ.TabIndex = 6;
            this.tbCNPJ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCNPJ_KeyDown);
            this.tbCNPJ.Leave += new System.EventHandler(this.tbCNPJ_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "CNPJ";
            // 
            // cbEstado
            // 
            this.cbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(253, 152);
            this.cbEstado.MaxLength = 2;
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(54, 21);
            this.cbEstado.TabIndex = 5;
            this.cbEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEstado_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Estado";
            // 
            // tbCidade
            // 
            this.tbCidade.Location = new System.Drawing.Point(6, 153);
            this.tbCidade.MaxLength = 50;
            this.tbCidade.Name = "tbCidade";
            this.tbCidade.Size = new System.Drawing.Size(241, 20);
            this.tbCidade.TabIndex = 4;
            this.tbCidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCidade_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cidade";
            // 
            // tbEndereco
            // 
            this.tbEndereco.Location = new System.Drawing.Point(6, 110);
            this.tbEndereco.MaxLength = 100;
            this.tbEndereco.Name = "tbEndereco";
            this.tbEndereco.Size = new System.Drawing.Size(703, 20);
            this.tbEndereco.TabIndex = 3;
            this.tbEndereco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEndereco_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Endereço";
            // 
            // tbAtividade
            // 
            this.tbAtividade.Location = new System.Drawing.Point(6, 71);
            this.tbAtividade.MaxLength = 100;
            this.tbAtividade.Name = "tbAtividade";
            this.tbAtividade.Size = new System.Drawing.Size(703, 20);
            this.tbAtividade.TabIndex = 2;
            this.tbAtividade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAtividade_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Atividade";
            // 
            // tbNomeFantasia
            // 
            this.tbNomeFantasia.Location = new System.Drawing.Point(373, 32);
            this.tbNomeFantasia.MaxLength = 50;
            this.tbNomeFantasia.Name = "tbNomeFantasia";
            this.tbNomeFantasia.Size = new System.Drawing.Size(336, 20);
            this.tbNomeFantasia.TabIndex = 1;
            this.tbNomeFantasia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNomeFantasia_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(370, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome Fantasia";
            // 
            // tbRazaoSocial
            // 
            this.tbRazaoSocial.Location = new System.Drawing.Point(6, 32);
            this.tbRazaoSocial.MaxLength = 50;
            this.tbRazaoSocial.Name = "tbRazaoSocial";
            this.tbRazaoSocial.Size = new System.Drawing.Size(361, 20);
            this.tbRazaoSocial.TabIndex = 0;
            this.tbRazaoSocial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRazaoSocial_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razão Social";
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(662, 252);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 1;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(735, 243);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(727, 217);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados cadastrais";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(727, 217);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contas bancárias";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbIdContaBancaria);
            this.groupBox6.Controls.Add(this.btContaNova);
            this.groupBox6.Controls.Add(this.btContaRemover);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.btContaAdd);
            this.groupBox6.Controls.Add(this.tbConta);
            this.groupBox6.Controls.Add(this.cbTipoConta);
            this.groupBox6.Controls.Add(this.tbAgencia);
            this.groupBox6.Controls.Add(this.tbBanco);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(716, 203);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
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
            // btContaNova
            // 
            this.btContaNova.Location = new System.Drawing.Point(6, 171);
            this.btContaNova.Name = "btContaNova";
            this.btContaNova.Size = new System.Drawing.Size(75, 23);
            this.btContaNova.TabIndex = 62;
            this.btContaNova.Text = "Nova";
            this.btContaNova.UseVisualStyleBackColor = true;
            this.btContaNova.Click += new System.EventHandler(this.btContaNova_Click);
            // 
            // btContaRemover
            // 
            this.btContaRemover.Location = new System.Drawing.Point(629, 171);
            this.btContaRemover.Name = "btContaRemover";
            this.btContaRemover.Size = new System.Drawing.Size(75, 23);
            this.btContaRemover.TabIndex = 61;
            this.btContaRemover.Text = "Remover";
            this.btContaRemover.UseVisualStyleBackColor = true;
            this.btContaRemover.Click += new System.EventHandler(this.btContaRemover_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.gvContasBancarias);
            this.groupBox8.Location = new System.Drawing.Point(6, 59);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(702, 106);
            this.groupBox8.TabIndex = 60;
            this.groupBox8.TabStop = false;
            // 
            // gvContasBancarias
            // 
            this.gvContasBancarias.AllowUserToAddRows = false;
            this.gvContasBancarias.AllowUserToDeleteRows = false;
            this.gvContasBancarias.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvContasBancarias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvContasBancarias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvContasBancarias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.gvContasBancarias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvContasBancarias.Location = new System.Drawing.Point(3, 16);
            this.gvContasBancarias.MultiSelect = false;
            this.gvContasBancarias.Name = "gvContasBancarias";
            this.gvContasBancarias.ReadOnly = true;
            this.gvContasBancarias.RowHeadersVisible = false;
            this.gvContasBancarias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvContasBancarias.Size = new System.Drawing.Size(696, 87);
            this.gvContasBancarias.TabIndex = 0;
            this.gvContasBancarias.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gvContasBancarias_MouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "idContaBancaria";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Banco";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Agência";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Tipo Conta";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Conta";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // btContaAdd
            // 
            this.btContaAdd.Location = new System.Drawing.Point(629, 30);
            this.btContaAdd.Name = "btContaAdd";
            this.btContaAdd.Size = new System.Drawing.Size(75, 23);
            this.btContaAdd.TabIndex = 4;
            this.btContaAdd.Text = "Adicionar";
            this.btContaAdd.UseVisualStyleBackColor = true;
            this.btContaAdd.Click += new System.EventHandler(this.btContaAdd_Click);
            // 
            // tbConta
            // 
            this.tbConta.Location = new System.Drawing.Point(477, 32);
            this.tbConta.MaxLength = 20;
            this.tbConta.Name = "tbConta";
            this.tbConta.Size = new System.Drawing.Size(146, 20);
            this.tbConta.TabIndex = 3;
            // 
            // cbTipoConta
            // 
            this.cbTipoConta.FormattingEnabled = true;
            this.cbTipoConta.Location = new System.Drawing.Point(318, 32);
            this.cbTipoConta.Name = "cbTipoConta";
            this.cbTipoConta.Size = new System.Drawing.Size(153, 21);
            this.cbTipoConta.TabIndex = 2;
            // 
            // tbAgencia
            // 
            this.tbAgencia.Location = new System.Drawing.Point(208, 32);
            this.tbAgencia.MaxLength = 10;
            this.tbAgencia.Name = "tbAgencia";
            this.tbAgencia.Size = new System.Drawing.Size(104, 20);
            this.tbAgencia.TabIndex = 1;
            // 
            // tbBanco
            // 
            this.tbBanco.Location = new System.Drawing.Point(6, 32);
            this.tbBanco.MaxLength = 30;
            this.tbBanco.Name = "tbBanco";
            this.tbBanco.Size = new System.Drawing.Size(196, 20);
            this.tbBanco.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(474, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Nº Conta";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(315, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 13);
            this.label32.TabIndex = 57;
            this.label32.Text = "Tipo Conta";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(205, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(46, 13);
            this.label33.TabIndex = 56;
            this.label33.Text = "Agência";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(3, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(43, 13);
            this.label34.TabIndex = 55;
            this.label34.Text = "Banco";
            // 
            // EmpresaManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 280);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmpresaManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Empresas";
            this.Load += new System.EventHandler(this.EmpresaManutencao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvContasBancarias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbEndereco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAtividade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNomeFantasia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRazaoSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInscricaoEstadual;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbICM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCNPJ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbIdContaBancaria;
        private System.Windows.Forms.Button btContaNova;
        private System.Windows.Forms.Button btContaRemover;
        private System.Windows.Forms.GroupBox groupBox8;
        private Util.SortedDataGridView gvContasBancarias;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btContaAdd;
        private System.Windows.Forms.TextBox tbConta;
        private System.Windows.Forms.ComboBox cbTipoConta;
        private System.Windows.Forms.TextBox tbAgencia;
        private System.Windows.Forms.TextBox tbBanco;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
    }
}