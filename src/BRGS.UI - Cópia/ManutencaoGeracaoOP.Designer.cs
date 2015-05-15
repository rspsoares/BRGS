namespace BRGS.UI
{
    partial class ManutencaoGeracaoOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManutencaoGeracaoOP));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbData = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDespesa = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbCentroCusto = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cbUEN = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btGerarOP = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbValor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbData);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbDespesa);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.cbCentroCusto);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.cbUEN);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Location = new System.Drawing.Point(1, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 177);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // tbValor
            // 
            this.tbValor.Enabled = false;
            this.tbValor.Location = new System.Drawing.Point(124, 152);
            this.tbValor.MaxLength = 10;
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(81, 20);
            this.tbValor.TabIndex = 7;
            this.tbValor.Text = "0,00";
            this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(121, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Valor";
            // 
            // tbData
            // 
            this.tbData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbData.Location = new System.Drawing.Point(6, 152);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(112, 20);
            this.tbData.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Data Vencimento";
            // 
            // cbDespesa
            // 
            this.cbDespesa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDespesa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDespesa.FormattingEnabled = true;
            this.cbDespesa.Location = new System.Drawing.Point(7, 112);
            this.cbDespesa.Name = "cbDespesa";
            this.cbDespesa.Size = new System.Drawing.Size(487, 21);
            this.cbDespesa.TabIndex = 3;
            this.cbDespesa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDespesa_KeyDown);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(6, 96);
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
            this.cbCentroCusto.Location = new System.Drawing.Point(7, 72);
            this.cbCentroCusto.Name = "cbCentroCusto";
            this.cbCentroCusto.Size = new System.Drawing.Size(487, 21);
            this.cbCentroCusto.TabIndex = 2;
            this.cbCentroCusto.SelectedValueChanged += new System.EventHandler(this.cbCentroCusto_SelectedValueChanged);
            this.cbCentroCusto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCentroCusto_KeyDown);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(4, 56);
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
            this.cbUEN.Location = new System.Drawing.Point(6, 32);
            this.cbUEN.Name = "cbUEN";
            this.cbUEN.Size = new System.Drawing.Size(488, 21);
            this.cbUEN.TabIndex = 1;
            this.cbUEN.SelectedValueChanged += new System.EventHandler(this.cbUEN_SelectedValueChanged);
            this.cbUEN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbUEN_KeyDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(6, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(191, 13);
            this.label26.TabIndex = 21;
            this.label26.Text = "Unidade Estratégica de Negócio";
            // 
            // btGerarOP
            // 
            this.btGerarOP.Location = new System.Drawing.Point(429, 185);
            this.btGerarOP.Name = "btGerarOP";
            this.btGerarOP.Size = new System.Drawing.Size(75, 23);
            this.btGerarOP.TabIndex = 3;
            this.btGerarOP.Text = "Gerar OP";
            this.btGerarOP.UseVisualStyleBackColor = true;
            this.btGerarOP.Click += new System.EventHandler(this.btGerarOP_Click);
            // 
            // ManutencaoGeracaoOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 213);
            this.Controls.Add(this.btGerarOP);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManutencaoGeracaoOP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenção do Veículo - Geração de Ordem de Pagamento";
            this.Load += new System.EventHandler(this.ManutencaoGeracaoOP_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tbData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDespesa;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbCentroCusto;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbUEN;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btGerarOP;
    }
}