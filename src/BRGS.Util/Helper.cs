using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using BRGS.Entity;
using System.Data.SqlClient;
using System.Drawing;


namespace BRGS.Util
{
    public class Helper
    {
        #region Auditoria

        public Object ObterAlteracoesAuditoria(object objetoOriginal, object objetoAtualizado, Object objetoAuditoria, out bool valorAlterado)
        {
            valorAlterado = false;
            if (objetoOriginal.GetType() == objetoAtualizado.GetType())
            {
                foreach (PropertyInfo propriedadeObjeto in objetoOriginal.GetType().GetProperties())
                {
                    object valorOriginal = propriedadeObjeto.GetValue(objetoOriginal, null);
                    object valorAtualizado = propriedadeObjeto.GetValue(objetoAtualizado, null);

                    if (!Nullable.Equals(valorOriginal,valorAtualizado))
                    {
                        valorAlterado = true;
                        foreach (PropertyInfo propriedadeAuditoria in objetoAuditoria.GetType().GetProperties())
                        {
                            if (propriedadeObjeto.Name == propriedadeAuditoria.Name)
                            {
                                propriedadeObjeto.SetValue(objetoAuditoria, Convert.ChangeType(valorAtualizado, propriedadeObjeto.PropertyType), null);
                                break;
                            }
                        }
                    }
                }
            }

            return objetoAuditoria;
        }

        #endregion

        #region Validações e formatações gerais

        public bool ValidarEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return rg.IsMatch(email);            
        }

        public bool ValidarCPFCNPJ(string cpfCNPJ)
        {
            if (cpfCNPJ.Replace(".", "").Replace("-", "").Replace("/", "").Length == 11)
                return ValidarCPF(cpfCNPJ);
            else
                return ValidarCNPJ(cpfCNPJ);
        }

        public bool ValidarCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
			int[] multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
			int soma;
			int resto;
			string digito;
			string tempCnpj;

			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			
            if (cnpj.Length != 14)
			   return false;

            if (cnpj == "00000000000000")
                return false;
            
            tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			
            for(int i=0; i<12; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			
            resto = (soma % 11);
			
            if ( resto < 2)
			   resto = 0;
			else
			   resto = 11 - resto;
			
            digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			
            for (int i = 0; i < 13; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			
            resto = (soma % 11);
			
            if (resto < 2)
			    resto = 0;
			else
			   resto = 11 - resto;
			
            digito = digito + resto.ToString();

			return cnpj.EndsWith(digito);		
        }

        public bool ValidarCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            long numero;

		    cpf = cpf.Trim();
		    cpf = cpf.Replace(".", "").Replace("-", "");

            if (Int64.TryParse(cpf, out numero) == false)
                return false;

            if (cpf.Length != 11)
		       return false;

            if (cpf == "00000000000")
                return false;
		    
            tempCpf = cpf.Substring(0, 9);
		    soma = 0;

		    for(int i=0; i<9; i++)
		        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
		    
            resto = soma % 11;
		    
            if ( resto < 2 )
		        resto = 0;
		    else
		       resto = 11 - resto;

		    digito = resto.ToString();
		    tempCpf = tempCpf + digito;
		    soma = 0;
		    
            for(int i=0; i<10; i++)
		        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
		    
            resto = soma % 11;
		    
            if (resto < 2)
		       resto = 0;
		    else
		       resto = 11 - resto;
		    
            digito = digito + resto.ToString();
		    
            return cpf.EndsWith(digito);	      
        }


        public string FormatarCPF_CNPJ(string cpfCNPJ)
        {
            string retorno = string.Empty;
            
            retorno = cpfCNPJ.Replace(".", string.Empty).Replace("/", string.Empty).Replace("-", string.Empty);

            switch (retorno.Length)
            {
                case 11:
                    retorno =
                        retorno.Substring(0, 3) + "." +
                        retorno.Substring(3, 3) + "." +
                        retorno.Substring(6, 3) + "-" +
                        retorno.Substring(9, 2);
                    break;
                case 14:
                    retorno =
                        retorno.Substring(0, 2) + "." +
                        retorno.Substring(2, 3) + "." +
                        retorno.Substring(5, 3) + "/" +
                        retorno.Substring(8, 4) + "-" +
                        retorno.Substring(12, 2);
                    break;                
            }

            return retorno;
        }

