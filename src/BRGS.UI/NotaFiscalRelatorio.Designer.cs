namespace BRGS.UI
{
    partial class NotaFiscalRelatorio
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbResumido = new System.Windows.Forms.RadioButton();
            this.rbCompleto = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbDesc = new System.Windows.Forms.RadioButton();
            this.rbAsc = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbDataPagamento = new System.Windows.Forms.RadioButton();
            this.rbEvento = new System.Windows.Forms.RadioButton();
            this.rbCliente = new System.Windows.Forms.RadioButton();
            this.rbDataEmissao = new System.Windows.Forms.RadioButton();
            this.rbNumeroNF = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTipoNota = new System.Windows.Forms.ComboBox();
            this.chkTipo = new System.Windows.Forms.CheckBox();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.cbEmpresas = new System.Windows.Forms.ComboBox();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.optNao = new System.Windows.Forms.RadioButton();
            this.optSim = new System.Windows.Forms.RadioButton();
            this.chkPaga = new System.Windows.Forms.CheckBox();
            this.chkDataEmissao = new System.Windows.Forms.CheckBox();
            this.chkEmpresa = new System.Windows.Forms.CheckBox();
            this.lbAte = new System.Windows.Forms.Label();
            this.btVisualizar = new System.Windows.Forms.Button();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.optAtivo = new System.Windows.Forms.RadioButton();
            this.optCancelado = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tableLayoutPanel1);
            this.groupBox8.Location = new System.Drawing.Point(6, 10);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(629, 49);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Tipo";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rbResumido, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbCompleto, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(617, 24);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rbResumido
            // 
            this.rbResumido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbResumido.AutoSize = true;
            this.rbResumido.Checked = true;
            this.rbResumido.Location = new System.Drawing.Point(118, 3);
            this.rbResumido.Name = "rbResumido";
            this.rbResumido.Size = new System.Drawing.Size(72, 17);
            this.rbResumido.TabIndex = 0;
            this.rbResumido.TabStop = true;
            this.rbResumido.Text = "Resumido";
            this.rbResumido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbResumido.UseVisualStyleBackColor = true;
            // 
            // rbCompleto
            // 
            this.rbCompleto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbCompleto.AutoSize = true;
            this.rbCompleto.Location = new System.Drawing.Point(428, 3);
            this.rbCompleto.Name = "rbCompleto";
            this.rbCompleto.Size = new System.Drawing.Size(69, 17);
            this.rbCompleto.TabIndex = 1;
            this.rbCompleto.Text = "Completo";
            this.rbCompleto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCompleto.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(6, 246);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(629, 75);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordenação";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbDesc);
            this.groupBox5.Controls.Add(this.rbAsc);
            this.groupBox5.Location = new System.Drawing.Point(429, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(190, 47);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Direção";
            // 
            // rbDesc
            // 
            this.rbDesc.AutoSize = true;
            this.rbDesc.Location = new System.Drawing.Point(94, 19);
            this.rbDesc.Name = "rbDesc";
            this.rbDesc.Size = new System.Drawing.Size(89, 17);
            this.rbDesc.TabIndex = 1;
            this.rbDesc.Text = "Descendente";
            this.rbDesc.UseVisualStyleBackColor = true;
            // 
            // rbAsc
            // 
            this.rbAsc.AutoSize = true;
            this.rbAsc.Checked = true;
            this.rbAsc.Location = new System.Drawing.Point(6, 19);
            this.rbAsc.Name = "rbAsc";
            this.rbAsc.Size = new System.Drawing.Size(82, 17);
            this.rbAsc.TabIndex = 0;
            this.rbAsc.TabStop = true;
            this.rbAsc.Text = "Ascendente";
            this.rbAsc.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbDataPagamento);
            this.groupBox4.Controls.Add(this.rbEvento);
            this.groupBox4.Controls.Add(this.rbCliente);
            this.groupBox4.Controls.Add(this.rbDataEmissao);
            this.groupBox4.Controls.Add(this.rbNumeroNF);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(417, 47);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Campos";
            // 
            // rbDataPagamento
            // 
            this.rbDataPagamento.AutoSize = true;
            this.rbDataPagamento.Location = new System.Drawing.Point(310, 20);
            this.rbDataPagamento.Name = "rbDataPagamento";
            this.rbDataPagamento.Size = new System.Drawing.Size(105, 17);
            this.rbDataPagamento.TabIndex = 6;
            this.rbDataPagamento.Text = "Data Pagamento";
            this.rbDataPagamento.UseVisualStyleBackColor = true;
            // 
            // rbEvento
            // 
            this.rbEvento.AutoSize = true;
            this.rbEvento.Location = new System.Drawing.Point(245, 20);
            this.rbEvento.Name = "rbEvento";
            this.rbEvento.Size = new System.Drawing.Size(59, 17);
            this.rbEvento.TabIndex = 5;
            this.rbEvento.Text = "Evento";
            this.rbEvento.UseVisualStyleBackColor = true;
            // 
            // rbCliente
            // 
            this.rbCliente.AutoSize = true;
            this.rbCliente.Location = new System.Drawing.Point(182, 20);
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.Size = new System.Drawing.Size(57, 17);
            this.rbCliente.TabIndex = 4;
            this.rbCliente.Text = "Cliente";
            this.rbCliente.UseVisualStyleBackColor = true;
            // 
            // rbDataEmissao
            // 
            this.rbDataEmissao.AutoSize = true;
            this.rbDataEmissao.Location = new System.Drawing.Point(91, 20);
            this.rbDataEmissao.Name = "rbDataEmissao";
            this.rbDataEmissao.Size = new System.Drawing.Size(90, 17);
            this.rbDataEmissao.TabIndex = 3;
            this.rbDataEmissao.Text = "Data Emissão";
            this.rbDataEmissao.UseVisualStyleBackColor = true;
            // 
            // rbNumeroNF
            // 
            this.rbNumeroNF.AutoSize = true;
            this.rbNumeroNF.Checked = true;
            this.rbNumeroNF.Location = new System.Drawing.Point(6, 19);
            this.rbNumeroNF.Name = "rbNumeroNF";
            this.rbNumeroNF.Size = new System.Drawing.Size(79, 17);
            this.rbNumeroNF.TabIndex = 2;
            this.rbNumeroNF.TabStop = true;
            this.rbNumeroNF.Text = "Número NF";
            this.rbNumeroNF.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.chkStatus);
            this.groupBox2.Controls.Add(this.cbTipoNota);
            this.groupBox2.Controls.Add(this.chkTipo);
            this.groupBox2.Controls.Add(this.dtpAte);
            this.groupBox2.Controls.Add(this.dtpDe);
            this.groupBox2.Controls.Add(this.cbClientes);
            this.groupBox2.Controls.Add(this.cbEmpresas);
            this.groupBox2.Controls.Add(this.chkCliente);
            this.groupBox2.Controls.Add(this.chkPaga);
            this.groupBox2.Controls.Add(this.chkDataEmissao);
            this.groupBox2.Controls.Add(this.chkEmpresa);
            this.groupBox2.Controls.Add(this.lbAte);
            this.groupBox2.Location = new System.Drawing.Point(6, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 175);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // cbTipoNota
            // 
            this.cbTipoNota.Enabled = false;
            this.cbTipoNota.FormattingEnabled = true;
            this.cbTipoNota.Location = new System.Drawing.Point(97, 126);
            this.cbTipoNota.Name = "cbTipoNota";
            this.cbTipoNota.Size = new System.Drawing.Size(121, 21);
            this.cbTipoNota.TabIndex = 22;
            this.cbTipoNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTipoNota_KeyPress);
            // 
            // chkTipo
            // 
            this.chkTipo.AutoSize = true;
            this.chkTipo.Location = new System.Drawing.Point(6, 128);
            this.chkTipo.Name = "chkTipo";
            this.chkTipo.Size = new System.Drawing.Size(73, 17);
            this.chkTipo.TabIndex = 21;
            this.chkTipo.Text = "Tipo Nota";
            this.chkTipo.UseVisualStyleBackColor = true;
            this.chkTipo.CheckedChanged += new System.EventHandler(this.chkTipo_CheckedChanged);
            // 
            // dtpAte
            // 
            this.dtpAte.Enabled = false;
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(230, 71);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(99, 20);
            this.dtpAte.TabIndex = 20;
            // 
            // dtpDe
            // 
            this.dtpDe.Enabled = false;
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(97, 71);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(99, 20);
            this.dtpDe.TabIndex = 19;
            // 
            // cbClientes
            // 
            this.cbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClientes.Enabled = false;
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(97, 44);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(526, 21);
            this.cbClientes.TabIndex = 3;
            this.cbClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCliente_KeyDown);
            // 
            // cbEmpresas
            // 
            this.cbEmpresas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEmpresas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEmpresas.Enabled = false;
            this.cbEmpresas.FormattingEnabled = true;
            this.cbEmpresas.Location = new System.Drawing.Point(97, 17);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(526, 21);
            this.cbEmpresas.TabIndex = 1;
            this.cbEmpresas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEmpresa_KeyDown);
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Location = new System.Drawing.Point(6, 46);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(58, 17);
            this.chkCliente.TabIndex = 2;
            this.chkCliente.Text = "Cliente";
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // optNao
            // 
            this.optNao.AutoSize = true;
            this.optNao.Enabled = false;
            this.optNao.Location = new System.Drawing.Point(55, 5);
            this.optNao.Name = "optNao";
            this.optNao.Size = new System.Drawing.Size(45, 17);
            this.optNao.TabIndex = 9;
            this.optNao.Text = "Não";
            this.optNao.UseVisualStyleBackColor = true;
            // 
            // optSim
            // 
            this.optSim.AutoSize = true;
            this.optSim.Checked = true;
            this.optSim.Enabled = false;
            this.optSim.Location = new System.Drawing.Point(10, 5);
            this.optSim.Name = "optSim";
            this.optSim.Size = new System.Drawing.Size(42, 17);
            this.optSim.TabIndex = 8;
            this.optSim.TabStop = true;
            this.optSim.Text = "Sim";
            this.optSim.UseVisualStyleBackColor = true;
            // 
            // chkPaga
            // 
            this.chkPaga.AutoSize = true;
            this.chkPaga.Location = new System.Drawing.Point(6, 101);
            this.chkPaga.Name = "chkPaga";
            this.chkPaga.Size = new System.Drawing.Size(51, 17);
            this.chkPaga.TabIndex = 7;
            this.chkPaga.Text = "Paga";
            this.chkPaga.UseVisualStyleBackColor = true;
            this.chkPaga.CheckedChanged += new System.EventHandler(this.chkPaga_CheckedChanged);
            // 
            // chkDataEmissao
            // 
            this.chkDataEmissao.AutoSize = true;
            this.chkDataEmissao.Location = new System.Drawing.Point(6, 73);
            this.chkDataEmissao.Name = "chkDataEmissao";
            this.chkDataEmissao.Size = new System.Drawing.Size(91, 17);
            this.chkDataEmissao.TabIndex = 4;
            this.chkDataEmissao.Text = "Data Emissão";
            this.chkDataEmissao.UseVisualStyleBackColor = true;
            this.chkDataEmissao.CheckedChanged += new System.EventHandler(this.chkDataEmissao_CheckedChanged);
            // 
            // chkEmpresa
            // 
            this.chkEmpresa.AutoSize = true;
            this.chkEmpresa.Location = new System.Drawing.Point(6, 19);
            this.chkEmpresa.Name = "chkEmpresa";
            this.chkEmpresa.Size = new System.Drawing.Size(67, 17);
            this.chkEmpresa.TabIndex = 0;
            this.chkEmpresa.Text = "Empresa";
            this.chkEmpresa.UseVisualStyleBackColor = true;
            this.chkEmpresa.CheckedChanged += new System.EventHandler(this.chkEmpresa_CheckedChanged);
            // 
            // lbAte
            // 
            this.lbAte.AutoSize = true;
            this.lbAte.Location = new System.Drawing.Point(202, 74);
            this.lbAte.Name = "lbAte";
            this.lbAte.Size = new System.Drawing.Size(22, 13);
            this.lbAte.TabIndex = 18;
            this.lbAte.Text = "até";
            // 
            // btVisualizar
            // 
            this.btVisualizar.Location = new System.Drawing.Point(572, 339);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btVisualizar.TabIndex = 1;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.UseVisualStyleBackColor = true;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Location = new System.Drawing.Point(6, 152);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(56, 17);
            this.chkStatus.TabIndex = 23;
            this.chkStatus.Text = "Status";
            this.chkStatus.UseVisualStyleBackColor = true;
            this.chkStatus.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);
            // 
            // optAtivo
            // 
            this.optAtivo.AutoSize = true;
            this.optAtivo.Checked = true;
            this.optAtivo.Enabled = false;
            this.optAtivo.Location = new System.Drawing.Point(6, 0);
            this.optAtivo.Name = "optAtivo";
            this.optAtivo.Size = new System.Drawing.Size(49, 17);
            this.optAtivo.TabIndex = 24;
            this.optAtivo.TabStop = true;
            this.optAtivo.Text = "Ativo";
            this.optAtivo.UseVisualStyleBackColor = true;
            // 
            // optCancelado
            // 
            this.optCancelado.AutoSize = true;
            this.optCancelado.Enabled = false;
            this.optCancelado.Location = new System.Drawing.Point(62, 0);
            this.optCancelado.Name = "optCancelado";
            this.optCancelado.Size = new System.Drawing.Size(76, 17);
            this.optCancelado.TabIndex = 25;
            this.optCancelado.Text = "Cancelado";
            this.optCancelado.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.optCancelado);
            this.panel1.Controls.Add(this.optAtivo);
            this.panel1.Location = new System.Drawing.Point(91, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 17);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.optNao);
            this.panel2.Controls.Add(this.optSim);
            this.panel2.Location = new System.Drawing.Point(87, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(118, 30);
            this.panel2.TabIndex = 27;
            // 
            // NotaFiscalRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 366);
            this.Controls.Add(this.btVisualizar);
            this.Controls.Add(this.groupBox1);
            this.Name = "NotaFiscalRelatorio";
            this.Text = "NotaFiscalServicoRelatorio";
            this.Load += new System.EventHandler(this.NotaFiscalRelatorio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbDataEmissao;
        private System.Windows.Forms.RadioButton rbNumeroNF;
        private System.Windows.Forms.RadioButton rbEvento;
        private System.Windows.Forms.RadioButton rbCliente;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbDesc;
        private System.Windows.Forms.RadioButton rbAsc;
        private System.Windows.Forms.RadioButton rbDataPagamento;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rbResumido;
        private System.Windows.Forms.RadioButton rbCompleto;
        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.ComboBox cbEmpresas;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.RadioButton optNao;
        private System.Windows.Forms.RadioButton optSim;
        private System.Windows.Forms.CheckBox chkPaga;
        private System.Windows.Forms.CheckBox chkDataEmissao;
        private System.Windows.Forms.CheckBox chkEmpresa;
        private System.Windows.Forms.Label lbAte;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.ComboBox cbTipoNota;
        private System.Windows.Forms.CheckBox chkTipo;
        private System.Windows.Forms.RadioButton optCancelado;
        private System.Windows.Forms.RadioButton optAtivo;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}