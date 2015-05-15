namespace BRGS.UI
{
    partial class ObraRelatorio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btVisualizar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gvEventosSelecionados = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbFiltroEvento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gvEventosCadastrados = new BRGS.Util.SortedDataGridView();
            this.idObra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btRem = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.cbUEN = new System.Windows.Forms.ComboBox();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.chkUEN = new System.Windows.Forms.CheckBox();
            this.cbLicitacao = new System.Windows.Forms.ComboBox();
            this.chkLicitacao = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEventosSelecionados)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEventosCadastrados)).BeginInit();
            this.SuspendLayout();
            // 
            // btVisualizar
            // 
            this.btVisualizar.Location = new System.Drawing.Point(768, 326);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btVisualizar.TabIndex = 3;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.UseVisualStyleBackColor = true;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btVisualizar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 355);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbLicitacao);
            this.groupBox2.Controls.Add(this.chkLicitacao);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btRem);
            this.groupBox2.Controls.Add(this.btAdd);
            this.groupBox2.Controls.Add(this.cbClientes);
            this.groupBox2.Controls.Add(this.cbUEN);
            this.groupBox2.Controls.Add(this.chkCliente);
            this.groupBox2.Controls.Add(this.chkUEN);
            this.groupBox2.Location = new System.Drawing.Point(6, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(837, 309);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gvEventosSelecionados);
            this.groupBox4.Location = new System.Drawing.Point(449, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(382, 208);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Eventos selecionados";
            // 
            // gvEventosSelecionados
            // 
            this.gvEventosSelecionados.AllowUserToAddRows = false;
            this.gvEventosSelecionados.AllowUserToDeleteRows = false;
            this.gvEventosSelecionados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvEventosSelecionados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gvEventosSelecionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEventosSelecionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gvEventosSelecionados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvEventosSelecionados.Location = new System.Drawing.Point(3, 16);
            this.gvEventosSelecionados.Name = "gvEventosSelecionados";
            this.gvEventosSelecionados.ReadOnly = true;
            this.gvEventosSelecionados.RowHeadersVisible = false;
            this.gvEventosSelecionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvEventosSelecionados.Size = new System.Drawing.Size(376, 189);
            this.gvEventosSelecionados.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "idObra";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Evento";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbFiltroEvento);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.gvEventosCadastrados);
            this.groupBox3.Location = new System.Drawing.Point(6, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 208);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Eventos cadastrados";
            // 
            // tbFiltroEvento
            // 
            this.tbFiltroEvento.Location = new System.Drawing.Point(6, 32);
            this.tbFiltroEvento.MaxLength = 50;
            this.tbFiltroEvento.Name = "tbFiltroEvento";
            this.tbFiltroEvento.Size = new System.Drawing.Size(388, 20);
            this.tbFiltroEvento.TabIndex = 0;
            this.tbFiltroEvento.TextChanged += new System.EventHandler(this.tbFiltroEvento_TextChanged);
            this.tbFiltroEvento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFiltroEvento_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nome";
            // 
            // gvEventosCadastrados
            // 
            this.gvEventosCadastrados.AllowUserToAddRows = false;
            this.gvEventosCadastrados.AllowUserToDeleteRows = false;
            this.gvEventosCadastrados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvEventosCadastrados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gvEventosCadastrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEventosCadastrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idObra,
            this.Evento});
            this.gvEventosCadastrados.Location = new System.Drawing.Point(6, 58);
            this.gvEventosCadastrados.Name = "gvEventosCadastrados";
            this.gvEventosCadastrados.ReadOnly = true;
            this.gvEventosCadastrados.RowHeadersVisible = false;
            this.gvEventosCadastrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvEventosCadastrados.Size = new System.Drawing.Size(388, 144);
            this.gvEventosCadastrados.TabIndex = 1;
            // 
            // idObra
            // 
            this.idObra.HeaderText = "idObra";
            this.idObra.Name = "idObra";
            this.idObra.ReadOnly = true;
            this.idObra.Visible = false;
            // 
            // Evento
            // 
            this.Evento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Evento.HeaderText = "Evento";
            this.Evento.Name = "Evento";
            this.Evento.ReadOnly = true;
            // 
            // btRem
            // 
            this.btRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRem.Location = new System.Drawing.Point(412, 234);
            this.btRem.Name = "btRem";
            this.btRem.Size = new System.Drawing.Size(31, 23);
            this.btRem.TabIndex = 9;
            this.btRem.Text = "<";
            this.btRem.UseVisualStyleBackColor = true;
            this.btRem.Click += new System.EventHandler(this.btRem_Click);
            // 
            // btAdd
            // 
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(412, 180);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(31, 23);
            this.btAdd.TabIndex = 8;
            this.btAdd.Text = ">";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // cbClientes
            // 
            this.cbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClientes.Enabled = false;
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(70, 44);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(761, 21);
            this.cbClientes.TabIndex = 3;
            this.cbClientes.SelectedIndexChanged += new System.EventHandler(this.cbClientes_SelectedIndexChanged);
            this.cbClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbClientes_KeyDown);
            // 
            // cbUEN
            // 
            this.cbUEN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUEN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUEN.Enabled = false;
            this.cbUEN.FormattingEnabled = true;
            this.cbUEN.Location = new System.Drawing.Point(70, 17);
            this.cbUEN.Name = "cbUEN";
            this.cbUEN.Size = new System.Drawing.Size(761, 21);
            this.cbUEN.TabIndex = 1;
            this.cbUEN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbUEN_KeyDown);
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Location = new System.Drawing.Point(6, 46);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(58, 17);
            this.chkCliente.TabIndex = 2;
            this.chkCliente.Text = "Cliente";
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // chkUEN
            // 
            this.chkUEN.AutoSize = true;
            this.chkUEN.Location = new System.Drawing.Point(6, 19);
            this.chkUEN.Name = "chkUEN";
            this.chkUEN.Size = new System.Drawing.Size(49, 17);
            this.chkUEN.TabIndex = 0;
            this.chkUEN.Text = "UEN";
            this.chkUEN.UseVisualStyleBackColor = true;
            this.chkUEN.CheckedChanged += new System.EventHandler(this.chkUEN_CheckedChanged);
            // 
            // cbLicitacao
            // 
            this.cbLicitacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLicitacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLicitacao.Enabled = false;
            this.cbLicitacao.FormattingEnabled = true;
            this.cbLicitacao.Location = new System.Drawing.Point(148, 69);
            this.cbLicitacao.Name = "cbLicitacao";
            this.cbLicitacao.Size = new System.Drawing.Size(351, 21);
            this.cbLicitacao.TabIndex = 33;
            // 
            // chkLicitacao
            // 
            this.chkLicitacao.AutoSize = true;
            this.chkLicitacao.Enabled = false;
            this.chkLicitacao.Location = new System.Drawing.Point(33, 71);
            this.chkLicitacao.Name = "chkLicitacao";
            this.chkLicitacao.Size = new System.Drawing.Size(109, 17);
            this.chkLicitacao.TabIndex = 32;
            this.chkLicitacao.Text = "Número Licitação";
            this.chkLicitacao.UseVisualStyleBackColor = true;
            this.chkLicitacao.CheckedChanged += new System.EventHandler(this.chkLicitacao_CheckedChanged);
            // 
            // ObraRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 362);
            this.Controls.Add(this.groupBox1);
            this.Name = "ObraRelatorio";
            this.Text = "LancamentoGastosRelatorio";
            this.Load += new System.EventHandler(this.LancamentoGastosRelatorio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvEventosSelecionados)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEventosCadastrados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.ComboBox cbUEN;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.CheckBox chkUEN;
        private System.Windows.Forms.GroupBox groupBox4;
        private Util.SortedDataGridView gvEventosSelecionados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbFiltroEvento;
        private System.Windows.Forms.Label label3;
        private Util.SortedDataGridView gvEventosCadastrados;
        private System.Windows.Forms.DataGridViewTextBoxColumn idObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Evento;
        private System.Windows.Forms.Button btRem;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.ComboBox cbLicitacao;
        private System.Windows.Forms.CheckBox chkLicitacao;
    }
}