using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC.Correios.Web.Models
{
    public class Localidade
    {
        public int CodigoMunicipio { get; set; }

        public string UF { get; set; }

        public string NomeCompletoMunicipio { get; set; }
    }
}