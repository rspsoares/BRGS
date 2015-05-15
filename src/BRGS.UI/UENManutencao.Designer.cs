namespace BRGS.UI
{
    partial class UENManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UENManutencao));
            this.btExcluir = new System.Windows.Forms.Button();
            this.btGravar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAdministrativo = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gvCentrosCustosAssociados = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbFiltroDespesa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gvCentrosCustosCadastrados = new BRGS.Util.SortedDataGridView();
            this.idCentroCusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btRem = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCentrosCustosAssociados)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCentrosCustosCadastrados)).BeginInit();
            this.SuspendLayout();
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(2, 346);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 5;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(624, 346);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 4;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAdministrativo);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lbCodigo);
            this.groupBox1.Controls.Add(this.tbDescricao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 338);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // chkAdministrativo
            // 
            this.chkAdministrativo.AutoSize = true;
            this.chkAdministrativo.Location = new System.Drawing.Point(600, 30);
            this.chkAdministrativo.Name = "chkAdministrativo";
            this.chkAdministrativo.Size = new System.Drawing.Size(91, 17);
            this.chkAdministrativo.TabIndex = 1;
            this.chkAdministrativo.Text = "Administrativo";
            this.chkAdministrativo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btRem);
            this.groupBox2.Controls.Add(this.btAdd);
            this.groupBox2.Location = new System.Drawing.Point(6, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(682, 278);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gvCentrosCustosAssociados);
            this.groupBox4.Location = new System.Drawing.Point(359, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(310, 256);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Centros de Custos associados";
            // 
            // gvCentrosCustosAssociados
            // 
            this.gvCentrosCustosAssociados.AllowUserToAddRows = false;
            this.gvCentrosCustosAssociados.AllowUserToDeleteRows = false;
            this.gvCentrosCustosAssociados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvCentrosCustosAssociados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCentrosCustosAssociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCentrosCustosAssociados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2,
            this.dataGridViewTextBoxColumn2});
            this.gvCentrosCustosAssociados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCentrosCustosAssociados.Location = new System.Drawing.Point(3, 16);
            this.gvCentrosCustosAssociados.Name = "gvCentrosCustosAssociados";
            this.gvCentrosCustosAssociados.ReadOnly = true;
            this.gvCentrosCustosAssociados.RowHeadersVisible = false;
            this.gvCentrosCustosAssociados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCentrosCustosAssociados.Size = new System.Drawing.Size(304, 237);
            this.gvCentrosCustosAssociados.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "idCentroCusto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Código";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
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
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.gvCentrosCustosCadastrados);
            this.groupBox3.Location = new System.Drawing.Point(6, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 256);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Centros de Custos cadastrados";
            // 
            // tbFiltroDespesa
            // 
            this.tbFiltroDespesa.Location = new System.Drawing.Point(6, 32);
            this.tbFiltroDespesa.MaxLength = 50;
            this.tbFiltroDespesa.Name = "tbFiltroDespesa";
            this.tbFiltroDespesa.Size = new System.Drawing.Size(298, 20);
            this.tbFiltroDespesa.TabIndex = 0;
            this.tbFiltroDespesa.TextChanged += new System.EventHandler(this.tbFiltroCentroCusto_TextChanged);
            this.tbFiltroDespesa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFiltroCentroCusto_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição";
            // 
            // gvCentrosCustosCadastrados
            // 
            this.gvCentrosCustosCadastrados.AllowUserToAddRows = false;
            this.gvCentrosCustosCadastrados.AllowUserToDeleteRows = false;
            this.gvCentrosCustosCadastrados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvCentrosCustosCadastrados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvCentrosCustosCadastrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCentrosCustosCadastrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCentroCusto,
            this.Column1,
            this.Descricao});
            this.gvCentrosCustosCadastrados.Location = new System.Drawing.Point(6, 58);
            this.gvCentrosCustosCadastrados.Name = "gvCentrosCustosCadastrados";
            this.gvCentrosCustosCadastrados.ReadOnly = true;
            this.gvCentrosCustosCadastrados.RowHeadersVisible = false;
            this.gvCentrosCustosCadastrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCentrosCustosCadastrados.Size = new System.Drawing.Size(297, 195);
            this.gvCentrosCustosCadastrados.TabIndex = 1;
            // 
            // idCentroCusto
            // 
            this.idCentroCusto.HeaderText = "idDespesa";
            this.idCentroCusto.Name = "idCentroCusto";
            this.idCentroCusto.ReadOnly = true;
            this.idCentroCusto.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
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
            this.btRem.Location = new System.Drawing.Point(322, 153);
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
            this.btAdd.Location = new System.Drawing.Point(322, 106);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(31, 23);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = ">";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(280, 12);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(35, 13);
            this.lbCodigo.TabIndex = 15;
            this.lbCodigo.Text = "label2";
            this.lbCodigo.Visible = false;
            // 
            // tbDescricao
            // 
            this.tbDescricao.Location = new System.Drawing.Point(6, 28);
            this.tbDescricao.MaxLength = 100;
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(585, 20);
            this.tbDescricao.TabIndex = 0;
            this.tbDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDescricao_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Descrição";
            // 
            // UENManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 371);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UENManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Unidade Estratégica de Negócio";
            this.Load += new System.EventHandler(this.UENManutencao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCentrosCustosAssociados)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCentrosCustosCadastrados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private Util.SortedDataGridView gvCentrosCustosAssociados;
        private System.Windows.Forms.GroupBox groupBox3;
        private Util.SortedDataGridView gvCentrosCustosCadastrados;
        private System.Windows.Forms.Button btRem;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox tbDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCentroCusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox tbFiltroDespesa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAdministrativo;
    }
}