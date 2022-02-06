using System;
using System.Collections.Generic;
using IPC.Correios.Web.Models;
using IPC.Correios.Web.Repositories;
using NUnit.Framework;

namespace IPC.Correios.Middleware.Core.Tests
{
    [TestFixture]
    public class EnderecoRepositoryTest
    {
        private EnderecoRepository EnderecoRepository;

        [SetUp]
        public void Setup()
        {
            EnderecoRepository = new EnderecoRepository();
        }

        [Test]
        public void BuscarEndereco()
        {
            int CEP = 88356102;

            Assert.IsNotNull(EnderecoRepository.BuscarEndereco(CEP));
        }
    }
}
