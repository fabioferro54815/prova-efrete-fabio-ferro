using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC.Correios.Web.Models
{
    public class Logradouro
    {
        public int CodigoLogradouro { get; set; }

        public int CodigoMunicipio { get; set; }

        public int CEP { get; set; }

        public string NomeCompleto { get; set; }
    }
}