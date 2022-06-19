namespace ControleEstacionamentos.Models
{
    public class Estacionamento : Pessoa
    {
        public Estacionamento()
        {
            
        }

        public Estacionamento(int id, string nome, int status, string cnpj, string endereco)
        {
            this.id = id;
            this.nome = nome;
            this.status = status;
            this.cnpj = cnpj;
            this.endereco = endereco;
        }

        public string cnpj { get; set; }
        public string endereco { get; set;}
    }
}