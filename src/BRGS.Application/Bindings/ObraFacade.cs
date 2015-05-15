using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class ObraFacade: IObraFacade
    {
        public virtual List<Obra> Pesquisar(Obra obra)
        {
            return new List<Obra>();
        }

        public virtual List<Obra> PesquisarObraDespesa(int idDespesa)
        {
            return new List<Obra>();
        }

        public virtual List<Obra> PesquisarCombo()
        {
            return new List<Obra>();
        }

        public virtual List<Obra> PesquisarObraFreteCombo()
        {
            return new List<Obra>();
        }

        public virtual string Incluir(Obra obra, out int idObra)
        {
            idObra = 0;
            return "";
        }

        public virtual string Alterar(Obra obra)
        {
            return "";
        }

        public virtual void Excluir()
        {
            
        }

        public virtual DataTable GerarRelatorioRealizadas(string filtro)
        {
            return new DataTable();
        }

        public virtual List<ObraGastoRealizado> PesquisarGastosRealizados(ObraGastoRealizado gastoRealizado)
        {
            return new List<ObraGastoRealizado>();
        }

        public virtual List<UEN> RetornarUENGastosRealizados(ObraGastoRealizado gastoRealizado)
        {
            return new List<UEN>();
        }

        public virtual void IncluirGastoRealizado(ObraGastoRealizado gastoRealizado, out int idGastoRealizado)
        {
            idGastoRealizado = 0;
        }
    }
}
