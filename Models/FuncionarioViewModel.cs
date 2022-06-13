using System.ComponentModel.DataAnnotations;

namespace ControleEstacionamentos.Models
{
    public class FuncionarioViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string CPF { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Senha { get; set; }
    }
}