        public string FormatarValorMoeda(string valor)
        {
            string valorMoeda = string.Empty;
            decimal valorAux = decimal.Zero; 

            if (valor != string.Empty)
            {
                valor = decimal.TryParse(valor, out valorAux) ? valor : "0,00";
                valorMoeda = string.Format(CultureInfo.CreateSpecificCulture("pt-BR"), "{0:C}", decimal.Parse(valor)).Replace("R$ ", string.Empty);
            }
             
            else
                valorMoeda = "0,00";

            return valorMoeda;
        }
        
        public string ValidarHora(string hora)
        {
            string horaRetorno = string.Empty;

            string[] horaValidacao = hora.Split(char.Parse(":"));

            if (horaValidacao[0].Trim().Length == 0)
            {
                horaValidacao[0] = "00";
                hora = "00" + hora.Substring(2);
            }

            if (horaValidacao[1].Trim().Length == 0)
            {
                hora = hora.Substring(0, 3) + "00";
                horaValidacao[1] = "00";
            }

            if (int.Parse(horaValidacao[0]) > 24 || int.Parse(horaValidacao[1]) > 59)
                horaRetorno = "00:00";
            else
                horaRetorno = hora;

            return horaRetorno; 
        }

        #endregion

        #region Funções gerais

        public DateTime CalcularDataVencimento(DateTime dataInicial, int qtdMeses, List<Feriado> lstFeriados)
        {
            DateTime dataVencimento = new DateTime();           

            dataVencimento = dataInicial.AddMonths(qtdMeses);

            while (true)
            {
                if (dataVencimento.DayOfWeek == DayOfWeek.Saturday || dataVencimento.DayOfWeek == DayOfWeek.Sunday || lstFeriados.Exists(x => x.Dia == dataVencimento.Day && x.Mes == dataVencimento.Month))
                    dataVencimento = dataVencimento.AddDays(1);
                else
                    break;
            }

            return dataVencimento;
        }
        
        public List<string> RetornarUF()
        {
            List<string> lstUF = new List<string>();
         
            lstUF.Add("AC");            
            lstUF.Add("AL");
            lstUF.Add("AP");
            lstUF.Add("AM");            
            lstUF.Add("BA");            
            lstUF.Add("CE");            
            lstUF.Add("DF");            
            lstUF.Add("ES");            
            lstUF.Add("GO");            
            lstUF.Add("MA");            
            lstUF.Add("MT");            
            lstUF.Add("MS");            
            lstUF.Add("MG");            
            lstUF.Add("PA");            
            lstUF.Add("PB");            
            lstUF.Add("PR");            
            lstUF.Add("PE");            
            lstUF.Add("PI");            
            lstUF.Add("RJ");            
            lstUF.Add("RN");            
            lstUF.Add("RS");            
            lstUF.Add("RO");            
            lstUF.Add("RR");            
            lstUF.Add("SC");            
            lstUF.Add("SP");            
            lstUF.Add("SE");
            lstUF.Add("TO");

            return lstUF;
        }

