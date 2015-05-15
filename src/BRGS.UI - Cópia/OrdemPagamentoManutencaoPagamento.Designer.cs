namespace BRGS.UI
{
    partial class OrdemPagamentoManutencaoPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdemPagamentoManutencaoPagamento));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbDesconto = new System.Windows.Forms.TextBox();
            this.tbMulta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbValorPago = new System.Windows.Forms.TextBox();
            this.tbDataPagamento = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbIdItem = new System.Windows.Forms.Label();
            this.chkPago = new System.Windows.Forms.CheckBox();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.tbDataVencimento = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbItem);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lbIdItem);
            this.groupBox1.Controls.Add(this.chkPago);
            this.groupBox1.Controls.Add(this.tbValor);
            this.groupBox1.Controls.Add(this.tbDataVencimento);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 240);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // tbItem
            // 
            this.tbItem.Enabled = false;
            this.tbItem.Location = new System.Drawing.Point(6, 32);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(292, 20);
            this.tbItem.TabIndex = 23;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbDesconto);
            this.groupBox2.Controls.Add(this.tbMulta);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbValorPago);
            this.groupBox2.Controls.Add(this.tbDataPagamento);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(10, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 112);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações de Pagamento";
            // 
            // tbDesconto
            // 
            this.tbDesconto.Enabled = false;
            this.tbDesconto.Location = new System.Drawing.Point(153, 42);
            this.tbDesconto.MaxLength = 15;
            this.tbDesconto.Name = "tbDesconto";
            this.tbDesconto.Size = new System.Drawing.Size(129, 20);
            this.tbDesconto.TabIndex = 25;
            this.tbDesconto.Text = "0,00";
            this.tbDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDesconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDesconto_KeyDown);
            this.tbDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDesconto_KeyPress);
            this.tbDesconto.Leave += new System.EventHandler(this.tbDesconto_Leave);
            // 
            // tbMulta
            // 
            this.tbMulta.Enabled = false;
            this.tbMulta.Location = new System.Drawing.Point(6, 41);
            this.tbMulta.MaxLength = 15;
            this.tbMulta.Name = "tbMulta";
            this.tbMulta.Size = new System.Drawing.Size(131, 20);
            this.tbMulta.TabIndex = 24;
            this.tbMulta.Text = "0,00";
            this.tbMulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMulta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMulta_KeyDown);
            this.tbMulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMulta_KeyPress);
            this.tbMulta.Leave += new System.EventHandler(this.tbMulta_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Desconto (R$)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Multa (R$)";
            // 
            // tbValorPago
            // 
            this.tbValorPago.Enabled = false;
            this.tbValorPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValorPago.Location = new System.Drawing.Point(153, 81);
            this.tbValorPago.Name = "tbValorPago";
            this.tbValorPago.Size = new System.Drawing.Size(129, 20);
            this.tbValorPago.TabIndex = 19;
            this.tbValorPago.Text = "0,00";
            this.tbValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValorPago_KeyDown);
            this.tbValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorPago_KeyPress);
            this.tbValorPago.Leave += new System.EventHandler(this.tbValorPago_Leave);
            // 
            // tbDataPagamento
            // 
            this.tbDataPagamento.Enabled = false;
            this.tbDataPagamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataPagamento.Location = new System.Drawing.Point(6, 81);
            this.tbDataPagamento.Name = "tbDataPagamento";
            this.tbDataPagamento.Size = new System.Drawing.Size(131, 20);
            this.tbDataPagamento.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(150, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Valor Pago (R$)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Data Pagamento";
            // 
            // lbIdItem
            // 
            this.lbIdItem.AutoSize = true;
            this.lbIdItem.Location = new System.Drawing.Point(140, 16);
            this.lbIdItem.Name = "lbIdItem";
            this.lbIdItem.Size = new System.Drawing.Size(44, 13);
            this.lbIdItem.TabIndex = 18;
            this.lbIdItem.Text = "lbIdItem";
            this.lbIdItem.Visible = false;
            // 
            // chkPago
            // 
            this.chkPago.AutoSize = true;
            this.chkPago.Location = new System.Drawing.Point(10, 98);
            this.chkPago.Name = "chkPago";
            this.chkPago.Size = new System.Drawing.Size(51, 17);
            this.chkPago.TabIndex = 11;
            this.chkPago.Text = "Pago";
            this.chkPago.UseVisualStyleBackColor = true;
            this.chkPago.CheckedChanged += new System.EventHandler(this.chkPago_CheckedChanged);
            // 
            // tbValor
            // 
            this.tbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValor.Location = new System.Drawing.Point(163, 71);
            this.tbValor.MaxLength = 15;
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(135, 20);
            this.tbValor.TabIndex = 10;
            this.tbValor.Text = "0,00";
            this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValor_KeyDown);
            this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
            this.tbValor.Leave += new System.EventHandler(this.tbValor_Leave);
            // 
            // tbDataVencimento
            // 
            this.tbDataVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDataVencimento.Location = new System.Drawing.Point(6, 71);
            this.tbDataVencimento.Name = "tbDataVencimento";
            this.tbDataVencimento.Size = new System.Drawing.Size(141, 20);
            this.tbDataVencimento.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(160, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Valor (R$)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Data Vencimento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição Item";
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(231, 249);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 33;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // OrdemPagamentoManutencaoPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 278);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrdemPagamentoManutencaoPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordem Pagamento - Pagamento Item";
            this.Load += new System.EventHandler(this.OrdemPagamentoManutencaoPagamento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbDesconto;
        private System.Windows.Forms.TextBox tbMulta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbValorPago;
        private System.Windows.Forms.DateTimePicker tbDataPagamento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbIdItem;
        private System.Windows.Forms.CheckBox chkPago;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.DateTimePicker tbDataVencimento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.TextBox tbItem;
    }
}