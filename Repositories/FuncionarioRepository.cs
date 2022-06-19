using ControleEstacionamentos.Models;
using System.Data.SqlClient;

namespace ControleEstacionamentos.Repositories
{
    public class FuncionarioRepository : DBContext, IFuncionarioRepository
    {
        public List<Estacionamento> GetEstacionamentosAssociados(int id_funcionario)
        {
            try
            {                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"
                    SELECT e.cnpj, e.Endereco, p.id, p.nome, p.[status] FROM Estacionamentos as e, FuncionarioEstacionamento as fe, Pessoas as p
                        WHERE @id = fe.funcionarioId AND fe.estacionamentoId = e.pessoa_id AND p.id = e.pessoa_id
                ";

                cmd.Parameters.AddWithValue("@id", id_funcionario);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Estacionamento> estacionamentos = new List<Estacionamento>();
                
                while(reader.Read())
                {
                    estacionamentos.Add(
                        new Estacionamento((int)reader["id"], (string)reader["nome"], (int)reader["status"], (string)reader["cnpj"], (string)reader["Endereco"])
                    );
                }

                return estacionamentos;
            }
            finally
            {
                Dispose();
            }
        }

        public Funcionario Read(string cpf)
        {
            try
            {
                Funcionario funcionario = new Funcionario();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"
                    SELECT * FROM Funcionarios as f, Pessoas as p
                        WHERE f.CPF = @cpf AND f.pessoa_id = p.id
                ";
                cmd.Parameters.AddWithValue("@cpf", cpf);
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    funcionario.cpf= cpf;
                    funcionario.id = (int) reader["id"];
                    funcionario.nome = (string) reader["nome"];
                    funcionario.status = (int) reader["status"];
                    funcionario.senha = (string) reader["Senha"];
                }
                return funcionario;
            }
            finally
            {
                Dispose();
            }
        }
    }
}
