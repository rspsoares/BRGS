using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRGS.BIZ;
using BRGS.Entity;
using BRGS.UI;
using BRGS.UI.Relatorios;
using BRGS.Util;
using CrystalDecisions.CrystalReports.Engine;

namespace BRGS.UI
{
    public partial class mdiBRGS : Form
    {
        private HelperUI helperUI = new HelperUI();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public mdiBRGS()
        {
            InitializeComponent();
        }       

        private void mdiBRGS_Load(object sender, EventArgs e)
        {
            try
            {              
                if (this.ObterStringConnection())
                {
                    Login form = new Login();
                    form.ShowDialog();
                    form.Activate();

                    if (UsuarioLogado.idUsuario > 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.CarregarPermissoesUsuario();
                        this.statusStrip.Visible = true;
                        this.tsUsuario.Text = UsuarioLogado.Nome;                       
                    }
                    else                    
                        this.BloquearMenus();
                }
                else                
                    this.BloquearMenus();                  
            }
            catch (SqlException)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogErro logErro = new LogErro()
                {
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(logErro);
            }

            this.Cursor = Cursors.Default;
        }

        private void CarregarPermissoesUsuario()
        {
            List<UsuarioPermissoes> lstPermissoes = new List<UsuarioPermissoes>();

            if (UsuarioLogado.dataPublicacao != DateTime.MinValue && (DateTime.Now - UsuarioLogado.dataPublicacao).Days > 25)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BloquearMenus();
                return;
            }

            lstPermissoes = UsuarioLogado.lstPermissoes.Where(cont => cont.nomeFormulario == this.Name).ToList();
            helper.VerificaPermissaoAcessoObjetosMenu(menuStrip1, lstPermissoes);          
        }

        private bool ObterStringConnection()
        {
            string strConnCript = string.Empty;
            string strConn = string.Empty;
            bool sucesso = false;

            if (!helper.ObterArquivoConexao())
            {
                MessageBox.Show("Arquivo de configuração do acesso ao Banco de Dados não encontrado ou está corrompido. Favor informar os dados de conexão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                using (ServidorConexao formConexao = new ServidorConexao())
                {
                    DialogResult dr = formConexao.ShowDialog();
                    sucesso = dr == DialogResult.OK;
                }
            }
            else
                sucesso = true;

            return sucesso;
        }

        private void BloquearMenus()
        {
            menuStrip1.Enabled = false;            
        }

        private void tabTelas_DoubleClick(object sender, EventArgs e)
        {
            Form formAberto = new Form();

            formAberto = (Form)tabTelas.TabPages[tabTelas.SelectedIndex].Controls[0];
            formAberto.Close();
            formAberto.Dispose();

            tabTelas.TabPages.RemoveAt(tabTelas.SelectedIndex);
        }       

        private void rbEngenharia_Obras_Consulta_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Obras"), new ObraConsulta()); 
        }

        private void rbEngenharia_Despesas_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Despesas"), new DespesaConsulta()); 
        }

        private void rbEngenharia_CentrosCustos_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Centros de Custos"), new CentroCustoConsulta()); 
        }

        private void rbEngenharia_UEN_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de UEN's"), new UENConsulta()); 
        }

        private void rbFinanceiro_NFConsulta_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Notas Fiscais"), new NotaFiscalConsulta()); 
        }

        private void rbFinanceiro_NFEmissao_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Emissão de Notas Fiscais"), new NotaFiscalManutencao(new NotaFiscal())); 
        }

        private void rbAdministrativo_Clientes_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Clientes"), new ClienteConsulta()); 
        }

        private void rbFinanceiro_NFRelatorio_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Relatório de Notas Fiscais"), new NotaFiscalRelatorio()); 
        }

        private void rbFinanceiro_OPConsulta_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Ordem de Pagamento"), new OrdemPagamentoConsulta()); 
        }

        private void rbEngenharia_Obras_Relatorio_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Relatório de Obras"), new ObraRelatorio()); 
        }

        private void rbSeguranca_Usuarios_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Usuários"), new UsuarioConsulta()); 
        }

        private void rbAdministrativo_Atividades_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Atividades"), new AtividadeConsulta()); 
        }

        private void rbAdministrativo_Categorias_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Categorias"), new CategoriaConsulta()); 
        }

        private void rbEngenharia_Fases_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Fases"), new FaseConsulta()); 
        }

        private void rbFinanceiro_OPRelatorio_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Relatório de Ordens de Pagamentos Emitidas"), new OrdemPagamentoRelatorio()); 
        }

        private void rbAdministrativo_Feriados_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Feriados"), new FeriadoConsulta()); 
        }

        private void rbFinanceiro_RelatorioGastos_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Relatório de OP - Gastos em Obras"), new OrdemPagamentoRelatorioGastos()); 
        }

        private void rbAdministrativo_Fornecedores_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Fornecedores"), new FornecedorConsulta()); 
        }

        private void rbTransporte_Veiculo_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Veículos"), new VeiculoConsulta()); 
        }

        private void rbTransporte_Motorista_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Motoristas"), new MotoristaConsulta()); 
        }

        private void rbTransporte_Abastecimento_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Abastecimentos"), new AbastecimentoConsulta()); 
        }

        private void rbTransporte_Frete_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Fretes"), new FreteConsulta()); 
        }

        private void rbSeguranca_Auditoria_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Auditoria"), new AuditoriaConsulta()); 
        }

        private void rbTransporte_FreteRelatorio_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Relatório de Fretes"), new FreteRelatorio()); 
        }

        private void rbTransporte_Manutencao_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Manutenções"), new ManutencaoConsulta()); 
        }

        private void rbTransporte_Multa_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Multas"), new MultaConsulta()); 
        }

        private void rbTransporte_Gravidade_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Gravidades de Multas"), new MultaGravidadeConsulta()); 
        }

        private void rbTransporte_Uso_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Usos dos Veículos"), new UsoVeiculosConsulta()); 
        }

        private void rbTransporte_Ocorrencia_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Consulta de Ocorrências de Multas"), new MultaOcorrenciaConsulta()); 
        }

        private void rbSeguranca_Parametrizacao_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Parametrização"), new ParametrizacaoManutencao()); 
        }

        private void rbAdministrativo_Empresa_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Cadastro de Empresas"), new EmpresaConsulta());
        }

        private void tabTelas_MouseUp(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Right)
            {         
                for (int i = 0; i < tabTelas.TabCount; i++)
                {             
                    Rectangle r = tabTelas.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {                 
                        Form formAberto = new Form();

                        formAberto = (Form)tabTelas.TabPages[i].Controls[0];
                        formAberto.Close();
                        formAberto.Dispose();

                        tabTelas.TabPages.RemoveAt(i);
                    }
                }
            }
        }

        private void rbFinanceiro_RelatorioGastosFixos_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Relatório de OP - Gastos Fixos"), new OrdemPagamentoRelatorioGastoFixo());
        }

        private void rbEngenharia_Obras_Relatorio_Consolidado_Click(object sender, EventArgs e)
        {
            helperUI.AbrirNovaAba(new TabPage("Relatório de Obras - Consolidado"), new ObrasRelatorioConsolidado()); 
        }                
    }
}
