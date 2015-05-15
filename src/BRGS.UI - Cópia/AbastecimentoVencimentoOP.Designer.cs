namespace BRGS.UI
{
    partial class AbastecimentoVencimentoOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbastecimentoVencimentoOP));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOPAbastecimento = new System.Windows.Forms.ComboBox();
            this.chkAdicionarOP = new System.Windows.Forms.CheckBox();
            this.tbData = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btGerar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbOPAbastecimento);
            this.groupBox1.Controls.Add(this.chkAdicionarOP);
            this.groupBox1.Controls.Add(this.tbData);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbOPAbastecimento
            // 
            this.cbOPAbastecimento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbOPAbastecimento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbOPAbastecimento.Enabled = false;
            this.cbOPAbastecimento.FormattingEnabled = true;
            this.cbOPAbastecimento.Location = new System.Drawing.Point(120, 35);
            this.cbOPAbastecimento.Name = "cbOPAbastecimento";
            this.cbOPAbastecimento.Size = new System.Drawing.Size(157, 21);
            this.cbOPAbastecimento.TabIndex = 2;
            this.cbOPAbastecimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbOPAbastecimento_KeyDown);
            // 
            // chkAdicionarOP
            // 
            this.chkAdicionarOP.AutoSize = true;
            this.chkAdicionarOP.Location = new System.Drawing.Point(120, 15);
            this.chkAdicionarOP.Name = "chkAdicionarOP";
            this.chkAdicionarOP.Size = new System.Drawing.Size(103, 17);
            this.chkAdicionarOP.TabIndex = 1;
            this.chkAdicionarOP.Text = "Adicionar na OP";
            this.chkAdicionarOP.UseVisualStyleBackColor = true;
            this.chkAdicionarOP.CheckedChanged += new System.EventHandler(this.chkAdicionarOP_CheckedChanged);
            // 
            // tbData
            // 
            this.tbData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbData.Location = new System.Drawing.Point(13, 35);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(101, 20);
            this.tbData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Vencimento";
            // 
            // btGerar
            // 
            this.btGerar.Location = new System.Drawing.Point(210, 88);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(75, 23);
            this.btGerar.TabIndex = 1;
            this.btGerar.Text = "Gerar";
            this.btGerar.UseVisualStyleBackColor = true;
            this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(2, 88);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 2;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // AbastecimentoVencimentoOP
            // 
            this.AcceptButton = this.btGerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(288, 116);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btGerar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbastecimentoVencimentoOP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data de Vencimento da OP";
            this.Load += new System.EventHandler(this.AbastecimentoVencimentoOP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.Button btCancelar;
        public System.Windows.Forms.DateTimePicker tbData;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbOPAbastecimento;
        public System.Windows.Forms.CheckBox chkAdicionarOP;
    }
}