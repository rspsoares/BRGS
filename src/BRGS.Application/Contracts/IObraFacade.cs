using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Contracts
{
    public interface IObraFacade
    {
        List<Obra> Pesquisar(Obra obra);               

        List<Obra> PesquisarObraDespesa(int idDespesa);

        List<Obra> PesquisarCombo();

        List<Obra> PesquisarObraFreteCombo();

        string Incluir(Obra obra, out int idObra);

        string Alterar(Obra obra);

        void Excluir();

        DataTable GerarRelatorioRealizadas(string filtro);

        List<ObraGastoRealizado> PesquisarGastosRealizados(ObraGastoRealizado gastoRealizado);

        List<UEN> RetornarUENGastosRealizados(ObraGastoRealizado gastoRealizado);

        void IncluirGastoRealizado(ObraGastoRealizado gastoRealizado, out int idGastoRealizado);
    }
}
