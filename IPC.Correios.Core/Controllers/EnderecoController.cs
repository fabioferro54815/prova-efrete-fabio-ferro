using IPC.Correios.Core.Interfaces;
using IPC.Correios.Web.Repositories;
using IPC.Correios.Web.ViewModels;
using System.Web.Mvc;

namespace IPC.Correios.Web.Controllers
{
    public class EnderecoController : Controller
    {
        private IEnderecoRepository EnderecoRepository { get; set; }

        public EnderecoController()
        {
            EnderecoRepository = new EnderecoRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuscarEndereco(int cep)
        {
            return View(EnderecoRepository.BuscarEndereco(cep));
        }
    }
}
