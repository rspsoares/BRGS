namespace BRGS.UI
{
    partial class CentroCustoManutencao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CentroCustoManutencao));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btRemUsuario = new System.Windows.Forms.Button();
            this.btAddUsuario = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.gvUsuariosAssociados = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.gvUsuariosCadastrados = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAdministrativo = new System.Windows.Forms.CheckBox();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gvDespesasAssociadas = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbFiltroDespesa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gvDespesasCadastradas = new BRGS.Util.SortedDataGridView();
            this.idDespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btRem = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuariosAssociados)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuariosCadastrados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespesasAssociadas)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespesasCadastradas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.chkAdministrativo);
            this.groupBox1.Controls.Add(this.tbCodigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbDescricao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 484);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btRemUsuario);
            this.groupBox5.Controls.Add(this.btAddUsuario);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Location = new System.Drawing.Point(6, 294);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(580, 184);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ASSOCIAÇÃO DE USUÁRIOS";
            // 
            // btRemUsuario
            // 
            this.btRemUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemUsuario.Location = new System.Drawing.Point(272, 122);
            this.btRemUsuario.Name = "btRemUsuario";
            this.btRemUsuario.Size = new System.Drawing.Size(31, 23);
            this.btRemUsuario.TabIndex = 3;
            this.btRemUsuario.Text = "<";
            this.btRemUsuario.UseVisualStyleBackColor = true;
            this.btRemUsuario.Click += new System.EventHandler(this.btRemUsuario_Click);
            // 
            // btAddUsuario
            // 
            this.btAddUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddUsuario.Location = new System.Drawing.Point(272, 67);
            this.btAddUsuario.Name = "btAddUsuario";
            this.btAddUsuario.Size = new System.Drawing.Size(31, 23);
            this.btAddUsuario.TabIndex = 2;
            this.btAddUsuario.Text = ">";
            this.btAddUsuario.UseVisualStyleBackColor = true;
            this.btAddUsuario.Click += new System.EventHandler(this.btAddUsuario_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.gvUsuariosAssociados);
            this.groupBox7.Location = new System.Drawing.Point(309, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(261, 156);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Usuários associados";
            // 
            // gvUsuariosAssociados
            // 
            this.gvUsuariosAssociados.AllowUserToAddRows = false;
            this.gvUsuariosAssociados.AllowUserToDeleteRows = false;
            this.gvUsuariosAssociados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvUsuariosAssociados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvUsuariosAssociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsuariosAssociados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.gvUsuariosAssociados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvUsuariosAssociados.Location = new System.Drawing.Point(3, 16);
            this.gvUsuariosAssociados.Name = "gvUsuariosAssociados";
            this.gvUsuariosAssociados.ReadOnly = true;
            this.gvUsuariosAssociados.RowHeadersVisible = false;
            this.gvUsuariosAssociados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvUsuariosAssociados.Size = new System.Drawing.Size(255, 137);
            this.gvUsuariosAssociados.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "idUsuario";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.gvUsuariosCadastrados);
            this.groupBox6.Location = new System.Drawing.Point(6, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(259, 159);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Usuários Cadastrados";
            // 
            // gvUsuariosCadastrados
            // 
            this.gvUsuariosCadastrados.AllowUserToAddRows = false;
            this.gvUsuariosCadastrados.AllowUserToDeleteRows = false;
            this.gvUsuariosCadastrados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvUsuariosCadastrados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvUsuariosCadastrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsuariosCadastrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.gvUsuariosCadastrados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvUsuariosCadastrados.Location = new System.Drawing.Point(3, 16);
            this.gvUsuariosCadastrados.Name = "gvUsuariosCadastrados";
            this.gvUsuariosCadastrados.ReadOnly = true;
            this.gvUsuariosCadastrados.RowHeadersVisible = false;
            this.gvUsuariosCadastrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvUsuariosCadastrados.Size = new System.Drawing.Size(253, 140);
            this.gvUsuariosCadastrados.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "idUsuario";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // chkAdministrativo
            // 
            this.chkAdministrativo.AutoSize = true;
            this.chkAdministrativo.Location = new System.Drawing.Point(495, 31);
            this.chkAdministrativo.Name = "chkAdministrativo";
            this.chkAdministrativo.Size = new System.Drawing.Size(91, 17);
            this.chkAdministrativo.TabIndex = 2;
            this.chkAdministrativo.Text = "Administrativo";
            this.chkAdministrativo.UseVisualStyleBackColor = true;
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(6, 28);
            this.tbCodigo.MaxLength = 50;
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(116, 20);
            this.tbCodigo.TabIndex = 0;
            this.tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Código";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btRem);
            this.groupBox2.Controls.Add(this.btAdd);
            this.groupBox2.Location = new System.Drawing.Point(6, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 234);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ASSOCIAÇÃO DE DESPESAS";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gvDespesasAssociadas);
            this.groupBox4.Location = new System.Drawing.Point(309, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 213);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Despesas associadas";
            // 
            // gvDespesasAssociadas
            // 
            this.gvDespesasAssociadas.AllowUserToAddRows = false;
            this.gvDespesasAssociadas.AllowUserToDeleteRows = false;
            this.gvDespesasAssociadas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvDespesasAssociadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gvDespesasAssociadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDespesasAssociadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gvDespesasAssociadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDespesasAssociadas.Location = new System.Drawing.Point(3, 16);
            this.gvDespesasAssociadas.Name = "gvDespesasAssociadas";
            this.gvDespesasAssociadas.ReadOnly = true;
            this.gvDespesasAssociadas.RowHeadersVisible = false;
            this.gvDespesasAssociadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDespesasAssociadas.Size = new System.Drawing.Size(259, 194);
            this.gvDespesasAssociadas.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "idDespesa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbFiltroDespesa);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.gvDespesasCadastradas);
            this.groupBox3.Location = new System.Drawing.Point(6, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 213);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Despesas cadastradas";
            // 
            // tbFiltroDespesa
            // 
            this.tbFiltroDespesa.Location = new System.Drawing.Point(6, 32);
            this.tbFiltroDespesa.MaxLength = 50;
            this.tbFiltroDespesa.Name = "tbFiltroDespesa";
            this.tbFiltroDespesa.Size = new System.Drawing.Size(248, 20);
            this.tbFiltroDespesa.TabIndex = 0;
            this.tbFiltroDespesa.TextChanged += new System.EventHandler(this.tbFiltroDespesa_TextChanged);
            this.tbFiltroDespesa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFiltroDespesa_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrição";
            // 
            // gvDespesasCadastradas
            // 
            this.gvDespesasCadastradas.AllowUserToAddRows = false;
            this.gvDespesasCadastradas.AllowUserToDeleteRows = false;
            this.gvDespesasCadastradas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvDespesasCadastradas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gvDespesasCadastradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDespesasCadastradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDespesa,
            this.Descricao});
            this.gvDespesasCadastradas.Location = new System.Drawing.Point(6, 58);
            this.gvDespesasCadastradas.Name = "gvDespesasCadastradas";
            this.gvDespesasCadastradas.ReadOnly = true;
            this.gvDespesasCadastradas.RowHeadersVisible = false;
            this.gvDespesasCadastradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDespesasCadastradas.Size = new System.Drawing.Size(248, 146);
            this.gvDespesasCadastradas.TabIndex = 1;
            // 
            // idDespesa
            // 
            this.idDespesa.HeaderText = "idDespesa";
            this.idDespesa.Name = "idDespesa";
            this.idDespesa.ReadOnly = true;
            this.idDespesa.Visible = false;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // btRem
            // 
            this.btRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRem.Location = new System.Drawing.Point(272, 137);
            this.btRem.Name = "btRem";
            this.btRem.Size = new System.Drawing.Size(31, 23);
            this.btRem.TabIndex = 2;
            this.btRem.Text = "<";
            this.btRem.UseVisualStyleBackColor = true;
            this.btRem.Click += new System.EventHandler(this.btRem_Click);
            // 
            // btAdd
            // 
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(272, 74);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(31, 23);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = ">";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbDescricao
            // 
            this.tbDescricao.Location = new System.Drawing.Point(128, 28);
            this.tbDescricao.MaxLength = 100;
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(361, 20);
            this.tbDescricao.TabIndex = 1;
            this.tbDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDescricao_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Descrição";
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(520, 491);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 1;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(9, 491);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 2;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // CentroCustoManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 516);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CentroCustoManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Centros de Custos";
            this.Load += new System.EventHandler(this.CentroCustoManutencao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuariosAssociados)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuariosCadastrados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDespesasAssociadas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespesasCadastradas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btRem;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private Util.SortedDataGridView gvDespesasAssociadas;
        private Util.SortedDataGridView gvDespesasCadastradas;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDespesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.TextBox tbFiltroDespesa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAdministrativo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btRemUsuario;
        private System.Windows.Forms.Button btAddUsuario;
        private System.Windows.Forms.GroupBox groupBox7;
        private Util.SortedDataGridView gvUsuariosAssociados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.GroupBox groupBox6;
        private Util.SortedDataGridView gvUsuariosCadastrados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}