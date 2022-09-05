using System.ComponentModel.DataAnnotations;

namespace ProgWeb3.ApiCadastro.Core.Model
{
    public class Cliente
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Cpf é obrigatório!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O Cpf deve conter 11 dígitos!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Data é obrigatória!")]
        public DateTime DataNascimento { get; set; }


        public int Idade => CalculaIdade();


        public int CalculaIdade()
        {
            var idade = DateTime.Now.Year - DataNascimento.Year;

            if (DataNascimento.DayOfYear > DateTime.Now.DayOfYear)
            {
                idade--;
            }

            return idade;
        }
    }
}