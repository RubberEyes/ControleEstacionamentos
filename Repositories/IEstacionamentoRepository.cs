using ControleEstacionamentos.Models;

namespace ControleEstacionamentos.Repositories
{
    public interface IEstacionamentoRepository
    {
        Estacionamento Read(int id);
    }
}