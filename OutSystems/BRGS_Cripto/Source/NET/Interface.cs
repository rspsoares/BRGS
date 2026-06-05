using System;
using System.Collections;
using System.Data;
using OutSystems.HubEdition.RuntimePlatform;

namespace OutSystems.NssBRGS_Cripto {

	public interface IssBRGS_Cripto {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ssCriptoText"></param>
		/// <param name="ssPlainText"></param>
		void MssCriptografar(out string ssCriptoText, string ssPlainText);

	} // IssBRGS_Cripto

} // OutSystems.NssBRGS_Cripto
