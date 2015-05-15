namespace BRGS.UI
{
    partial class OrdemPagamentoManutencaoParcelamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdemPagamentoManutencaoParcelamento));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbID = new System.Windows.Forms.Label();
            this.btAtualizarParcela = new System.Windows.Forms.Button();
            this.tbDataVencimentoParcela = new System.Windows.Forms.DateTimePicker();
            this.tbValorParcela = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btCalcular = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvParcelas = new BRGS.Util.SortedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbNumeroParcelas = new System.Windows.Forms.TextBox();
            this.tbDataPrimeiroVencimento = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbValorTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btGerar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lbTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTotal);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btCalcular);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbNumeroParcelas);
            this.groupBox1.Controls.Add(this.tbDataPrimeiroVencimento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbValorTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 435);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbID);
            this.groupBox3.Controls.Add(this.btAtualizarParcela);
            this.groupBox3.Controls.Add(this.tbDataVencimentoParcela);
            this.groupBox3.Controls.Add(this.tbValorParcela);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(6, 366);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 63);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ajuste Parcela";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(234, 19);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(26, 13);
            this.lbID.TabIndex = 5;
            this.lbID.Text = "lbID";
            this.lbID.Visible = false;
            // 
            // btAtualizarParcela
            // 
            this.btAtualizarParcela.Location = new System.Drawing.Point(292, 33);
            this.btAtualizarParcela.Name = "btAtualizarParcela";
            this.btAtualizarParcela.Size = new System.Drawing.Size(75, 23);
            this.btAtualizarParcela.TabIndex = 2;
            this.btAtualizarParcela.Text = "Atualizar";
            this.btAtualizarParcela.UseVisualStyleBackColor = true;
            this.btAtualizarParcela.Click += new System.EventHandler(this.btAtualizarParcela_Click);
            // 
            // tbDataVencimentoParcela
            // 
            this.tbDataVencimentoParcela.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataVencimentoParcela.Location = new System.Drawing.Point(6, 32);
            this.tbDataVencimentoParcela.Name = "tbDataVencimentoParcela";
            this.tbDataVencimentoParcela.Size = new System.Drawing.Size(117, 20);
            this.tbDataVencimentoParcela.TabIndex = 0;
            // 
            // tbValorParcela
            // 
            this.tbValorParcela.Location = new System.Drawing.Point(129, 32);
            this.tbValorParcela.Name = "tbValorParcela";
            this.tbValorParcela.Size = new System.Drawing.Size(80, 20);
            this.tbValorParcela.TabIndex = 1;
            this.tbValorParcela.Text = "0,00";
            this.tbValorParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorParcela.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValorParcela_KeyDown);
            this.tbValorParcela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorParcela_KeyPress);
            this.tbValorParcela.Leave += new System.EventHandler(this.tbValorParcela_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Vencimento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Valor Parcela";
            // 
            // btCalcular
            // 
            this.btCalcular.Location = new System.Drawing.Point(309, 26);
            this.btCalcular.Name = "btCalcular";
            this.btCalcular.Size = new System.Drawing.Size(75, 23);
            this.btCalcular.TabIndex = 3;
            this.btCalcular.Text = "Calcular";
            this.btCalcular.UseVisualStyleBackColor = true;
            this.btCalcular.Click += new System.EventHandler(this.btCalcular_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvParcelas);
            this.groupBox2.Location = new System.Drawing.Point(6, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 279);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parcelas";
            // 
            // gvParcelas
            // 
            this.gvParcelas.AllowUserToAddRows = false;
            this.gvParcelas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvParcelas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.gvParcelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvParcelas.Location = new System.Drawing.Point(3, 16);
            this.gvParcelas.MultiSelect = false;
            this.gvParcelas.Name = "gvParcelas";
            this.gvParcelas.ReadOnly = true;
            this.gvParcelas.RowHeadersVisible = false;
            this.gvParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvParcelas.Size = new System.Drawing.Size(370, 260);
            this.gvParcelas.TabIndex = 0;
            this.gvParcelas.SelectionChanged += new System.EventHandler(this.gvParcelas_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Parcela";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Vencimento";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Valor";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // tbNumeroParcelas
            // 
            this.tbNumeroParcelas.Location = new System.Drawing.Point(230, 29);
            this.tbNumeroParcelas.Name = "tbNumeroParcelas";
            this.tbNumeroParcelas.Size = new System.Drawing.Size(54, 20);
            this.tbNumeroParcelas.TabIndex = 2;
            this.tbNumeroParcelas.Text = "0";
            this.tbNumeroParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNumeroParcelas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNumeroParcelas_KeyDown);
            this.tbNumeroParcelas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeroParcelas_KeyPress);
            // 
            // tbDataPrimeiroVencimento
            // 
            this.tbDataPrimeiroVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataPrimeiroVencimento.Location = new System.Drawing.Point(9, 29);
            this.tbDataPrimeiroVencimento.Name = "tbDataPrimeiroVencimento";
            this.tbDataPrimeiroVencimento.Size = new System.Drawing.Size(123, 20);
            this.tbDataPrimeiroVencimento.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Primeiro Vencimento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nº Parcelas";
            // 
            // tbValorTotal
            // 
            this.tbValorTotal.Location = new System.Drawing.Point(138, 28);
            this.tbValorTotal.Name = "tbValorTotal";
            this.tbValorTotal.Size = new System.Drawing.Size(86, 20);
            this.tbValorTotal.TabIndex = 1;
            this.tbValorTotal.Text = "0,00";
            this.tbValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorTotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValorTotal_KeyDown);
            this.tbValorTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorTotal_KeyPress);
            this.tbValorTotal.Leave += new System.EventHandler(this.tbValorTotal_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor Total";
            // 
            // btGerar
            // 
            this.btGerar.Location = new System.Drawing.Point(318, 443);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(75, 23);
            this.btGerar.TabIndex = 1;
            this.btGerar.Text = "Gerar";
            this.btGerar.UseVisualStyleBackColor = true;
            this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(3, 443);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 2;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.Black;
            this.lbTotal.Location = new System.Drawing.Point(131, 340);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(248, 23);
            this.lbTotal.TabIndex = 25;
            this.lbTotal.Text = "Total: R$ 0,00";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OrdemPagamentoManutencaoParcelamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 472);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btGerar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrdemPagamentoManutencaoParcelamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geração de Parcelamento";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvParcelas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNumeroParcelas;
        private System.Windows.Forms.DateTimePicker tbDataPrimeiroVencimento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbValorTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btCalcular;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Button btAtualizarParcela;
        private System.Windows.Forms.DateTimePicker tbDataVencimentoParcela;
        private System.Windows.Forms.TextBox tbValorParcela;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Util.SortedDataGridView gvParcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label lbTotal;
    }
}