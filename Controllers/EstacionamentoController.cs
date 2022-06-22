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
        private IFuncionarioRepository funcionarioRepository;

        public EstacionamentoController(IEstacionamentoRepository repository, IVagaRepository vagaRepository, IFuncionarioRepository funcionarioRepository)
        {
            this.repository = repository;
            this.vagaRepository = vagaRepository;
            this.funcionarioRepository = funcionarioRepository;
        }



        public ActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("IdFuncionario");
            if (id.HasValue)
            {
                List<Estacionamento> estacionamentos = funcionarioRepository.GetEstacionamentosAssociados(id.Value);
                
                return View(estacionamentos);
            }
            return RedirectToAction("Login", "Funcionario");
        }
    }
}
