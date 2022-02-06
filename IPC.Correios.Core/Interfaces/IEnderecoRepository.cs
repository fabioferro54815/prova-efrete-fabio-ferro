using IPC.Correios.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Interfaces
{
    interface IEnderecoRepository
    {
        ResultadoViewModel BuscarEndereco(int CEP);
    }
}
