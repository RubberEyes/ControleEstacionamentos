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

        public ActionResult Index(int? id_estacionamento)
        {
            int? id_funcionario = HttpContext.Session.GetInt32("IdFuncionario");
            if(id_funcionario == null)
            {
                return RedirectToAction("Login", "Funcionario");
            }

            if(id_estacionamento.HasValue)
            {
                List<Vaga> vagas = repository.GetVagas(id_estacionamento.GetValueOrDefault(0));
                ViewBag.EstacionamentoId = id_estacionamento;

                Console.WriteLine("id: " + id_estacionamento);
                Console.WriteLine("viewdata: " + ViewData["EstacionamentoId"]);

                return View(vagas);
            }
            
            return RedirectToAction("Index", "Estacionamento");
        }

        [HttpGet]
        public ActionResult Toggle(int id_vaga, int id_estacionamento)
        {
            Console.WriteLine("Toggling Vaga ID: " + id_vaga);
            Console.WriteLine("viewdata: " + ViewData["EstacionamentoId"]);


            repository.Toggle(id_vaga);

            return RedirectToAction( "Index", "Vaga", new { id_estacionamento =  id_estacionamento} );
        }
    }
}
