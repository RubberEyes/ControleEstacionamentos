using Microsoft.AspNetCore.Mvc;
using ControleEstacionamentos.Models;
using ControleEstacionamentos.Repositories;

namespace ControleEstacionamentos.Controllers
{
    public class FuncionarioController : Controller
    {
        private IFuncionarioRepository repository;

        public FuncionarioController(IFuncionarioRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FuncionarioViewModel model)
        {
            Funcionario funcionario = repository.Read(model.CPF);
            if(funcionario.senha == model.Senha)
            {
                HttpContext.Session.SetInt32("Id", funcionario.id);
                HttpContext.Session.SetString("Nome", funcionario.nome);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "CPF de Funcionário não encontrado";
            return View(model);
        }
    }
}