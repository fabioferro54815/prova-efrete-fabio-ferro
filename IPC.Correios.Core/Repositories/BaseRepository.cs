using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IPC.Correios.Web.Repositories
{
    public class BaseRepository
    {
        protected string[] ObterRegistrosTXT(string PATH)
        {
            return File.ReadAllLines(PATH);
        }

        public string[] ExtrairCampos(string valor)
        {
            string[] valores = valor.Split('@');

            return valores;
        }

    }
}