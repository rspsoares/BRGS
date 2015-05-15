namespace BRGS.UI
{
    partial class MultaManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultaManutencao));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbOrgaoCompetente = new System.Windows.Forms.TextBox();
            this.cbGravidade = new System.Windows.Forms.ComboBox();
            this.tbPontos = new System.Windows.Forms.TextBox();
            this.tbInfrator = new System.Windows.Forms.TextBox();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.tbDesdobramento = new System.Windows.Forms.TextBox();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbValor);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbOrgaoCompetente);
            this.groupBox1.Controls.Add(this.cbGravidade);
            this.groupBox1.Controls.Add(this.tbPontos);
            this.groupBox1.Controls.Add(this.tbInfrator);
            this.groupBox1.Controls.Add(this.tbDescricao);
            this.groupBox1.Controls.Add(this.tbDesdobramento);
            this.groupBox1.Controls.Add(this.tbCodigo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbValor
            // 
            this.tbValor.Enabled = false;
            this.tbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValor.Location = new System.Drawing.Point(412, 110);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(79, 20);
            this.tbValor.TabIndex = 15;
            this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(412, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Valor";
            // 
            // tbOrgaoCompetente
            // 
            this.tbOrgaoCompetente.Location = new System.Drawing.Point(9, 149);
            this.tbOrgaoCompetente.MaxLength = 50;
            this.tbOrgaoCompetente.Name = "tbOrgaoCompetente";
            this.tbOrgaoCompetente.Size = new System.Drawing.Size(258, 20);
            this.tbOrgaoCompetente.TabIndex = 6;
            this.tbOrgaoCompetente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOrgaoCompetente_KeyDown);
            // 
            // cbGravidade
            // 
            this.cbGravidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGravidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGravidade.FormattingEnabled = true;
            this.cbGravidade.Location = new System.Drawing.Point(254, 109);
            this.cbGravidade.Name = "cbGravidade";
            this.cbGravidade.Size = new System.Drawing.Size(152, 21);
            this.cbGravidade.TabIndex = 5;
            this.cbGravidade.SelectedIndexChanged += new System.EventHandler(this.cbGravidade_SelectedIndexChanged);
            this.cbGravidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbGravidade_KeyDown);
            // 
            // tbPontos
            // 
            this.tbPontos.Location = new System.Drawing.Point(196, 110);
            this.tbPontos.MaxLength = 5;
            this.tbPontos.Name = "tbPontos";
            this.tbPontos.Size = new System.Drawing.Size(52, 20);
            this.tbPontos.TabIndex = 4;
            this.tbPontos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPontos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPontos_KeyDown);
            this.tbPontos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPontos_KeyPress);
            this.tbPontos.Leave += new System.EventHandler(this.tbPontos_Leave);
            // 
            // tbInfrator
            // 
            this.tbInfrator.Location = new System.Drawing.Point(9, 110);
            this.tbInfrator.MaxLength = 20;
            this.tbInfrator.Name = "tbInfrator";
            this.tbInfrator.Size = new System.Drawing.Size(181, 20);
            this.tbInfrator.TabIndex = 3;
            this.tbInfrator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInfrator_KeyDown);
            // 
            // tbDescricao
            // 
            this.tbDescricao.Location = new System.Drawing.Point(9, 71);
            this.tbDescricao.MaxLength = 250;
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(482, 20);
            this.tbDescricao.TabIndex = 2;
            this.tbDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDescricao_KeyDown);
            // 
            // tbDesdobramento
            // 
            this.tbDesdobramento.Location = new System.Drawing.Point(88, 32);
            this.tbDesdobramento.MaxLength = 5;
            this.tbDesdobramento.Name = "tbDesdobramento";
            this.tbDesdobramento.Size = new System.Drawing.Size(57, 20);
            this.tbDesdobramento.TabIndex = 1;
            this.tbDesdobramento.Text = "0";
            this.tbDesdobramento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDesdobramento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDesdobramento_KeyDown);
            this.tbDesdobramento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDesdobramento_KeyPress);
            this.tbDesdobramento.Leave += new System.EventHandler(this.tbDesdobramento_Leave);
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(9, 32);
            this.tbCodigo.MaxLength = 10;
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(73, 20);
            this.tbCodigo.TabIndex = 0;
            this.tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Órgão Competente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(193, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pontos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(254, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gravidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Infrator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descrição";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Desdobramento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(424, 186);
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
            // MultaManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 214);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultaManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Multas";
            this.Load += new System.EventHandler(this.MultaManutencao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.TextBox tbDescricao;
        private System.Windows.Forms.TextBox tbDesdobramento;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbOrgaoCompetente;
        private System.Windows.Forms.ComboBox cbGravidade;
        private System.Windows.Forms.TextBox tbPontos;
        private System.Windows.Forms.TextBox tbInfrator;
    }
}