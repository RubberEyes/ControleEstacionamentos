using ControleEstacionamentos.Models;
using System.Data.SqlClient;


namespace ControleEstacionamentos.Repositories
{
    public class EstacionamentoRepository : DBContext, IEstacionamentoRepository
    {
        public Estacionamento Read(int id)
        {
            throw new NotImplementedException();
        }
    }
}