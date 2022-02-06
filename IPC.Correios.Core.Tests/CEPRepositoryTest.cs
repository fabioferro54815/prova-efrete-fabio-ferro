using System;
using System.Collections.Generic;
using IPC.Correios.Web.Models;
using IPC.Correios.Web.Repositories;
using NUnit.Framework;

namespace IPC.Correios.Middleware.Core.Tests
{
    [TestFixture]
    public class CEPRepositoryTest
    {
        private CEPRepository CEPRepository;

        [SetUp]
        public void Setup()
        {
            CEPRepository = new CEPRepository();
        }

        [Test]
        public void BuscarEstados()
        {
            Assert.IsNotEmpty(CEPRepository.BuscarEstados());
        }

        [Test]
        public void BuscarMunicipios()
        { 
            string sigla = "SC";

            Assert.IsNotEmpty(CEPRepository.BuscarMunicipios(sigla));
        }

        [Test]
        public void BuscarLogradouros()
        {
            int codigoMunicipio = 8377;

            Assert.IsNotEmpty(CEPRepository.BuscarLogradouros(codigoMunicipio));
        }

        [Test]
        public void BuscarCEP()
        {
            int codigoLogradouro = 1000034;

            Assert.IsNotNull(CEPRepository.BuscarCEP(codigoLogradouro));
        }

        [Test]
        public void BuscarCEPNãoEncontrado()
        {
            int codigoLogradouro = 10075638;

            Assert.IsNull(CEPRepository.BuscarCEP(codigoLogradouro));
        }
    }
}