        public DataTable ConverterListaDataTable<T>(IList<T> lista)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable tabelaRetorno = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];

                if (!prop.PropertyType.FullName.Contains("List"))
                    tabelaRetorno.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] valores = new object[props.Count];

            foreach (T item in lista)
            {
                for (int i = 0; i < valores.Length; i++)
                    valores[i] = props[i].GetValue(item);

                tabelaRetorno.Rows.Add(valores);
            }

            return tabelaRetorno;
        }

        private byte[] ObterBytesImagem(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
 
        public DataTable AdicionarLogotipoDataTable(DataTable dt, Image imagemLogo)
        {                        
            dt.Columns.Add("Logotipo", Type.GetType("System.Byte[]"));

            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["Logotipo"] = this.ObterBytesImagem(imagemLogo);
            
            return dt;            
        }

        public void CarregarComboBox(ComboBox combo, BindingSource bs, List<object> lstItens, string displayMember, string valueMember)
        {
            combo.AutoCompleteMode = AutoCompleteMode.None;
            combo.DataSource = null;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            bs.DataSource = lstItens;
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            combo.DataSource = bs;
        }

        #endregion

        #region Mensagens de erro
        
        public string RetornarMensagemPadraoErroAcessoBD()
        {
            return
                "Não foi possível acessar o banco de dados ou executar a instrução." +
                Environment.NewLine +
                "Possíveis causas:" + Environment.NewLine +
                "- Falha na comunicação com o banco de dados;" + Environment.NewLine +
                "- Integridade do banco de dados comprometida.";            
        }

        public string RetornarMensagemPadraoErroGenerico()
        {
            return 
                "Ocorreu um problema na execução dessa operação.";
        }

        #endregion

        #region Banco de Dados

        public string ConcatenarParametrosSQL(Dictionary<string, string> lstParametros)
        {
            string parametros = string.Empty;

            foreach (var parametro in lstParametros)
                parametros += parametro.Key + " = " + parametro.Value + " || ";

            return parametros.Trim();
        }

        public Dictionary<string, string> RetornarComparacoesCampo(string tipoCampo)
        {
            Dictionary<string, string> lstComparacoes = new Dictionary<string, string>();

            switch (tipoCampo)
            {
                case "String":
                    lstComparacoes.Add(" = '", "Igual");
                    lstComparacoes.Add(" != '", "Diferente");
                    lstComparacoes.Add(" Like '%", "Contém");
                    lstComparacoes.Add(" Not Like '%", "Não contém");
                    break;
                case "int":
                case "Int32":
                case "float":
                    lstComparacoes.Add(" = ", "Igual");
                    lstComparacoes.Add(" != ", "Diferente");
                    lstComparacoes.Add(" > ", "Maior");
                    lstComparacoes.Add(" >= ", "Maior ou igual");
                    lstComparacoes.Add(" < ", "Menor");
                    lstComparacoes.Add(" <= ", "Menor ou igual");
                    break;
                case "DateTime":
                    lstComparacoes.Add(" = CONVERT(DATETIME, '", "Igual");
                    lstComparacoes.Add(" != CONVERT(DATETIME, '", "Diferente");
                    lstComparacoes.Add(" > CONVERT(DATETIME, '", "Maior");
                    lstComparacoes.Add(" >= CONVERT(DATETIME, '", "Maior ou igual");
                    lstComparacoes.Add(" < CONVERT(DATETIME, '", "Menor");
                    lstComparacoes.Add(" <= CONVERT(DATETIME, '", "Menor ou igual");
                    break;

                default:
                    break;
            }

            return lstComparacoes;
        }

        public string RetornarComplementoComparacao(string comparacao)
        {
            string complementoComparacao = string.Empty;

            if (comparacao.Contains("Like"))
                complementoComparacao = "%'";
            else if (comparacao.Contains("DATETIME"))
                complementoComparacao = "', 103)";
            else if (comparacao.Contains("'"))
                complementoComparacao = "'";

            return complementoComparacao;
        }

        private string PrepararStringConexao(string enderecoServidor)
        {
            string strConn = string.Empty;

            strConn = enderecoServidor.Replace("\\\\", "\\").Trim();
            strConn = "Server=" + strConn + ";Database=BRGS;Network Library=DBMSSOCN;Initial Catalog=BRGS;User Id=sa;Password=brgs2013;";           

            return strConn;
        }

        public string TestarConexao(string enderecoServidor, out string msgErro)
        {
            string strTesteConn = string.Empty;
            msgErro = string.Empty;

            strTesteConn = this.PrepararStringConexao(enderecoServidor);

            msgErro = this.ValidarStringConnection(strTesteConn);

            if (msgErro == string.Empty)
            {
                using (SqlConnection sqlConn = new SqlConnection(strTesteConn))
                {
                    try
                    { // Abrindo conexão
                        sqlConn.Open();
                        sqlConn.Close();
                        sqlConn.Dispose();
                    }
                    catch
                    {
                        msgErro = "Atenção: Não foi possível conectar ao Banco de Dados.";
                    }
                }
            }

            return strTesteConn;
        }

        private string ValidarStringConnection(string testConn)
        {
            string msgErro = string.Empty;

            try
            {
                var con = new SqlConnectionStringBuilder(testConn);
            }
            catch (KeyNotFoundException)
            {
                msgErro = "Parâmetro não informado.";
            }
            catch (Exception)
            {
                msgErro = "Formato incorreto.";
            }

            return msgErro;
        }

        public void CriarArquivoConexao(string strConn)
        {
            string pastaSigepet = string.Empty;
            string strCripto = string.Empty;

            pastaSigepet = @"C:\BRGS\";

            if (!Directory.Exists(pastaSigepet))
                Directory.CreateDirectory(pastaSigepet);

            strCripto = this.CriptografarTexto(strConn);

            File.WriteAllText(pastaSigepet + @"\DBServer.dat", strCripto);
        }

        public bool ObterArquivoConexao()
        {
            string pastaBRGS = string.Empty;
            string strConnCript = string.Empty;
            string strConn = string.Empty;
            bool sucesso = false;

            pastaBRGS = @"C:\BRGS\";

            if (Directory.Exists(pastaBRGS))
            {
                DirectoryInfo Pasta = new DirectoryInfo(pastaBRGS);
                FileInfo[] arquivoStringConnection = Pasta.GetFiles("DBServer.dat", SearchOption.TopDirectoryOnly);

                if (arquivoStringConnection.Length > 0)
                {
                    String[] linhasArquivo = File.ReadAllLines(arquivoStringConnection[0].FullName);
                    if (linhasArquivo.Length > 0)
                    {
                        if (this.VerificarStringBase64(linhasArquivo[0]))
                        {
                            strConn = this.DescriptografarTexto(linhasArquivo[0]);                            
                            Parametrizacao.servidor_Conexao = strConn;
                            Parametrizacao.servidor_Endereco = strConn.Substring(7, strConn.IndexOf(";", 0) - 7);
                            sucesso = true;
                        }
                        else
                            sucesso = false;
                    }
                    else
                        sucesso = false;
                }
            }
         
            return sucesso;
        }


        public DataTable AdicionarColunaFiltroRelatorio(string filtroRelatorio, DataTable dt)
        {
            if (filtroRelatorio == string.Empty)
                filtroRelatorio = "Sem filtro";
            else if (filtroRelatorio.Substring(filtroRelatorio.Length - 3, 3) == " / ")
                filtroRelatorio = filtroRelatorio.Remove(filtroRelatorio.Length - 3);

            dt.Columns.Add("Filtro");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                    row.SetField("Filtro", filtroRelatorio);
            }
            else
            {
                DataRow row = dt.NewRow();
                row["Filtro"] = filtroRelatorio;
                dt.Rows.Add(row);
            }

            return dt;
        }

        #endregion

        #region E-mail
        
        public string EnviarEmail(string emailDestinatario, string emailRemetente, string emailSenha, string emailAssunto, string emailCorpo, string servidorSMTP, int portaSMTP, int SSL)
        {
            string resultado = string.Empty;

            if (new Ping().Send("www.google.com").Status != IPStatus.Success)            
                return "Sem conexão com a internet";

            resultado = ValidarConfiguracoesEmail(emailRemetente, emailSenha, servidorSMTP, portaSMTP);

            if (resultado != string.Empty)
                return resultado;

            try
            {
                MailAddress destinatario = new MailAddress(emailDestinatario);            
                MailAddress remetente = new MailAddress(emailRemetente);
                MailMessage eMail = new MailMessage(remetente,destinatario);

                eMail.Subject = emailAssunto;
                eMail.Body = emailCorpo;
                eMail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = servidorSMTP;
                smtp.Port = portaSMTP;

                smtp.Credentials = new NetworkCredential(emailRemetente, emailSenha);
                smtp.EnableSsl = SSL == 1 ? true : false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Timeout = 20000;

                smtp.Send(eMail);
            }
            catch (Exception ex)
            {
                resultado = ex.Message.ToString();
            }

            return resultado;
        }

        private string ValidarConfiguracoesEmail(string emailRemetente, string emailSenha, string servidorSMTP, int portaSMTP)
        {
            string Msg = string.Empty;

            if (emailRemetente == string.Empty)
                Msg = "Favor informar o E-mail do remetente";

            if (emailSenha == string.Empty)
                Msg = Msg + Environment.NewLine + "Favor informar a senha do E-mail";

            if (servidorSMTP == string.Empty)
                Msg = Msg + Environment.NewLine + "Favor informar o endereço do Servidor SMTP";

            if (portaSMTP == 0)
                Msg = Msg + Environment.NewLine + "Favor informar a porta do Servidor SMTP";

            return Msg;
        }

        #endregion

        #region Criptografia

        private string initVector = "osenhoreomeudeus";
        private int keysize = 256;
        private string passPhrase = "jeovarafah";

        public string CriptografarTexto(string textoOriginal)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(textoOriginal);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] textoCriptografado = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();

            return Convert.ToBase64String(textoCriptografado);
        }

        public string DescriptografarTexto(string textoCriptografado)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(textoCriptografado);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            byte[] textoOriginal = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(textoOriginal, 0, textoOriginal.Length);
            memoryStream.Close();
            cryptoStream.Close();

            return Encoding.UTF8.GetString(textoOriginal, 0, decryptedByteCount);
        }

        private bool VerificarStringBase64(string textoCriptografado)
        {
            textoCriptografado = textoCriptografado.Trim();
            return (textoCriptografado.Length % 4 == 0) && Regex.IsMatch(textoCriptografado, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        public string CriptografarSenha(string senhaInformada)
        {
            string senhaCriptografada = string.Empty;
            byte[] hash;

            if (senhaInformada.Trim() != string.Empty)
            {
                var data = Encoding.ASCII.GetBytes(senhaInformada);

                using (SHA512 shaM = new SHA512Managed())
                {
                    hash = shaM.ComputeHash(data);
                }

                senhaCriptografada = Encoding.ASCII.GetString(hash);
            }

            return senhaCriptografada;
        }

        public bool CompararSenhaCriptografada(string senhaCriptografada, string senhaInformada)
        {
            return CriptografarSenha(senhaInformada) == senhaCriptografada;
        }

        #endregion

        #region Permissão de Acesso

        public void VerificaPermissaoAcessoObjetos(Form form, List<UsuarioPermissoes> lstPermissoes)
        {
            foreach (UsuarioPermissoes itemPermissao in lstPermissoes.Where(x => string.IsNullOrEmpty(x.nomeControle) == false).ToList())
            {
                Control[] controle = form.Controls.Find(itemPermissao.nomeControle, true);
                if (controle.Length > 0)
                    controle[0].Enabled = itemPermissao.Habilitado;
            }
        }

        public void VerificaPermissaoAcessoObjetosMenu(MenuStrip menu, List<UsuarioPermissoes> lstPermissoesMenu)
        {
            bool itemHabilitado = true;

            foreach (UsuarioPermissoes itemPermissao in lstPermissoesMenu.Where(x => x.nomeControle != string.Empty))
            {
                ToolStripItem itemMenu = menu.Items.Find(itemPermissao.nomeControle, true).FirstOrDefault();
                if (itemMenu != null)
                    itemMenu.Enabled = itemPermissao.Habilitado;                
            }

            //foreach (ToolStripMenuItem menuItem in menu.Items.OfType<ToolStripMenuItem>())
            //{                
            //    if (menuItem.HasDropDownItems)
            //    {
            //        ToolStripItemCollection lstSubMenus = menuItem.DropDownItems;
            //        itemHabilitado = VerificarItemHabilitado(lstSubMenus);
            //        menuItem.Enabled = itemHabilitado;
            //    }
            //}
        }

        //private bool VerificarItemHabilitado(ToolStripItemCollection lstSubMenus)
        //{
        //    List<bool> lstStatusItemMenu = new List<bool>();
        //    bool itemHabilitado = true;

        //    foreach (ToolStripMenuItem subItem in lstSubMenus.OfType<ToolStripMenuItem>())
        //    {
        //        if (subItem.HasDropDownItems)
        //        {
        //            itemHabilitado = VerificarItemHabilitado(subItem.DropDownItems);
        //            subItem.Enabled = itemHabilitado;                    
        //        }
        //        else
        //            lstStatusItemMenu.Add(subItem.Enabled);
        //    }

        //    return lstStatusItemMenu.Exists(x => x == true);
        //}        

        public bool VerificaPermissaoAcessoFormulario(string nomeFormulario, List<UsuarioPermissoes> lstPermissoes)
        {
            return lstPermissoes.Exists(perm => perm.nomeFormulario == nomeFormulario);
        }

        #endregion

        #region Parametrizações Grid

        public void VerificarCorLinhaGrid(DataGridView grid)
        {
            switch (grid.Name)
            {
                case "gvOrdensPagamentos":
                    VerificarCorLinhaGridOP(grid);
                    break;
                case "gvVeiculos":
                    VerificarCorLinhaGridVeiculos(grid);
                    break;
                default:
                    break;
            }
        }

        private void VerificarCorLinhaGridOP(DataGridView grid)
        {            
            int diasAteVenc = 0;

            foreach (DataGridViewRow linha in grid.Rows)
            {
                if (linha.Cells[7].Value.ToString() != "PAGA" && linha.Cells[7].Value.ToString() != "CANCELADA")
                {
                    diasAteVenc = (DateTime.Parse(linha.Cells[10].Value.ToString()) - DateTime.Today).Days;

                    if (diasAteVenc <= Parametrizacao.diasVencimentoOPAlerta && diasAteVenc > Parametrizacao.diasVencimentoOPCritico)
                        linha.DefaultCellStyle.BackColor = Color.Yellow;
                    else if (diasAteVenc <= Parametrizacao.diasVencimentoOPCritico)
                        linha.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }            
        }

        private void VerificarCorLinhaGridVeiculos(DataGridView grid)
        {
            int? diasAteVencSeguro = 0;
            int diasAteVencIPVA = 0;
            int diasAteVencDPVAT = 0;

            foreach (DataGridViewRow linha in grid.Rows)
            {
                diasAteVencSeguro = linha.Cells[5].Value == null ? (int?)null : (DateTime.Parse(linha.Cells[5].Value.ToString()) - DateTime.Today).Days;
                diasAteVencIPVA = (DateTime.Parse(linha.Cells[6].Value.ToString()) - DateTime.Today).Days;
                diasAteVencDPVAT = (DateTime.Parse(linha.Cells[7].Value.ToString()) - DateTime.Today).Days;

                if ((diasAteVencSeguro != null && diasAteVencSeguro <= Parametrizacao.diasVencimentoDocumentacaoVeiculoAlerta && diasAteVencSeguro > Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico) ||
                    (diasAteVencIPVA <= Parametrizacao.diasVencimentoDocumentacaoVeiculoAlerta && diasAteVencIPVA > Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico) ||
                    (diasAteVencDPVAT <= Parametrizacao.diasVencimentoDocumentacaoVeiculoAlerta && diasAteVencDPVAT > Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico))
                {
                    linha.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if ((diasAteVencSeguro != null && diasAteVencSeguro <= Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico) ||
                    (diasAteVencIPVA <= Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico) ||
                    (diasAteVencDPVAT <= Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico))
                {
                    linha.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }            
        }

        #endregion
    }    
}
