namespace BRGS.UI
{
    partial class OrdemPagamentoRelatorioGastos
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
            this.btVisualizar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCustoFixo = new System.Windows.Forms.CheckBox();
            this.chkDespesa = new System.Windows.Forms.CheckBox();
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
            this.tbPagamentoAte = new System.Windows.Forms.DateTimePicker();
            this.tbPagamentoDe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDataPagamento = new System.Windows.Forms.CheckBox();
            this.tbVencimentoAte = new System.Windows.Forms.DateTimePicker();
            this.tbVencimentoDe = new System.Windows.Forms.DateTimePicker();
            this.lbAte = new System.Windows.Forms.Label();
            this.optNao = new System.Windows.Forms.RadioButton();
            this.optSim = new System.Windows.Forms.RadioButton();
            this.chkPaga = new System.Windows.Forms.CheckBox();
            this.chkDataVencimento = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespesasSelecionadas)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespesasCadastradas)).BeginInit();
            this.SuspendLayout();
            // 
            // btVisualizar
            // 
            this.btVisualizar.Location = new System.Drawing.Point(649, 470);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btVisualizar.TabIndex = 4;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.UseVisualStyleBackColor = true;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCustoFixo);
            this.groupBox1.Controls.Add(this.chkDespesa);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btRem);
            this.groupBox1.Controls.Add(this.btAdd);
            this.groupBox1.Controls.Add(this.tbPagamentoAte);
            this.groupBox1.Controls.Add(this.tbPagamentoDe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkDataPagamento);
            this.groupBox1.Controls.Add(this.tbVencimentoAte);
            this.groupBox1.Controls.Add(this.tbVencimentoDe);
            this.groupBox1.Controls.Add(this.lbAte);
            this.groupBox1.Controls.Add(this.optNao);
            this.groupBox1.Controls.Add(this.optSim);
            this.groupBox1.Controls.Add(this.chkPaga);
            this.groupBox1.Controls.Add(this.chkDataVencimento);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 461);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // chkCustoFixo
            // 
            this.chkCustoFixo.AutoSize = true;
            this.chkCustoFixo.Enabled = false;
            this.chkCustoFixo.Location = new System.Drawing.Point(33, 115);
            this.chkCustoFixo.Name = "chkCustoFixo";
            this.chkCustoFixo.Size = new System.Drawing.Size(75, 17);
            this.chkCustoFixo.TabIndex = 33;
            this.chkCustoFixo.Text = "Custo Fixo";
            this.chkCustoFixo.UseVisualStyleBackColor = true;
            this.chkCustoFixo.CheckedChanged += new System.EventHandler(this.chkCustoFixo_CheckedChanged);
            // 
            // chkDespesa
            // 
            this.chkDespesa.AutoSize = true;
            this.chkDespesa.Location = new System.Drawing.Point(8, 92);
            this.chkDespesa.Name = "chkDespesa";
            this.chkDespesa.Size = new System.Drawing.Size(68, 17);
            this.chkDespesa.TabIndex = 32;
            this.chkDespesa.Text = "Despesa";
            this.chkDespesa.UseVisualStyleBackColor = true;
            this.chkDespesa.CheckedChanged += new System.EventHandler(this.chkDespesa_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gvDespesasSelecionadas);
            this.groupBox4.Location = new System.Drawing.Point(398, 138);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(315, 317);
            this.groupBox4.TabIndex = 31;
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
            this.gvDespesasSelecionadas.Enabled = false;
            this.gvDespesasSelecionadas.Location = new System.Drawing.Point(3, 16);
            this.gvDespesasSelecionadas.Name = "gvDespesasSelecionadas";
            this.gvDespesasSelecionadas.ReadOnly = true;
            this.gvDespesasSelecionadas.RowHeadersVisible = false;
            this.gvDespesasSelecionadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDespesasSelecionadas.Size = new System.Drawing.Size(309, 298);
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
            this.groupBox3.Location = new System.Drawing.Point(33, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 317);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Despesas cadastradas";
            // 
            // tbFiltroDespesa
            // 
            this.tbFiltroDespesa.Enabled = false;
            this.tbFiltroDespesa.Location = new System.Drawing.Point(6, 32);
            this.tbFiltroDespesa.MaxLength = 50;
            this.tbFiltroDespesa.Name = "tbFiltroDespesa";
            this.tbFiltroDespesa.Size = new System.Drawing.Size(309, 20);
            this.tbFiltroDespesa.TabIndex = 0;
            this.tbFiltroDespesa.TextChanged += new System.EventHandler(this.tbFiltroEvento_TextChanged);
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
            this.gvDespesasCadastradas.Enabled = false;
            this.gvDespesasCadastradas.Location = new System.Drawing.Point(6, 58);
            this.gvDespesasCadastradas.Name = "gvDespesasCadastradas";
            this.gvDespesasCadastradas.ReadOnly = true;
            this.gvDespesasCadastradas.RowHeadersVisible = false;
            this.gvDespesasCadastradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDespesasCadastradas.Size = new System.Drawing.Size(309, 253);
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
            this.btRem.Location = new System.Drawing.Point(361, 311);
            this.btRem.Name = "btRem";
            this.btRem.Size = new System.Drawing.Size(31, 23);
            this.btRem.TabIndex = 29;
            this.btRem.Text = "<";
            this.btRem.UseVisualStyleBackColor = true;
            this.btRem.Click += new System.EventHandler(this.btRem_Click);
            // 
            // btAdd
            // 
            this.btAdd.Enabled = false;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(361, 259);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(31, 23);
            this.btAdd.TabIndex = 28;
            this.btAdd.Text = ">";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbPagamentoAte
            // 
            this.tbPagamentoAte.Enabled = false;
            this.tbPagamentoAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbPagamentoAte.Location = new System.Drawing.Point(268, 16);
            this.tbPagamentoAte.Name = "tbPagamentoAte";
            this.tbPagamentoAte.Size = new System.Drawing.Size(99, 20);
            this.tbPagamentoAte.TabIndex = 27;
            // 
            // tbPagamentoDe
            // 
            this.tbPagamentoDe.Enabled = false;
            this.tbPagamentoDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbPagamentoDe.Location = new System.Drawing.Point(135, 16);
            this.tbPagamentoDe.Name = "tbPagamentoDe";
            this.tbPagamentoDe.Size = new System.Drawing.Size(99, 20);
            this.tbPagamentoDe.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "até";
            // 
            // chkDataPagamento
            // 
            this.chkDataPagamento.AutoSize = true;
            this.chkDataPagamento.Location = new System.Drawing.Point(8, 19);
            this.chkDataPagamento.Name = "chkDataPagamento";
            this.chkDataPagamento.Size = new System.Drawing.Size(121, 17);
            this.chkDataPagamento.TabIndex = 24;
            this.chkDataPagamento.Text = "Data de Pagamento";
            this.chkDataPagamento.UseVisualStyleBackColor = true;
            this.chkDataPagamento.CheckedChanged += new System.EventHandler(this.chkDataPagamento_CheckedChanged);
            // 
            // tbVencimentoAte
            // 
            this.tbVencimentoAte.Enabled = false;
            this.tbVencimentoAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbVencimentoAte.Location = new System.Drawing.Point(268, 42);
            this.tbVencimentoAte.Name = "tbVencimentoAte";
            this.tbVencimentoAte.Size = new System.Drawing.Size(99, 20);
            this.tbVencimentoAte.TabIndex = 23;
            // 
            // tbVencimentoDe
            // 
            this.tbVencimentoDe.Enabled = false;
            this.tbVencimentoDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbVencimentoDe.Location = new System.Drawing.Point(135, 42);
            this.tbVencimentoDe.Name = "tbVencimentoDe";
            this.tbVencimentoDe.Size = new System.Drawing.Size(99, 20);
            this.tbVencimentoDe.TabIndex = 22;
            // 
            // lbAte
            // 
            this.lbAte.AutoSize = true;
            this.lbAte.Location = new System.Drawing.Point(240, 44);
            this.lbAte.Name = "lbAte";
            this.lbAte.Size = new System.Drawing.Size(22, 13);
            this.lbAte.TabIndex = 21;
            this.lbAte.Text = "até";
            // 
            // optNao
            // 
            this.optNao.AutoSize = true;
            this.optNao.Enabled = false;
            this.optNao.Location = new System.Drawing.Point(183, 69);
            this.optNao.Name = "optNao";
            this.optNao.Size = new System.Drawing.Size(45, 17);
            this.optNao.TabIndex = 12;
            this.optNao.Text = "Não";
            this.optNao.UseVisualStyleBackColor = true;
            // 
            // optSim
            // 
            this.optSim.AutoSize = true;
            this.optSim.Checked = true;
            this.optSim.Enabled = false;
            this.optSim.Location = new System.Drawing.Point(135, 68);
            this.optSim.Name = "optSim";
            this.optSim.Size = new System.Drawing.Size(42, 17);
            this.optSim.TabIndex = 11;
            this.optSim.TabStop = true;
            this.optSim.Text = "Sim";
            this.optSim.UseVisualStyleBackColor = true;
            // 
            // chkPaga
            // 
            this.chkPaga.AutoSize = true;
            this.chkPaga.Location = new System.Drawing.Point(8, 68);
            this.chkPaga.Name = "chkPaga";
            this.chkPaga.Size = new System.Drawing.Size(51, 17);
            this.chkPaga.TabIndex = 10;
            this.chkPaga.Text = "Paga";
            this.chkPaga.UseVisualStyleBackColor = true;
            this.chkPaga.CheckedChanged += new System.EventHandler(this.chkPaga_CheckedChanged);
            // 
            // chkDataVencimento
            // 
            this.chkDataVencimento.AutoSize = true;
            this.chkDataVencimento.Location = new System.Drawing.Point(8, 43);
            this.chkDataVencimento.Name = "chkDataVencimento";
            this.chkDataVencimento.Size = new System.Drawing.Size(108, 17);
            this.chkDataVencimento.TabIndex = 2;
            this.chkDataVencimento.Text = "Data Vencimento";
            this.chkDataVencimento.UseVisualStyleBackColor = true;
            this.chkDataVencimento.CheckedChanged += new System.EventHandler(this.chkDataVencimento_CheckedChanged);
            // 
            // OrdemPagamentoRelatorioGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 498);
            this.Controls.Add(this.btVisualizar);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrdemPagamentoRelatorioGastos";
            this.Text = "OrdemPagamentoRelatorioGastos";
            this.Load += new System.EventHandler(this.OrdemPagamentoRelatorioGastos_Load);
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

        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker tbVencimentoAte;
        private System.Windows.Forms.DateTimePicker tbVencimentoDe;
        private System.Windows.Forms.Label lbAte;
        private System.Windows.Forms.RadioButton optNao;
        private System.Windows.Forms.RadioButton optSim;
        private System.Windows.Forms.CheckBox chkPaga;
        private System.Windows.Forms.CheckBox chkDataVencimento;
        private System.Windows.Forms.DateTimePicker tbPagamentoAte;
        private System.Windows.Forms.DateTimePicker tbPagamentoDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDataPagamento;
        private System.Windows.Forms.CheckBox chkCustoFixo;
        private System.Windows.Forms.CheckBox chkDespesa;
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