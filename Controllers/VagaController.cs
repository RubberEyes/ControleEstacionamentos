using Microsoft.AspNetCore.Mvc;
using ControleEstacionamentos.Models;
using ControleEstacionamentos.Repositories;

namespace ControleEstacionamentos.Controllers
{
    public class VagaController : Controller
    {
        private IVagaRepository repository;

        public VagaController(IVagaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Toggle(int id)
        {
            repository.Toggle(id);
            return View();
        }
    }
}