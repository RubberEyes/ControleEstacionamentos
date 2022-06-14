using Microsoft.AspNetCore.Mvc;
using ControleEstacionamentos.Models;
using ControleEstacionamentos.Repositories;
using System.Text.RegularExpressions;

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
            if(string.IsNullOrEmpty (model.Senha) || string.IsNullOrEmpty(model.CPF)) // Verificação de campos
            {
                return View(model);
            }

            string pattern = @"\.|-";
            Regex rgx = new Regex(pattern);

            string modelcpf = rgx.Replace(model.CPF, "");

            Funcionario funcionario = repository.Read(modelcpf);

            if(funcionario.cpf == null)
            {
                Console.WriteLine("Wrong cpf" + modelcpf);
                ViewBag.Message = "CPF de Funcionário não encontrado";
                return View(model);
            }


            if(funcionario.senha == model.Senha)
            {
                HttpContext.Session.SetInt32("Id", funcionario.id);
                HttpContext.Session.SetString("Nome", funcionario.nome);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                Console.WriteLine("Wrong psswd");
                ViewBag.Message = "Senha errada";
                return View(model);
            }
        }
    }
}