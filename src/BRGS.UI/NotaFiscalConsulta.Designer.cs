namespace BRGS.UI
{
    partial class NotaFiscalConsulta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.cbPesquisaCampo = new System.Windows.Forms.ComboBox();
            this.tbPesquisaValor = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvNFS = new BRGS.Util.SortedDataGridView();
            this.btVisualizar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.idEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empenho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diferenca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvNFS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btPesquisar);
            this.groupBox1.Controls.Add(this.cbPesquisaCampo);
            this.groupBox1.Controls.Add(this.tbPesquisaValor);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro da pesquisa";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(824, 18);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(81, 23);
            this.btPesquisar.TabIndex = 2;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // cbPesquisaCampo
            // 
            this.cbPesquisaCampo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPesquisaCampo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPesquisaCampo.FormattingEnabled = true;
            this.cbPesquisaCampo.Location = new System.Drawing.Point(8, 19);
            this.cbPesquisaCampo.Name = "cbPesquisaCampo";
            this.cbPesquisaCampo.Size = new System.Drawing.Size(132, 21);
            this.cbPesquisaCampo.TabIndex = 0;
            this.cbPesquisaCampo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPesquisaCampo_KeyDown);
            // 
            // tbPesquisaValor
            // 
            this.tbPesquisaValor.Location = new System.Drawing.Point(146, 20);
            this.tbPesquisaValor.Name = "tbPesquisaValor";
            this.tbPesquisaValor.Size = new System.Drawing.Size(672, 20);
            this.tbPesquisaValor.TabIndex = 1;
            this.tbPesquisaValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPesquisaValor_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvNFS);
            this.groupBox2.Location = new System.Drawing.Point(4, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(914, 297);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // gvNFS
            // 
            this.gvNFS.AllowUserToAddRows = false;
            this.gvNFS.AllowUserToDeleteRows = false;
            this.gvNFS.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvNFS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvNFS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvNFS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEmpresa,
            this.Empresa,
            this.Column1,
            this.Numero,
            this.Data,
            this.Cliente,
            this.Empenho,
            this.ValorNota,
            this.ValorPago,
            this.Diferenca,
            this.Column2});
            this.gvNFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvNFS.Location = new System.Drawing.Point(3, 16);
            this.gvNFS.Name = "gvNFS";
            this.gvNFS.ReadOnly = true;
            this.gvNFS.RowHeadersVisible = false;
            this.gvNFS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvNFS.Size = new System.Drawing.Size(908, 278);
            this.gvNFS.TabIndex = 0;
            this.gvNFS.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvNFS_CellFormatting);
            this.gvNFS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvNFS_MouseDoubleClick);
            // 
            // btVisualizar
            // 
            this.btVisualizar.Location = new System.Drawing.Point(840, 356);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btVisualizar.TabIndex = 2;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.UseVisualStyleBackColor = true;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(7, 359);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(75, 23);
            this.btNovo.TabIndex = 3;
            this.btNovo.Text = "Nova";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // idEmpresa
            // 
            this.idEmpresa.HeaderText = "idEmpresa";
            this.idEmpresa.Name = "idEmpresa";
            this.idEmpresa.ReadOnly = true;
            this.idEmpresa.Visible = false;
            // 
            // Empresa
            // 
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tipo Nota";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data Emissão";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Empenho
            // 
            this.Empenho.HeaderText = "Empenho";
            this.Empenho.Name = "Empenho";
            this.Empenho.ReadOnly = true;
            // 
            // ValorNota
            // 
            this.ValorNota.HeaderText = "Valor Nota";
            this.ValorNota.Name = "ValorNota";
            this.ValorNota.ReadOnly = true;
            // 
            // ValorPago
            // 
            this.ValorPago.HeaderText = "Valor Pago";
            this.ValorPago.Name = "ValorPago";
            this.ValorPago.ReadOnly = true;
            // 
            // Diferenca
            // 
            this.Diferenca.HeaderText = "Diferença";
            this.Diferenca.Name = "Diferenca";
            this.Diferenca.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "idNota";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // NotaFiscalConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 388);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.btVisualizar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotaFiscalConsulta";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Controle de Notas Fiscais de Serviço";
            this.Load += new System.EventHandler(this.NotaFiscalServicoConsulta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvNFS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.ComboBox cbPesquisaCampo;
        private System.Windows.Forms.TextBox tbPesquisaValor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.Button btNovo;
        private BRGS.Util.SortedDataGridView gvNFS;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empenho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diferenca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}