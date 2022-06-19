using ControleEstacionamentos.Models;

namespace ControleEstacionamentos.Repositories
{
    public interface IVagaRepository
    {
        List<Vaga> GetVagas(int estacionamento_id);
        void Toggle(int id_vaga);
    }
}