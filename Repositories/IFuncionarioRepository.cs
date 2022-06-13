using ControleEstacionamentos.Models;

namespace ControleEstacionamentos.Repositories
{
    public interface IFuncionarioRepository
    {
        Funcionario Read(string cpf);
    }
}