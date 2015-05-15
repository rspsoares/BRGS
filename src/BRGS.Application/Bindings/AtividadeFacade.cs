using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace BRGS.Application.Bindings
{
    public class AtividadeFacade : IAtividadeFacade
    {
        private SqlConnection conn;

        public virtual List<Atividade> Pesquisar(Atividade atividade)
        {
            List<Atividade> lstAtividades = new List<Atividade>();
            
            try
            {
                var param = new DynamicParameters();
                param.Add("@idAtividade", atividade.idAtividade.Equals(0) ? null : atividade.idAtividade.ToString());
                param.Add("@Descricao", string.IsNullOrEmpty(atividade.Descricao) ? null : atividade.Descricao);
                param.Add("@UnitTest", atividade.UnitTest.Equals(0) ? null : atividade.UnitTest.ToString());

                conn = new SqlConnection(Parametrizacao.servidor_Conexao);

                using (conn)
                {
                    conn.Open();

                    lstAtividades = conn.Query<Atividade>("SP_ATIVIDADES_CONSULTAR", param, null,true,null,CommandType.StoredProcedure).ToList();
         
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }

            return new List<Atividade>();
        }

        public virtual string Incluir(Atividade atividade, out int idAtividade)
        {
            idAtividade = 0;
            return "";
        }

        public virtual string Alterar(Atividade atividadeOriginal, Atividade atividadeAtualizada)
        {
            return "";
        }

        public virtual string ValidarExclusao(Atividade atividade)
        {

            return "";
        }

        public virtual string Excluir(Atividade atividade)
        {
            return "";
        
        }
    }
}
