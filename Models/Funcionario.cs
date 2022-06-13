namespace ControleEstacionamentos.Models
{
    public class Funcionario : Pessoa
    {
        public Funcionario()
        {
        }

        public Funcionario(int id, string nome, int status, string cpf, string senha)
        {
            this.id = id;
            this.nome = nome;
            this.status = status;
            this.cpf = cpf;
            this.senha = senha;
        }

        public string cpf { get; set; }
        public string senha { get; set;}
    }
}