using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC.Correios.Web.ViewModels
{
    public class ResultadoViewModel
    {
        public int CEP { get; set; }

        public int CodigoLogradouro { get; set; }

        public string Logradouro { get; set; }

        public string UF { get; set; }

        public string Municipio { get; set; }
    }
}