using IPC.Correios.Core.Interfaces;
using IPC.Correios.Web.Models;
using IPC.Correios.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC.Correios.Web.Repositories
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        private string PATH_LOCALIDADES = @"C:\E-Frete\prova-pratica-fullstack-csharp\IPC.Correios.Core\App_Data\Correios\LOG_LOCALIDADE.txt";
        private string PATH_LOGRADOUROS = @"C:\E-Frete\prova-pratica-fullstack-csharp\IPC.Correios.Core\App_Data\Correios\LOG_LOGRADOURO_SC.TXT";

        public ResultadoViewModel BuscarEndereco(int CEP)
        {
            string[] logradouros = ObterRegistrosTXT(PATH_LOGRADOUROS);
            string[] localidades = ObterRegistrosTXT(PATH_LOCALIDADES);

            foreach (var logradouro in logradouros)
            {
                if (logradouro.Contains("@" + CEP.ToString() +"@"))
                {
                    string[] valoresLogradouro = ExtrairCampos(logradouro);

                    Logradouro logradouroOBJ = new Logradouro
                    {
                        CodigoLogradouro = int.Parse(valoresLogradouro[0]),
                        CodigoMunicipio = int.Parse(valoresLogradouro[2]),
                        CEP = int.Parse(valoresLogradouro[7]),
                        NomeCompleto = valoresLogradouro[10]
                    };

                    foreach (var localidade in localidades)
                    {
                        if (localidade.StartsWith(logradouroOBJ.CodigoMunicipio.ToString()))
                        {
                            string[] valoresLocalidade = ExtrairCampos(localidade);

                            Localidade localidadeOBJ = new Localidade
                            {
                                CodigoMunicipio = int.Parse(valoresLocalidade[0]),
                                UF = valoresLocalidade[1],
                                NomeCompletoMunicipio = valoresLocalidade[2]
                            };

                            ResultadoViewModel resultadoViewModel = new ResultadoViewModel
                            {
                                CEP = logradouroOBJ.CEP,
                                CodigoLogradouro = logradouroOBJ.CodigoLogradouro,
                                Logradouro = logradouroOBJ.NomeCompleto,
                                UF = localidadeOBJ.UF,
                                Municipio = localidadeOBJ.NomeCompletoMunicipio
                            };

                            return resultadoViewModel;
                        }
                    }
                }
            }
            return null;
        }
    }
}