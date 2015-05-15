namespace BRGS.UI
{
    partial class AuditoriaConsulta
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabAdministrativo = new System.Windows.Forms.TabControl();
            this.tabAtividades = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvAtividadesLog = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvAtividades = new BRGS.Util.SortedDataGridView();
            this.idDespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCategorias = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gvCategoriasLog = new BRGS.Util.SortedDataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gvCategorias = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabAdministrativo.SuspendLayout();
            this.tabAtividades.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAtividadesLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAtividades)).BeginInit();
            this.tabCategorias.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategoriasLog)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(890, 474);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tabAdministrativo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(882, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Administrativo";
            // 
            // tabAdministrativo
            // 
            this.tabAdministrativo.Controls.Add(this.tabAtividades);
            this.tabAdministrativo.Controls.Add(this.tabCategorias);
            this.tabAdministrativo.Location = new System.Drawing.Point(7, 6);
            this.tabAdministrativo.Name = "tabAdministrativo";
            this.tabAdministrativo.SelectedIndex = 0;
            this.tabAdministrativo.Size = new System.Drawing.Size(869, 436);
            this.tabAdministrativo.TabIndex = 0;
            // 
            // tabAtividades
            // 
            this.tabAtividades.BackColor = System.Drawing.SystemColors.Control;
            this.tabAtividades.Controls.Add(this.groupBox2);
            this.tabAtividades.Controls.Add(this.groupBox1);
            this.tabAtividades.Location = new System.Drawing.Point(4, 22);
            this.tabAtividades.Name = "tabAtividades";
            this.tabAtividades.Padding = new System.Windows.Forms.Padding(3);
            this.tabAtividades.Size = new System.Drawing.Size(861, 410);
            this.tabAtividades.TabIndex = 0;
            this.tabAtividades.Text = "Atividades";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvAtividadesLog);
            this.groupBox2.Location = new System.Drawing.Point(6, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 211);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Histórico";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvAtividades);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gvAtividadesLog
            // 
            this.gvAtividadesLog.AllowUserToAddRows = false;
            this.gvAtividadesLog.AllowUserToDeleteRows = false;
            this.gvAtividadesLog.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvAtividadesLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvAtividadesLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAtividadesLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column1,
            this.dataGridViewTextBoxColumn2,
            this.Column2,
            this.Column3,
            this.Column4});
            this.gvAtividadesLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAtividadesLog.Location = new System.Drawing.Point(3, 16);
            this.gvAtividadesLog.Name = "gvAtividadesLog";
            this.gvAtividadesLog.ReadOnly = true;
            this.gvAtividadesLog.RowHeadersVisible = false;
            this.gvAtividadesLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAtividadesLog.Size = new System.Drawing.Size(843, 192);
            this.gvAtividadesLog.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "idLog";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "idAtividade";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "Usuário";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 68;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "Data";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 55;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.HeaderText = "Ação";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 57;
            // 
            // gvAtividades
            // 
            this.gvAtividades.AllowUserToAddRows = false;
            this.gvAtividades.AllowUserToDeleteRows = false;
            this.gvAtividades.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvAtividades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvAtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAtividades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDespesa,
            this.Descricao});
            this.gvAtividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAtividades.Location = new System.Drawing.Point(3, 16);
            this.gvAtividades.Name = "gvAtividades";
            this.gvAtividades.ReadOnly = true;
            this.gvAtividades.RowHeadersVisible = false;
            this.gvAtividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAtividades.Size = new System.Drawing.Size(843, 162);
            this.gvAtividades.TabIndex = 1;
            this.gvAtividades.SelectionChanged += new System.EventHandler(this.gvAtividades_SelectionChanged);
            // 
            // idDespesa
            // 
            this.idDespesa.HeaderText = "idAtividade";
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
            // tabCategorias
            // 
            this.tabCategorias.BackColor = System.Drawing.SystemColors.Control;
            this.tabCategorias.Controls.Add(this.groupBox3);
            this.tabCategorias.Controls.Add(this.groupBox4);
            this.tabCategorias.Location = new System.Drawing.Point(4, 22);
            this.tabCategorias.Name = "tabCategorias";
            this.tabCategorias.Size = new System.Drawing.Size(861, 410);
            this.tabCategorias.TabIndex = 1;
            this.tabCategorias.Text = "Categorias";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gvCategoriasLog);
            this.groupBox3.Location = new System.Drawing.Point(6, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(849, 211);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Histórico";
            // 
            // gvCategoriasLog
            // 
            this.gvCategoriasLog.AllowUserToAddRows = false;
            this.gvCategoriasLog.AllowUserToDeleteRows = false;
            this.gvCategoriasLog.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvCategoriasLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gvCategoriasLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCategoriasLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.gvCategoriasLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCategoriasLog.Location = new System.Drawing.Point(3, 16);
            this.gvCategoriasLog.Name = "gvCategoriasLog";
            this.gvCategoriasLog.ReadOnly = true;
            this.gvCategoriasLog.RowHeadersVisible = false;
            this.gvCategoriasLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCategoriasLog.Size = new System.Drawing.Size(843, 192);
            this.gvCategoriasLog.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gvCategorias);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(852, 181);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // gvCategorias
            // 
            this.gvCategorias.AllowUserToAddRows = false;
            this.gvCategorias.AllowUserToDeleteRows = false;
            this.gvCategorias.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvCategorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.gvCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCategorias.Location = new System.Drawing.Point(3, 16);
            this.gvCategorias.Name = "gvCategorias";
            this.gvCategorias.ReadOnly = true;
            this.gvCategorias.RowHeadersVisible = false;
            this.gvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCategorias.Size = new System.Drawing.Size(846, 162);
            this.gvCategorias.TabIndex = 1;
            this.gvCategorias.SelectionChanged += new System.EventHandler(this.gvCategorias_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "idCategoria";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "idLog";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "idCategoria";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "Usuário";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 68;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn7.HeaderText = "Data";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 55;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn8.HeaderText = "Ação";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 57;
            // 
            // AuditoriaConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 489);
            this.Controls.Add(this.tabControl1);
            this.Name = "AuditoriaConsulta";
            this.Text = "AuditoriaConsulta";
            this.Load += new System.EventHandler(this.AuditoriaConsulta_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabAdministrativo.ResumeLayout(false);
            this.tabAtividades.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvAtividadesLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAtividades)).EndInit();
            this.tabCategorias.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCategoriasLog)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCategorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabAdministrativo;
        private System.Windows.Forms.TabPage tabAtividades;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Util.SortedDataGridView gvAtividades;
        private Util.SortedDataGridView gvAtividadesLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDespesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.TabPage tabCategorias;
        private System.Windows.Forms.GroupBox groupBox3;
        private Util.SortedDataGridView gvCategoriasLog;
        private System.Windows.Forms.GroupBox groupBox4;
        private Util.SortedDataGridView gvCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

    }
}