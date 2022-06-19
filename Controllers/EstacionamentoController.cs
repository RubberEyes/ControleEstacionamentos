using Microsoft.AspNetCore.Mvc;
using ControleEstacionamentos.Models;
using ControleEstacionamentos.Repositories;
using ControleEstacionamentos.Controllers;

namespace ControleEstacionamentos.Controllers
{
    public class EstacionamentoController : Controller
    {
        private IEstacionamentoRepository repository;
        private IVagaRepository vagaRepository;

        public EstacionamentoController(IEstacionamentoRepository repository, IVagaRepository vagaRepository)
        {
            this.repository = repository;
            this.vagaRepository = vagaRepository;
        }

        public ActionResult Index(int id)
        {
            int? id_funcionario = HttpContext.Session.GetInt32("Id");
            if(id_funcionario == null)
            {
                return RedirectToAction("Login", "Funcionario");
            }
            List<Vaga> vagas = vagaRepository.GetVagas(id);

            return View(vagas);
        }
    }
}
