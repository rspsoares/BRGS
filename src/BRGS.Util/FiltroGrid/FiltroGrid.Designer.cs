namespace BRGS.Util
{
    partial class FiltroGrid
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbPesquisaCampo = new System.Windows.Forms.ComboBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.tbPesquisaValor = new System.Windows.Forms.TextBox();
            this.tbData = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Controls.Add(this.tbPesquisaValor, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbPesquisaCampo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btPesquisar, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbData, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 29);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // cbPesquisaCampo
            // 
            this.cbPesquisaCampo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbPesquisaCampo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPesquisaCampo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPesquisaCampo.FormattingEnabled = true;
            this.cbPesquisaCampo.Location = new System.Drawing.Point(5, 4);
            this.cbPesquisaCampo.Name = "cbPesquisaCampo";
            this.cbPesquisaCampo.Size = new System.Drawing.Size(125, 21);
            this.cbPesquisaCampo.TabIndex = 1;
            this.cbPesquisaCampo.SelectedIndexChanged += new System.EventHandler(this.cbPesquisaCampo_SelectedIndexChanged);
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btPesquisar.Location = new System.Drawing.Point(707, 3);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(81, 23);
            this.btPesquisar.TabIndex = 27;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // tbPesquisaValor
            // 
            this.tbPesquisaValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPesquisaValor.Location = new System.Drawing.Point(261, 4);
            this.tbPesquisaValor.Name = "tbPesquisaValor";
            this.tbPesquisaValor.Size = new System.Drawing.Size(439, 20);
            this.tbPesquisaValor.TabIndex = 24;
            this.tbPesquisaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbData
            // 
            this.tbData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbData.Location = new System.Drawing.Point(141, 4);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(110, 20);
            this.tbData.TabIndex = 26;
            this.tbData.Visible = false;
            // 
            // FiltroGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FiltroGrid";
            this.Size = new System.Drawing.Size(799, 35);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ComboBox cbPesquisaCampo;
        public System.Windows.Forms.Button btPesquisar;
        public System.Windows.Forms.TextBox tbPesquisaValor;
        public System.Windows.Forms.DateTimePicker tbData;

    }
}
