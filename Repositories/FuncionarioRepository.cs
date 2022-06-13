using ControleEstacionamentos.Models;
using System.Data.SqlClient;

namespace ControleEstacionamentos.Repositories
{
    public class FuncionarioRepository : DBContext, IFuncionarioRepository
    {
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
