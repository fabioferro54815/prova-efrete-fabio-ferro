using IPC.Correios.Core.Interfaces;
using IPC.Correios.Web.Models;
using IPC.Correios.Web.Repositories;
using IPC.Correios.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPC.Correios.Web.Controllers
{
    public class CEPController : Controller
    {
        private ICEPRepository CEPRepository { get; set; }

        public CEPController()
        {
            CEPRepository = new CEPRepository();
        }

        public ActionResult Index()
        {
            return View(CEPRepository.BuscarEstados());
        }

        public ActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuscarMunicipios(string estado)
        {

            var resultado = CEPRepository.BuscarMunicipios(estado);

            if (resultado.Count() == 0)
                return Redirect("Error");
            else
            {
                return View(resultado);
            }
        }

        [HttpGet]
        public ActionResult BuscarLogradouros(int municipio)
        {
            var resultado = CEPRepository.BuscarLogradouros(municipio);

            if (resultado.Count() == 0)
                return Redirect("Error");
            else
            {
                return View(resultado);
            }
        }

        [HttpGet]
        public ActionResult BuscarCEP(int logradouro)
        {
            return View(CEPRepository.BuscarCEP(logradouro));
        }
    }
}
