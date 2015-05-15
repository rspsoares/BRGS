namespace BRGS.UI
{
    partial class FreteRelatorio
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFretistas = new System.Windows.Forms.ComboBox();
            this.chkFretista = new System.Windows.Forms.CheckBox();
            this.btVisualizar = new System.Windows.Forms.Button();
            this.chkObras = new System.Windows.Forms.CheckBox();
            this.cbObras = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbObras);
            this.groupBox1.Controls.Add(this.chkObras);
            this.groupBox1.Controls.Add(this.cbFretistas);
            this.groupBox1.Controls.Add(this.chkFretista);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // cbFretistas
            // 
            this.cbFretistas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFretistas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFretistas.Enabled = false;
            this.cbFretistas.FormattingEnabled = true;
            this.cbFretistas.Location = new System.Drawing.Point(77, 17);
            this.cbFretistas.Name = "cbFretistas";
            this.cbFretistas.Size = new System.Drawing.Size(425, 21);
            this.cbFretistas.TabIndex = 1;
            this.cbFretistas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFretistas_KeyDown);
            // 
            // chkFretista
            // 
            this.chkFretista.AutoSize = true;
            this.chkFretista.Location = new System.Drawing.Point(11, 19);
            this.chkFretista.Name = "chkFretista";
            this.chkFretista.Size = new System.Drawing.Size(60, 17);
            this.chkFretista.TabIndex = 0;
            this.chkFretista.Text = "Fretista";
            this.chkFretista.UseVisualStyleBackColor = true;
            this.chkFretista.CheckedChanged += new System.EventHandler(this.chkFretista_CheckedChanged);
            // 
            // btVisualizar
            // 
            this.btVisualizar.Location = new System.Drawing.Point(434, 80);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btVisualizar.TabIndex = 1;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.UseVisualStyleBackColor = true;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // chkObras
            // 
            this.chkObras.AutoSize = true;
            this.chkObras.Location = new System.Drawing.Point(11, 46);
            this.chkObras.Name = "chkObras";
            this.chkObras.Size = new System.Drawing.Size(54, 17);
            this.chkObras.TabIndex = 2;
            this.chkObras.Text = "Obras";
            this.chkObras.UseVisualStyleBackColor = true;
            this.chkObras.CheckedChanged += new System.EventHandler(this.chkObras_CheckedChanged);
            // 
            // cbObras
            // 
            this.cbObras.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbObras.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbObras.Enabled = false;
            this.cbObras.FormattingEnabled = true;
            this.cbObras.Location = new System.Drawing.Point(77, 44);
            this.cbObras.Name = "cbObras";
            this.cbObras.Size = new System.Drawing.Size(425, 21);
            this.cbObras.TabIndex = 3;
            this.cbObras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbObras_KeyDown);
            // 
            // FreteRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 109);
            this.Controls.Add(this.btVisualizar);
            this.Controls.Add(this.groupBox1);
            this.Name = "FreteRelatorio";
            this.Text = "FreteRelatorio";
            this.Load += new System.EventHandler(this.FreteRelatorio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbFretistas;
        private System.Windows.Forms.CheckBox chkFretista;
        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.ComboBox cbObras;
        private System.Windows.Forms.CheckBox chkObras;
    }
}