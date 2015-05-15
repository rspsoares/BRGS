namespace BRGS.UI
{
    partial class ParametrizacaoManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametrizacaoManutencao));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOPDiasVencAlerta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOPDiasVencCritico = new System.Windows.Forms.TextBox();
            this.tbVeiculoDiasVencCritico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbVeiculoDiasVencAlerta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(205, 115);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tbOPDiasVencCritico);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbOPDiasVencAlerta);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(197, 89);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ordem de Pagamento";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.tbVeiculoDiasVencCritico);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbVeiculoDiasVencAlerta);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(197, 89);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Veículos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dias para Venc. Alerta";
            // 
            // tbOPDiasVencAlerta
            // 
            this.tbOPDiasVencAlerta.Location = new System.Drawing.Point(6, 24);
            this.tbOPDiasVencAlerta.Name = "tbOPDiasVencAlerta";
            this.tbOPDiasVencAlerta.Size = new System.Drawing.Size(53, 20);
            this.tbOPDiasVencAlerta.TabIndex = 1;
            this.tbOPDiasVencAlerta.Text = "0";
            this.tbOPDiasVencAlerta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbOPDiasVencAlerta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOPDiasVencAlerta_KeyDown);
            this.tbOPDiasVencAlerta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOPDiasVencAlerta_KeyPress);
            this.tbOPDiasVencAlerta.Leave += new System.EventHandler(this.tbOPDiasVencAlerta_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dias para Venc. Crítico";
            // 
            // tbOPDiasVencCritico
            // 
            this.tbOPDiasVencCritico.Location = new System.Drawing.Point(6, 63);
            this.tbOPDiasVencCritico.Name = "tbOPDiasVencCritico";
            this.tbOPDiasVencCritico.Size = new System.Drawing.Size(53, 20);
            this.tbOPDiasVencCritico.TabIndex = 3;
            this.tbOPDiasVencCritico.Text = "0";
            this.tbOPDiasVencCritico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbOPDiasVencCritico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOPDiasVencCritico_KeyDown);
            this.tbOPDiasVencCritico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOPDiasVencCritico_KeyPress);
            this.tbOPDiasVencCritico.Leave += new System.EventHandler(this.tbOPDiasVencCritico_Leave);
            // 
            // tbVeiculoDiasVencCritico
            // 
            this.tbVeiculoDiasVencCritico.Location = new System.Drawing.Point(3, 63);
            this.tbVeiculoDiasVencCritico.Name = "tbVeiculoDiasVencCritico";
            this.tbVeiculoDiasVencCritico.Size = new System.Drawing.Size(56, 20);
            this.tbVeiculoDiasVencCritico.TabIndex = 7;
            this.tbVeiculoDiasVencCritico.Text = "0";
            this.tbVeiculoDiasVencCritico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbVeiculoDiasVencCritico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbVeiculoDiasVencCritico_KeyDown);
            this.tbVeiculoDiasVencCritico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVeiculoDiasVencCritico_KeyPress);
            this.tbVeiculoDiasVencCritico.Leave += new System.EventHandler(this.tbVeiculoDiasVencCritico_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dias para Venc. Doc. Crítico";
            // 
            // tbVeiculoDiasVencAlerta
            // 
            this.tbVeiculoDiasVencAlerta.Location = new System.Drawing.Point(6, 24);
            this.tbVeiculoDiasVencAlerta.Name = "tbVeiculoDiasVencAlerta";
            this.tbVeiculoDiasVencAlerta.Size = new System.Drawing.Size(53, 20);
            this.tbVeiculoDiasVencAlerta.TabIndex = 5;
            this.tbVeiculoDiasVencAlerta.Text = "0";
            this.tbVeiculoDiasVencAlerta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbVeiculoDiasVencAlerta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbVeiculoDiasVencAlerta_KeyDown);
            this.tbVeiculoDiasVencAlerta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVeiculoDiasVencAlerta_KeyPress);
            this.tbVeiculoDiasVencAlerta.Leave += new System.EventHandler(this.tbVeiculoDiasVencAlerta_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dias para Venc. Doc. Alerta";
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(131, 123);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 1;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // ParametrizacaoManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 279);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ParametrizacaoManutencao";
            this.Text = "ParametrizacaoManutencao";
            this.Load += new System.EventHandler(this.ParametrizacaoManutencao_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbOPDiasVencCritico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOPDiasVencAlerta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbVeiculoDiasVencCritico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbVeiculoDiasVencAlerta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btGravar;
    }
}