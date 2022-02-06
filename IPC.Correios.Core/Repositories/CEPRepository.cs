using IPC.Correios.Core.Interfaces;
using IPC.Correios.Web.Models;
using IPC.Correios.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC.Correios.Web.Repositories
{
    public class CEPRepository : BaseRepository, ICEPRepository
    {
        private string PATH_LOCALIDADES = @"C:\E-Frete\prova-pratica-fullstack-csharp\IPC.Correios.Core\App_Data\Correios\LOG_LOCALIDADE.txt";
        private string PATH_LOGRADOUROS = @"C:\E-Frete\prova-pratica-fullstack-csharp\IPC.Correios.Core\App_Data\Correios\LOG_LOGRADOURO_SC.TXT";

        public List<UF> BuscarEstados()
        {
            string[] localidades = ObterRegistrosTXT(PATH_LOCALIDADES);
            List<UF> estados = new List<UF>();

            foreach (var localidade in localidades)
            {
                string[] valoresLocalidade = ExtrairCampos(localidade);

                UF uf = new UF() { Sigla = valoresLocalidade[1] };

                var siglaBuscada = estados.Where(item => item.Sigla == uf.Sigla);

                if (!siglaBuscada.Any())
                    estados.Add(uf);
            }

            return estados;
        }

        public List<Municipio> BuscarMunicipios(string sigla)
        {
            string[] localidades = ObterRegistrosTXT(PATH_LOCALIDADES);
            List<Municipio> municipios = new List<Municipio>();

            foreach (var localidade in localidades)
            {
                if (localidade.Contains("@"+sigla+"@"))
                {
                    string[] valoresLocalidade = ExtrairCampos(localidade);

                    Municipio municipio = new Municipio()
                    {
                        CodigoMunicipio = int.Parse(valoresLocalidade[0]),
                        UF = valoresLocalidade[1],
                        Nome = valoresLocalidade [2]
                    };

                    municipios.Add(municipio);
                }
            }

            return municipios;
        }

        public List<Logradouro> BuscarLogradouros(int codigoMunicipio)
        {
            string[] logradouros = ObterRegistrosTXT(PATH_LOGRADOUROS);
            List<Logradouro> listaLogradouros = new List<Logradouro>();

            foreach (var logradouro in logradouros)
            {
                string[] valoresLogradouro = ExtrairCampos(logradouro);

                Logradouro logradouroOBJ = new Logradouro
                {
                    CodigoLogradouro = int.Parse(valoresLogradouro[0]),
                    CodigoMunicipio = int.Parse(valoresLogradouro[2]),
                    CEP = int.Parse(valoresLogradouro[7]),
                    NomeCompleto = valoresLogradouro[10]
                };

                if (logradouroOBJ.CodigoMunicipio == codigoMunicipio)
                {
                    listaLogradouros.Add(logradouroOBJ);
                }
            }

            return listaLogradouros;
        }

        public ResultadoViewModel BuscarCEP(int codigoLogradouro)
        {
            string[] logradouros = ObterRegistrosTXT(PATH_LOGRADOUROS);
            string[] localidades = ObterRegistrosTXT(PATH_LOCALIDADES);

            foreach (var logradouro in logradouros)
            {
                if (logradouro.StartsWith(codigoLogradouro.ToString()))
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