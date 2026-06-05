using System.Security.Cryptography;
using System.Text;

namespace OutSystems.NssBRGS_Cripto 
{
	public class CssBRGS_Cripto: IssBRGS_Cripto 
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ssCriptoText"></param>
		/// <param name="ssPlainText"></param>
		public void MssCriptografar(out string ssCriptoText, string ssPlainText) 
		{	
			ssCriptoText = "";

            byte[] hash;

            if (ssPlainText.Trim() != string.Empty)
            {
                var data = Encoding.ASCII.GetBytes(ssPlainText);

                using (SHA512 shaM = new SHA512Managed())
                {
                    hash = shaM.ComputeHash(data);
                }

                ssCriptoText = Encoding.ASCII.GetString(hash);
            }
        } 
	}
}