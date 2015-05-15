using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRGS.UI
{
    public class HelperUI
    {
        public void AbrirNovaAba(TabPage tab, Form frm)
        {            
            mdiBRGS mdi = new mdiBRGS();
            Form formDuplicado = null;
            
            // Recuperando a instância do MDI e do Form duplicado (se houver)
            foreach (Form formAberto in Application.OpenForms)
            {
                if (formAberto.Name == "mdiBRGS")                                
                    mdi = (mdiBRGS)formAberto;
                else if (formAberto.Name == frm.Name)                
                    formDuplicado = formAberto;                
            }

            // Verificando se o form já está aberto
            if(formDuplicado != null)
            { 
                foreach (TabPage itemAba in mdi.tabTelas.TabPages)
                {
                    if (itemAba.Controls[0] == formDuplicado)
                    {
                        // Posicionar na aba do form
                        mdi.tabTelas.SelectedTab = itemAba;
                        break;
                    }
                }
                return;
            }
            
            // Abre o formulário em uma nova aba
            tab.ToolTipText = tab.Text + Environment.NewLine + "Clique com o botão direito para fechar";
            tab.Name = tab.Text;
            mdi.tabTelas.TabPages.Add(tab);

            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            mdi.tabTelas.TabPages[mdi.tabTelas.TabCount - 1].Controls.Add(frm);
            mdi.tabTelas.SelectedIndex = mdi.tabTelas.TabCount - 1;
        }

        public void AlterarTituloAbaAtual(string novoTexto)
        {
            mdiBRGS mdi = new mdiBRGS();

            mdi = this.RecuperarInstanciaMDI();
            mdi.tabTelas.TabPages[mdi.tabTelas.SelectedIndex].Text = novoTexto;
        }

        private mdiBRGS RecuperarInstanciaMDI()
        {
            mdiBRGS mdi = new mdiBRGS();

            // Instânciando o MDI e o Form duplicado (se houver)
            foreach (Form formAberto in Application.OpenForms)
            {
                if (formAberto.Name == "mdiBRGS")
                {
                    mdi = (mdiBRGS)formAberto;
                    break;
                }
            }

            return mdi;
        }

        public Form RecuperarInstanciaForm(Form frm)
        {
            Form formFiltrado = null;

            mdiBRGS mdi = new mdiBRGS();
            mdi = this.RecuperarInstanciaMDI();

            foreach (Form formAberto in Application.OpenForms)
            {
                if (formAberto.Name == frm.Name)
                {
                    formFiltrado = formAberto;
                    break;
                }
            }

            return formFiltrado; 
        }

    //    public void AtualizarTela(string nomeTela)
    //    {
    //        mdiBRGS mdi = new mdiBRGS();

    //        foreach (Form formAberto in Application.OpenForms)
    //        {
    //            if (formAberto.Name == "mdiBRGS")
    //            {
    //                mdi = (mdiBRGS)formAberto;
    //                break;
    //            }
    //        }

    //        switch (nomeTela)
    //        {
    //            case "CentroCusto_ClienteManutencao":
    //                foreach (TabPage abaTab in mdi.tabTelas.TabPages)
    //                {
    //                    Control[] controle = abaTab.Controls.Find("ClienteManutencao", true);
    //                    if (controle.Length > 0)
    //                    {
    //                        ClienteManutencao formClientesManutencao = (ClienteManutencao)controle[0];
    //                        formClientesManutencao.lbIdCC.Text = 
    //                        formAnimais.CarregarComboClientes();
    //                        formAnimais.CarregarGrid(new AnimalGrid(), formAnimais.linhaGrid);
    //                    }
    //                }

    //                break;          

    //            default:
    //                break;
    //        }

    //    }
    }
}
