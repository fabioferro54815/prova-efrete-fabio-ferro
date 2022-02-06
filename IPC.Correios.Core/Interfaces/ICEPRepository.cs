using IPC.Correios.Web.Models;
using IPC.Correios.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Interfaces
{
    interface ICEPRepository
    {
        List<UF> BuscarEstados();

        List<Municipio> BuscarMunicipios(string sigla);

        List<Logradouro> BuscarLogradouros(int codigoMunicipio);

        ResultadoViewModel BuscarCEP(int codigoLogradouro);
    }
}
