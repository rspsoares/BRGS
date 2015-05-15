namespace BRGS.UI
{
    partial class UsuarioConsulta
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
            this.btNovo = new System.Windows.Forms.Button();
            this.btVisualizar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvUsuarios = new BRGS.Util.SortedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.cbPesquisaCampo = new System.Windows.Forms.ComboBox();
            this.tbPesquisaValor = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(3, 368);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(75, 23);
            this.btNovo.TabIndex = 3;
            this.btNovo.Text = "Novo";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btVisualizar
            // 
            this.btVisualizar.Location = new System.Drawing.Point(457, 368);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btVisualizar.TabIndex = 2;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.UseVisualStyleBackColor = true;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvUsuarios);
            this.groupBox2.Location = new System.Drawing.Point(3, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 304);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // gvUsuarios
            // 
            this.gvUsuarios.AllowUserToAddRows = false;
            this.gvUsuarios.AllowUserToDeleteRows = false;
            this.gvUsuarios.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.gvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvUsuarios.Location = new System.Drawing.Point(3, 16);
            this.gvUsuarios.Name = "gvUsuarios";
            this.gvUsuarios.ReadOnly = true;
            this.gvUsuarios.RowHeadersVisible = false;
            this.gvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvUsuarios.Size = new System.Drawing.Size(523, 285);
            this.gvUsuarios.TabIndex = 0;
            this.gvUsuarios.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvUsuarios_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "idUsuario";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Nome";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Login";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Último acesso";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Bloqueado";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btPesquisar);
            this.groupBox1.Controls.Add(this.cbPesquisaCampo);
            this.groupBox1.Controls.Add(this.tbPesquisaValor);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro da pesquisa";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(442, 18);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(81, 23);
            this.btPesquisar.TabIndex = 2;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // cbPesquisaCampo
            // 
            this.cbPesquisaCampo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPesquisaCampo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPesquisaCampo.FormattingEnabled = true;
            this.cbPesquisaCampo.Location = new System.Drawing.Point(8, 19);
            this.cbPesquisaCampo.Name = "cbPesquisaCampo";
            this.cbPesquisaCampo.Size = new System.Drawing.Size(132, 21);
            this.cbPesquisaCampo.TabIndex = 0;
            this.cbPesquisaCampo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPesquisaCampo_KeyDown);
            // 
            // tbPesquisaValor
            // 
            this.tbPesquisaValor.Location = new System.Drawing.Point(146, 20);
            this.tbPesquisaValor.Name = "tbPesquisaValor";
            this.tbPesquisaValor.Size = new System.Drawing.Size(290, 20);
            this.tbPesquisaValor.TabIndex = 1;
            this.tbPesquisaValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPesquisaValor_KeyDown);
            // 
            // UsuarioConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 399);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.btVisualizar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UsuarioConsulta";
            this.Text = "UsuarioConsulta";
            this.Load += new System.EventHandler(this.UsuarioConsulta_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private Util.SortedDataGridView gvUsuarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.ComboBox cbPesquisaCampo;
        private System.Windows.Forms.TextBox tbPesquisaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}