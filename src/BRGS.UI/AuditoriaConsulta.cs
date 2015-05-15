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
using BRGS.Util;

namespace BRGS.UI
{
    public partial class AuditoriaConsulta : Form
    {
        List<Atividade> lstAtividadeLog = new List<Atividade>();
        List<Categoria> lstCategoriaLog = new List<Categoria>();

        private BIZAuditoria bizAuditoria = new BIZAuditoria();      
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public AuditoriaConsulta()
        {
            InitializeComponent();
        }

        private void AuditoriaConsulta_Load(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.CarregarAuditorias();
            }
            catch (SqlException)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void CarregarAuditorias()
        {            
            this.CarregarAtividades();
            this.CarregarCategorias();


        }

        private void LimparGrid(DataGridView grid)
        {
            while (grid.Rows.Count > 0)
                grid.Rows.RemoveAt(0);
        }

        private void CarregarAtividades()
        {
            List<Atividade> lstMaster = new List<Atividade>();

            lstAtividadeLog = bizAuditoria.PesquisarAuditoriaAtividade(out lstMaster);

            if (lstAtividadeLog.Count == 0)
                return;

            this.LimparGrid(gvAtividades);

            foreach (Atividade item in lstMaster)
            {
                gvAtividades.Rows.Add(new object[] 
                {
                    item.idAtividade, 
                    item.Descricao
                });
            }            
        }

        private void gvAtividades_SelectionChanged(object sender, EventArgs e)
        {
            int linhaGrid = 0;
            int id = 0;

            if (gvAtividades.RowCount == 0)
                return;

            linhaGrid = gvAtividades.SelectedCells[0].RowIndex;
            id = int.Parse(gvAtividades[0, linhaGrid].Value.ToString());

            this.LimparGrid(gvAtividadesLog);

            gvAtividadesLog.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            foreach (Atividade item in lstAtividadeLog.Where(x => x.idAtividade == id).OrderBy(x => x.dataAlteracao).ToList())
            {
                gvAtividadesLog.Rows.Add(new object[] 
                {
                    item.idLog,
                    item.idAtividade, 
                    item.Descricao,
                    item.nomeUsuario,
                    item.dataAlteracao,
                    item.Acao
                });
            }
        }

        private void CarregarCategorias()
        {
            List<Categoria> lstMaster = new List<Categoria>();

            lstCategoriaLog = bizAuditoria.PesquisarAuditoriaCategoria(out lstMaster);

            if (lstCategoriaLog.Count == 0)
                return;

            this.LimparGrid(gvCategorias);

            foreach (Categoria item in lstMaster)
            {
                gvCategorias.Rows.Add(new object[] 
                {
                    item.idCategoria, 
                    item.Descricao
                });
            }
        }

        private void gvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            int linhaGrid = 0;
            int id = 0;

            if (gvCategorias.RowCount == 0)
                return;

            linhaGrid = gvCategorias.SelectedCells[0].RowIndex;
            id = int.Parse(gvCategorias[0, linhaGrid].Value.ToString());

            this.LimparGrid(gvCategoriasLog);

            gvCategoriasLog.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            foreach (Categoria item in lstCategoriaLog.Where(x => x.idCategoria == id).OrderBy(x => x.dataAlteracao).ToList())
            {
                gvCategoriasLog.Rows.Add(new object[] 
                {
                    item.idLog,
                    item.idCategoria, 
                    item.Descricao,
                    item.nomeUsuario,
                    item.dataAlteracao,
                    item.Acao
                });
            }
        }
    }
}
