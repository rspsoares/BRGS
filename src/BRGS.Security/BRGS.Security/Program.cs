using BRGS.Util;
using System.IO;
using System.Text.RegularExpressions;

namespace BRGS.Security
{
    class Program
    {
        private static readonly Helper _helper = new Helper();

        static void Main()
        {
            CryptoFile();
            DecryptFile();
        }
        

        static void CryptoFile()
        {
            //var content = _helper.CriptografarTexto("Server=dbsq0008.whservidor.com;Database=brgs1;Network Library=DBMSSOCN;Initial Catalog=brgs1;User Id=brgs1;Password=2014roberto;");
            var content = _helper.CriptografarTexto("Server=167.160.186.27;Database=brgs1_old;Network Library=DBMSSOCN;Initial Catalog=brgs1_old;User Id=brgs1;Password=2014roberto;");
            File.WriteAllText(@"C:\BRGS\DBServer.dat", content);
        }

        static void DecryptFile()
        {
            var folder = new DirectoryInfo(@"C:\BRGS\");
            var cryptedFile = folder.GetFiles("DBServer.dat", SearchOption.TopDirectoryOnly);

            if (cryptedFile.Length > 0)
            {
                var content = File.ReadAllText(cryptedFile[0].FullName);
                if (content.Length > 0 && CheckStringBase64(content))
                {
                    var strConn = _helper.DescriptografarTexto(content);
                    File.WriteAllText(@"C:\BRGS\ConnectionString.txt", strConn);
                }                 
            }
        }

        static bool CheckStringBase64(string textoCriptografado)
        {
            textoCriptografado = textoCriptografado.Trim();
            return (textoCriptografado.Length % 4 == 0) && Regex.IsMatch(textoCriptografado, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
    }
}
