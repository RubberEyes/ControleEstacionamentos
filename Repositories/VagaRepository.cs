using ControleEstacionamentos.Models;
using System.Data.SqlClient;

namespace ControleEstacionamentos.Repositories
{
    public class VagaRepository : DBContext, IVagaRepository
    {
        public List<Vaga> GetVagas(int estacionamento_id)
        {
            try 
            {
                List<Vaga> vagas = new List<Vaga>();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = @"
                    SELECT * FROM  Vagas v
                        LEFT JOIN PossuiVaga pv
                        ON pv.vagaId = v.id
                        WHERE pv.estacionamentoId = @id
                ";
                cmd.Parameters.AddWithValue("@id", estacionamento_id);

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    vagas.Add(
                        new Vaga
                        {
                            id = (int)reader["id"],
                            ocupado = (bool)reader["ocupacao"],
                            status = (int)reader["status"]
                        }
                    );
                }

                return vagas;
            }
            finally
            {
                Dispose();
            }
        }

        public void Toggle(int id_vaga)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = @"
                    IF 0 = (SELECT v.ocupacao FROM Vagas v WHERE v.id = @id)
                        UPDATE Vagas SET ocupacao = 1 WHERE id = @id
                    ELSE
                        UPDATE Vagas SET ocupacao = 0 WHERE id = @id
                ";

                cmd.Parameters.AddWithValue("@id", id_vaga);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                Dispose();
            }
        }
    }
}