using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace BRGS.Util
{
    public class ClassProperties
    {
        public class PropriedadeClasse
        {
            public PropertyInfo nomePropriedade { get; set; }
            public string descricaoPropriedade { get; set; }            
            public Type tipoPropriedade { get; set; }
        }

        public List<PropriedadeClasse> RetornarPropriedadesClasse(object classe)
        {
            List<PropriedadeClasse> lstPropriedadesClasse = new List<PropriedadeClasse>();
            Type tipo = classe.GetType();

            PropertyInfo[] lstPropriedades = tipo.GetProperties();

            foreach (PropertyInfo propriedade in lstPropriedades)                
            {
                DescriptionAttribute[] listaAtributos = (DescriptionAttribute[])propriedade.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (listaAtributos.Length > 0)                    
                {
                    lstPropriedadesClasse.Add(new PropriedadeClasse                    
                    { 
                        nomePropriedade = propriedade,
                        tipoPropriedade = propriedade.PropertyType,                        
                        descricaoPropriedade = listaAtributos[0].Description
                    });
                }                    
            }

            return lstPropriedadesClasse.OrderBy(p => p.descricaoPropriedade).ToList();
        }

        public Object RetornarObjetoFiltro(object classeDestino, PropertyInfo filtroSelecionado, string valorFiltro)
        {
            try
            {
                if (filtroSelecionado != null && valorFiltro != string.Empty)
                {
                    foreach (PropertyInfo propriedadeFiltroObjeto in classeDestino.GetType().GetProperties())
                    {
                        if (propriedadeFiltroObjeto.Name == filtroSelecionado.Name)
                        {
                            propriedadeFiltroObjeto.SetValue(classeDestino, Convert.ChangeType(valorFiltro, propriedadeFiltroObjeto.PropertyType), null);
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                classeDestino = null;
            }

            return classeDestino;
        }
    }
}
