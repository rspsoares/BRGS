namespace BRGS.UI
{
    partial class ServidorConexao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServidorConexao));
            this.btCancelar = new System.Windows.Forms.Button();
            this.btGravar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btTestar = new System.Windows.Forms.Button();
            this.tbConexao = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(2, 68);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 2;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btGravar
            // 
            this.btGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btGravar.Location = new System.Drawing.Point(501, 68);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 1;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btTestar);
            this.groupBox1.Controls.Add(this.tbConexao);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btTestar
            // 
            this.btTestar.Location = new System.Drawing.Point(490, 30);
            this.btTestar.Name = "btTestar";
            this.btTestar.Size = new System.Drawing.Size(75, 23);
            this.btTestar.TabIndex = 1;
            this.btTestar.Text = "Testar";
            this.btTestar.UseVisualStyleBackColor = true;
            this.btTestar.Click += new System.EventHandler(this.btTestar_Click);
            // 
            // tbConexao
            // 
            this.tbConexao.Location = new System.Drawing.Point(9, 32);
            this.tbConexao.MaxLength = 300;
            this.tbConexao.Name = "tbConexao";
            this.tbConexao.Size = new System.Drawing.Size(475, 20);
            this.tbConexao.TabIndex = 0;
            this.tbConexao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbConexao_KeyDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 13);
            this.label22.TabIndex = 9;
            this.label22.Text = "Conexão";
            // 
            // ServidorConexao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 94);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServidorConexao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexão do Banco de Dados";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btTestar;
        private System.Windows.Forms.TextBox tbConexao;
        private System.Windows.Forms.Label label22;
    }
}