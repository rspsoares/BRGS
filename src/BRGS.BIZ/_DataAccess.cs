using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BRGS.Entity;

namespace BRGS.BIZ
{
    public class DataAccess
    {        
        //private string strConn = ConfigurationManager.ConnectionStrings["dbConn"].ToString().Replace(@"\\", @"\");
        //private readonly string strConn = "Server=JRoberto-PC;Database=BRGS;Network Library=DBMSSOCN;Initial Catalog=BRGS;User Id=sa;Password=brgs2013;";        
        //private readonly string strConn = "Server=BSI006563\\SQLEXPRESS;Database=BRGS;Network Library=DBMSSOCN;Initial Catalog=BRGS;User Id=sa;Password=brgs2013;";
        //private readonly string strConn = "Server=localhost\\SQLEXPRESS;Network Library=DBMSSOCN;Initial Catalog=BRGS;User Id=sa;Password=brgs2013;";

        public DataAccess()
        {

        }

        public void Executar(string proc, Dictionary<string, string> parametros)
        {
            using (SqlConnection sqlConn = new SqlConnection(Parametrizacao.servidor_Conexao))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(proc, sqlConn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var parametro in parametros)
                        cmd.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));

                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        public void ExecutarTransacao(List<_Transacao> lstComandos)
        {
            string itemProc = string.Empty;
            Dictionary<string, string> itemParametros = new Dictionary<string, string>();

            using (SqlConnection sqlConn = new SqlConnection(Parametrizacao.servidor_Conexao))
            {
                try
                { 
                    sqlConn.Open();
                    SqlTransaction transaction = sqlConn.BeginTransaction(IsolationLevel.ReadCommitted);

                    try
                    {
                        foreach (_Transacao itemComando in lstComandos)
                        {
                            SqlCommand cmd = new SqlCommand(itemComando.nomeProcedure, sqlConn, transaction);
                            cmd.CommandType = CommandType.StoredProcedure;

                            foreach (var parametro in itemComando.lstParametros)
                                cmd.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        transaction.Dispose();
                        transaction = null;
                    }

                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Executar(string proc, Dictionary<string, byte[]> parametros)
        {
            using (SqlConnection sqlConn = new SqlConnection(Parametrizacao.servidor_Conexao))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(proc, sqlConn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var parametro in parametros)
                        cmd.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));

                    cmd.ExecuteNonQuery();
                    sqlConn.Close();                    
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet Pesquisar(string proc, Dictionary<string, string> parametros)
        {           
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dsRetorno = new DataSet();

            using (SqlConnection sqlConn = new SqlConnection(Parametrizacao.servidor_Conexao))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(proc, sqlConn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var parametro in parametros)
                        cmd.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));

                    da = new SqlDataAdapter(cmd);
                    dsRetorno = new DataSet();
                    da.Fill(dsRetorno, "dtRetorno");

                    sqlConn.Close();
                    return dsRetorno;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }      
    }
}
