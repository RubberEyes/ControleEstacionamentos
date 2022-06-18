using Microsoft.AspNetCore.Mvc;
using ControleEstacionamentos.Models;
using ControleEstacionamentos.Repositories;
using System.Text.RegularExpressions;

namespace ControleEstacionamentos.Controllers
{
    public class EstacionamentoController : Controller
    {
        private IEstacionamentoRepository repository;

        public EstacionamentoController(IEstacionamentoRepository repository)
        {
            this.repository = repository;
        }
    }
}
