namespace BRGS.UI
{
    partial class UsoVeiculosManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsoVeiculosManutencao));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPlaca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMotorista = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSaidaData = new System.Windows.Forms.DateTimePicker();
            this.tbSaidaHora = new System.Windows.Forms.DateTimePicker();
            this.chkRetorno = new System.Windows.Forms.CheckBox();
            this.tbChegadaData = new System.Windows.Forms.DateTimePicker();
            this.tbChegadaHora = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbObservacao = new System.Windows.Forms.TextBox();
            this.btGravar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbObservacao);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbChegadaHora);
            this.groupBox1.Controls.Add(this.tbChegadaData);
            this.groupBox1.Controls.Add(this.chkRetorno);
            this.groupBox1.Controls.Add(this.tbSaidaHora);
            this.groupBox1.Controls.Add(this.tbSaidaData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMotorista);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbPlaca);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Placa";
            // 
            // cbPlaca
            // 
            this.cbPlaca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPlaca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPlaca.FormattingEnabled = true;
            this.cbPlaca.Location = new System.Drawing.Point(6, 32);
            this.cbPlaca.Name = "cbPlaca";
            this.cbPlaca.Size = new System.Drawing.Size(185, 21);
            this.cbPlaca.TabIndex = 0;
            this.cbPlaca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPlaca_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(194, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Motorista";
            // 
            // cbMotorista
            // 
            this.cbMotorista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMotorista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMotorista.FormattingEnabled = true;
            this.cbMotorista.Location = new System.Drawing.Point(197, 32);
            this.cbMotorista.Name = "cbMotorista";
            this.cbMotorista.Size = new System.Drawing.Size(303, 21);
            this.cbMotorista.TabIndex = 1;
            this.cbMotorista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMotorista_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Saída do veículo";
            // 
            // tbSaidaData
            // 
            this.tbSaidaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbSaidaData.Location = new System.Drawing.Point(6, 77);
            this.tbSaidaData.Name = "tbSaidaData";
            this.tbSaidaData.Size = new System.Drawing.Size(108, 20);
            this.tbSaidaData.TabIndex = 2;
            // 
            // tbSaidaHora
            // 
            this.tbSaidaHora.CustomFormat = "HH:mm";
            this.tbSaidaHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tbSaidaHora.Location = new System.Drawing.Point(120, 77);
            this.tbSaidaHora.Name = "tbSaidaHora";
            this.tbSaidaHora.ShowUpDown = true;
            this.tbSaidaHora.Size = new System.Drawing.Size(68, 20);
            this.tbSaidaHora.TabIndex = 3;
            // 
            // chkRetorno
            // 
            this.chkRetorno.AutoSize = true;
            this.chkRetorno.Location = new System.Drawing.Point(197, 77);
            this.chkRetorno.Name = "chkRetorno";
            this.chkRetorno.Size = new System.Drawing.Size(118, 17);
            this.chkRetorno.TabIndex = 4;
            this.chkRetorno.Text = "Retorno do veículo";
            this.chkRetorno.UseVisualStyleBackColor = true;
            this.chkRetorno.CheckedChanged += new System.EventHandler(this.chkRetorno_CheckedChanged);
            // 
            // tbChegadaData
            // 
            this.tbChegadaData.Enabled = false;
            this.tbChegadaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbChegadaData.Location = new System.Drawing.Point(321, 77);
            this.tbChegadaData.Name = "tbChegadaData";
            this.tbChegadaData.Size = new System.Drawing.Size(105, 20);
            this.tbChegadaData.TabIndex = 5;
            // 
            // tbChegadaHora
            // 
            this.tbChegadaHora.CustomFormat = "HH:mm";
            this.tbChegadaHora.Enabled = false;
            this.tbChegadaHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tbChegadaHora.Location = new System.Drawing.Point(432, 77);
            this.tbChegadaHora.Name = "tbChegadaHora";
            this.tbChegadaHora.ShowUpDown = true;
            this.tbChegadaHora.Size = new System.Drawing.Size(68, 20);
            this.tbChegadaHora.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Observações";
            // 
            // tbObservacao
            // 
            this.tbObservacao.Location = new System.Drawing.Point(6, 120);
            this.tbObservacao.Multiline = true;
            this.tbObservacao.Name = "tbObservacao";
            this.tbObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservacao.Size = new System.Drawing.Size(494, 45);
            this.tbObservacao.TabIndex = 7;
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(432, 186);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 1;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(2, 186);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 2;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // UsoVeiculosManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 216);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsoVeiculosManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Uso de Veiculos";
            this.Load += new System.EventHandler(this.UsoVeiculosManutencao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker tbSaidaHora;
        private System.Windows.Forms.DateTimePicker tbSaidaData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMotorista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPlaca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbObservacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tbChegadaHora;
        private System.Windows.Forms.DateTimePicker tbChegadaData;
        private System.Windows.Forms.CheckBox chkRetorno;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.Button btExcluir;
    }
}