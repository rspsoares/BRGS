namespace BRGS.UI
{
    partial class AbastecimentoManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbastecimentoManutencao));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDesconto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLitros = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbKilometragem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbData = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbObra = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDespesa = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbCentroCusto = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cbUEN = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMotorista = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPlaca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btExcluir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbPosto = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbTotal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbDesconto);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbLitros);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbKilometragem);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbValor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbData);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbObra);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbDespesa);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.cbCentroCusto);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.cbUEN);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Location = new System.Drawing.Point(7, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(562, 220);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // tbTotal
            // 
            this.tbTotal.Enabled = false;
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.Location = new System.Drawing.Point(438, 192);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(80, 20);
            this.tbTotal.TabIndex = 36;
            this.tbTotal.Text = "0,00";
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(435, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Total";
            // 
            // tbDesconto
            // 
            this.tbDesconto.Enabled = false;
            this.tbDesconto.Location = new System.Drawing.Point(353, 192);
            this.tbDesconto.Name = "tbDesconto";
            this.tbDesconto.Size = new System.Drawing.Size(79, 20);
            this.tbDesconto.TabIndex = 8;
            this.tbDesconto.Text = "0,00";
            this.tbDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDesconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDesconto_KeyDown);
            this.tbDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDesconto_KeyPress);
            this.tbDesconto.Leave += new System.EventHandler(this.tbDesconto_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Desconto";
            // 
            // tbLitros
            // 
            this.tbLitros.Enabled = false;
            this.tbLitros.Location = new System.Drawing.Point(190, 192);
            this.tbLitros.MaxLength = 10;
            this.tbLitros.Name = "tbLitros";
            this.tbLitros.Size = new System.Drawing.Size(70, 20);
            this.tbLitros.TabIndex = 6;
            this.tbLitros.Text = "0,000";
            this.tbLitros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbLitros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLitros_KeyDown);
            this.tbLitros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLitros_KeyPress);
            this.tbLitros.Leave += new System.EventHandler(this.tbLitros_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(187, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Litros";
            // 
            // tbKilometragem
            // 
            this.tbKilometragem.Enabled = false;
            this.tbKilometragem.Location = new System.Drawing.Point(114, 192);
            this.tbKilometragem.MaxLength = 15;
            this.tbKilometragem.Name = "tbKilometragem";
            this.tbKilometragem.Size = new System.Drawing.Size(70, 20);
            this.tbKilometragem.TabIndex = 5;
            this.tbKilometragem.Text = "0";
            this.tbKilometragem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbKilometragem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbKilometragem_KeyDown);
            this.tbKilometragem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKilometragem_KeyPress);
            this.tbKilometragem.Leave += new System.EventHandler(this.tbKilometragem_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Kilometragem";
            // 
            // tbValor
            // 
            this.tbValor.Enabled = false;
            this.tbValor.Location = new System.Drawing.Point(266, 192);
            this.tbValor.MaxLength = 10;
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(81, 20);
            this.tbValor.TabIndex = 7;
            this.tbValor.Text = "0,00";
            this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValor_KeyDown);
            this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
            this.tbValor.Leave += new System.EventHandler(this.tbValor_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(263, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Valor";
            // 
            // tbData
            // 
            this.tbData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbData.Location = new System.Drawing.Point(6, 192);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(102, 20);
            this.tbData.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Data";
            // 
            // cbObra
            // 
            this.cbObra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbObra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbObra.FormattingEnabled = true;
            this.cbObra.Location = new System.Drawing.Point(6, 32);
            this.cbObra.Name = "cbObra";
            this.cbObra.Size = new System.Drawing.Size(550, 21);
            this.cbObra.TabIndex = 0;
            this.cbObra.SelectedIndexChanged += new System.EventHandler(this.cbObra_SelectedIndexChanged);
            this.cbObra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbObra_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Obra:";
            // 
            // cbDespesa
            // 
            this.cbDespesa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDespesa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDespesa.FormattingEnabled = true;
            this.cbDespesa.Location = new System.Drawing.Point(7, 152);
            this.cbDespesa.Name = "cbDespesa";
            this.cbDespesa.Size = new System.Drawing.Size(549, 21);
            this.cbDespesa.TabIndex = 3;
            this.cbDespesa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDespesa_KeyDown);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(6, 136);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 13);
            this.label24.TabIndex = 23;
            this.label24.Text = "Despesa";
            // 
            // cbCentroCusto
            // 
            this.cbCentroCusto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCentroCusto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCentroCusto.FormattingEnabled = true;
            this.cbCentroCusto.Location = new System.Drawing.Point(7, 112);
            this.cbCentroCusto.Name = "cbCentroCusto";
            this.cbCentroCusto.Size = new System.Drawing.Size(550, 21);
            this.cbCentroCusto.TabIndex = 2;
            this.cbCentroCusto.SelectedValueChanged += new System.EventHandler(this.cbCentroCusto_SelectedValueChanged);
            this.cbCentroCusto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCentroCusto_KeyDown);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(4, 96);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 13);
            this.label25.TabIndex = 22;
            this.label25.Text = "Centro Custo";
            // 
            // cbUEN
            // 
            this.cbUEN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUEN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUEN.FormattingEnabled = true;
            this.cbUEN.Location = new System.Drawing.Point(6, 72);
            this.cbUEN.Name = "cbUEN";
            this.cbUEN.Size = new System.Drawing.Size(550, 21);
            this.cbUEN.TabIndex = 1;
            this.cbUEN.SelectedValueChanged += new System.EventHandler(this.cbUEN_SelectedValueChanged);
            this.cbUEN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbUEN_KeyDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(6, 56);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(191, 13);
            this.label26.TabIndex = 21;
            this.label26.Text = "Unidade Estratégica de Negócio";
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(494, 404);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 3;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbNumero);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbMotorista);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cbPlaca);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(7, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(562, 101);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // tbNumero
            // 
            this.tbNumero.Enabled = false;
            this.tbNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumero.Location = new System.Drawing.Point(6, 32);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(100, 20);
            this.tbNumero.TabIndex = 0;
            this.tbNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Número";
            // 
            // cbMotorista
            // 
            this.cbMotorista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMotorista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMotorista.FormattingEnabled = true;
            this.cbMotorista.Location = new System.Drawing.Point(6, 74);
            this.cbMotorista.Name = "cbMotorista";
            this.cbMotorista.Size = new System.Drawing.Size(549, 21);
            this.cbMotorista.TabIndex = 2;
            this.cbMotorista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMotorista_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Motorista";
            // 
            // cbPlaca
            // 
            this.cbPlaca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPlaca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPlaca.FormattingEnabled = true;
            this.cbPlaca.Location = new System.Drawing.Point(112, 32);
            this.cbPlaca.Name = "cbPlaca";
            this.cbPlaca.Size = new System.Drawing.Size(443, 21);
            this.cbPlaca.TabIndex = 1;
            this.cbPlaca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPlaca_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Placa";
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(7, 404);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 4;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPosto);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(7, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Posto de Combustível";
            // 
            // cbPosto
            // 
            this.cbPosto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPosto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPosto.FormattingEnabled = true;
            this.cbPosto.Location = new System.Drawing.Point(6, 32);
            this.cbPosto.Name = "cbPosto";
            this.cbPosto.Size = new System.Drawing.Size(547, 21);
            this.cbPosto.TabIndex = 0;
            this.cbPosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPosto_KeyDown);
            // 
            // AbastecimentoManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 433);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbastecimentoManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenção de Abastecimento";
            this.Load += new System.EventHandler(this.AbastecimentoManutencao_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbDespesa;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbCentroCusto;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbUEN;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbMotorista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPlaca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tbData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbObra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNumero;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.TextBox tbLitros;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbKilometragem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDesconto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPosto;
        private System.Windows.Forms.Label label11;
    }
}