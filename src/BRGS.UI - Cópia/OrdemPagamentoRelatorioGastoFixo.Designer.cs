namespace BRGS.UI
{
    partial class OrdemPagamentoRelatorioGastoFixo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gvDespesasSelecionadas = new BRGS.Util.SortedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbFiltroDespesa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gvDespesasCadastradas = new BRGS.Util.SortedDataGridView();
            this.idDespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Despesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btRem = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.chkDespesa = new System.Windows.Forms.CheckBox();
            this.chkUEN = new System.Windows.Forms.CheckBox();
            this.cbUEN = new System.Windows.Forms.ComboBox();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.lbAte = new System.Windows.Forms.Label();
            this.chkDataPagamento = new System.Windows.Forms.CheckBox();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.chkEmpresa = new System.Windows.Forms.CheckBox();
            this.btVisualizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespesasSelecionadas)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespesasCadastradas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btRem);
            this.groupBox1.Controls.Add(this.btAdd);
            this.groupBox1.Controls.Add(this.chkDespesa);
            this.groupBox1.Controls.Add(this.chkUEN);
            this.groupBox1.Controls.Add(this.cbUEN);
            this.groupBox1.Controls.Add(this.dtpAte);
            this.groupBox1.Controls.Add(this.dtpDe);
            this.groupBox1.Controls.Add(this.lbAte);
            this.groupBox1.Controls.Add(this.chkDataPagamento);
            this.groupBox1.Controls.Add(this.cbEmpresa);
            this.groupBox1.Controls.Add(this.chkEmpresa);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 365);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gvDespesasSelecionadas);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(399, 115);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(315, 246);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Despesas selecionadas";
            // 
            // gvDespesasSelecionadas
            // 
            this.gvDespesasSelecionadas.AllowUserToAddRows = false;
            this.gvDespesasSelecionadas.AllowUserToDeleteRows = false;
            this.gvDespesasSelecionadas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvDespesasSelecionadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDespesasSelecionadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDespesasSelecionadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gvDespesasSelecionadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDespesasSelecionadas.Location = new System.Drawing.Point(3, 16);
            this.gvDespesasSelecionadas.Name = "gvDespesasSelecionadas";
            this.gvDespesasSelecionadas.ReadOnly = true;
            this.gvDespesasSelecionadas.RowHeadersVisible = false;
            this.gvDespesasSelecionadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDespesasSelecionadas.Size = new System.Drawing.Size(309, 227);
            this.gvDespesasSelecionadas.TabIndex = 1;
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
            this.dataGridViewTextBoxColumn2.HeaderText = "Despesa";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbFiltroDespesa);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.gvDespesasCadastradas);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(34, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 246);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Despesas cadastradas";
            // 
            // tbFiltroDespesa
            // 
            this.tbFiltroDespesa.Location = new System.Drawing.Point(6, 32);
            this.tbFiltroDespesa.MaxLength = 50;
            this.tbFiltroDespesa.Name = "tbFiltroDespesa";
            this.tbFiltroDespesa.Size = new System.Drawing.Size(309, 20);
            this.tbFiltroDespesa.TabIndex = 0;
            this.tbFiltroDespesa.TextChanged += new System.EventHandler(this.tbFiltroDespesa_TextChanged);
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
            // gvDespesasCadastradas
            // 
            this.gvDespesasCadastradas.AllowUserToAddRows = false;
            this.gvDespesasCadastradas.AllowUserToDeleteRows = false;
            this.gvDespesasCadastradas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvDespesasCadastradas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvDespesasCadastradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDespesasCadastradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDespesa,
            this.Despesa});
            this.gvDespesasCadastradas.Location = new System.Drawing.Point(6, 58);
            this.gvDespesasCadastradas.Name = "gvDespesasCadastradas";
            this.gvDespesasCadastradas.ReadOnly = true;
            this.gvDespesasCadastradas.RowHeadersVisible = false;
            this.gvDespesasCadastradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDespesasCadastradas.Size = new System.Drawing.Size(309, 180);
            this.gvDespesasCadastradas.TabIndex = 1;
            // 
            // idDespesa
            // 
            this.idDespesa.HeaderText = "idDespesa";
            this.idDespesa.Name = "idDespesa";
            this.idDespesa.ReadOnly = true;
            this.idDespesa.Visible = false;
            // 
            // Despesa
            // 
            this.Despesa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Despesa.HeaderText = "Despesa";
            this.Despesa.Name = "Despesa";
            this.Despesa.ReadOnly = true;
            // 
            // btRem
            // 
            this.btRem.Enabled = false;
            this.btRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRem.Location = new System.Drawing.Point(362, 268);
            this.btRem.Name = "btRem";
            this.btRem.Size = new System.Drawing.Size(31, 23);
            this.btRem.TabIndex = 33;
            this.btRem.Text = "<";
            this.btRem.UseVisualStyleBackColor = true;
            this.btRem.Click += new System.EventHandler(this.btRem_Click);
            // 
            // btAdd
            // 
            this.btAdd.Enabled = false;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(362, 215);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(31, 23);
            this.btAdd.TabIndex = 32;
            this.btAdd.Text = ">";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // chkDespesa
            // 
            this.chkDespesa.AutoSize = true;
            this.chkDespesa.Location = new System.Drawing.Point(10, 95);
            this.chkDespesa.Name = "chkDespesa";
            this.chkDespesa.Size = new System.Drawing.Size(68, 17);
            this.chkDespesa.TabIndex = 7;
            this.chkDespesa.Text = "Despesa";
            this.chkDespesa.UseVisualStyleBackColor = true;
            this.chkDespesa.CheckedChanged += new System.EventHandler(this.chkDespesa_CheckedChanged);
            // 
            // chkUEN
            // 
            this.chkUEN.AutoSize = true;
            this.chkUEN.Location = new System.Drawing.Point(10, 72);
            this.chkUEN.Name = "chkUEN";
            this.chkUEN.Size = new System.Drawing.Size(49, 17);
            this.chkUEN.TabIndex = 5;
            this.chkUEN.Text = "UEN";
            this.chkUEN.UseVisualStyleBackColor = true;
            this.chkUEN.CheckedChanged += new System.EventHandler(this.chkUEN_CheckedChanged);
            // 
            // cbUEN
            // 
            this.cbUEN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUEN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUEN.Enabled = false;
            this.cbUEN.FormattingEnabled = true;
            this.cbUEN.Location = new System.Drawing.Point(98, 70);
            this.cbUEN.Name = "cbUEN";
            this.cbUEN.Size = new System.Drawing.Size(618, 21);
            this.cbUEN.TabIndex = 6;
            // 
            // dtpAte
            // 
            this.dtpAte.Enabled = false;
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(229, 44);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(99, 20);
            this.dtpAte.TabIndex = 4;
            // 
            // dtpDe
            // 
            this.dtpDe.Enabled = false;
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(96, 44);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(99, 20);
            this.dtpDe.TabIndex = 3;
            // 
            // lbAte
            // 
            this.lbAte.AutoSize = true;
            this.lbAte.Location = new System.Drawing.Point(201, 47);
            this.lbAte.Name = "lbAte";
            this.lbAte.Size = new System.Drawing.Size(22, 13);
            this.lbAte.TabIndex = 25;
            this.lbAte.Text = "até";
            // 
            // chkDataPagamento
            // 
            this.chkDataPagamento.AutoSize = true;
            this.chkDataPagamento.Location = new System.Drawing.Point(10, 47);
            this.chkDataPagamento.Name = "chkDataPagamento";
            this.chkDataPagamento.Size = new System.Drawing.Size(80, 17);
            this.chkDataPagamento.TabIndex = 2;
            this.chkDataPagamento.Text = "Data Pagto";
            this.chkDataPagamento.UseVisualStyleBackColor = true;
            this.chkDataPagamento.CheckedChanged += new System.EventHandler(this.chkDataPagamento_CheckedChanged);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEmpresa.Enabled = false;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(96, 17);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(618, 21);
            this.cbEmpresa.TabIndex = 1;
            // 
            // chkEmpresa
            // 
            this.chkEmpresa.AutoSize = true;
            this.chkEmpresa.Location = new System.Drawing.Point(10, 19);
            this.chkEmpresa.Name = "chkEmpresa";
            this.chkEmpresa.Size = new System.Drawing.Size(67, 17);
            this.chkEmpresa.TabIndex = 0;
            this.chkEmpresa.Text = "Empresa";
            this.chkEmpresa.UseVisualStyleBackColor = true;
            this.chkEmpresa.CheckedChanged += new System.EventHandler(this.chkEmpresa_CheckedChanged);
            // 
            // btVisualizar
            // 
            this.btVisualizar.Location = new System.Drawing.Point(647, 374);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btVisualizar.TabIndex = 1;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.UseVisualStyleBackColor = true;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // OrdemPagamentoRelatorioGastoFixo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 403);
            this.Controls.Add(this.btVisualizar);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrdemPagamentoRelatorioGastoFixo";
            this.Text = "OrdemPagamentoRelatorioGastoFixo";
            this.Load += new System.EventHandler(this.OrdemPagamentoRelatorioGastoFixo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDespesasSelecionadas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespesasCadastradas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.CheckBox chkEmpresa;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.Label lbAte;
        private System.Windows.Forms.CheckBox chkDataPagamento;
        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.CheckBox chkDespesa;
        private System.Windows.Forms.CheckBox chkUEN;
        private System.Windows.Forms.ComboBox cbUEN;
        private System.Windows.Forms.GroupBox groupBox4;
        private Util.SortedDataGridView gvDespesasSelecionadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbFiltroDespesa;
        private System.Windows.Forms.Label label3;
        private Util.SortedDataGridView gvDespesasCadastradas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDespesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Despesa;
        private System.Windows.Forms.Button btRem;
        private System.Windows.Forms.Button btAdd;
    }
}