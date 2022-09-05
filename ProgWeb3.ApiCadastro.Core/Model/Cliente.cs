using System.ComponentModel.DataAnnotations;

namespace ProgWeb3.ApiCadastro.Core.Model
{
    public class Cliente
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome � obrigat�rio!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Cpf � obrigat�rio!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O Cpf deve conter 11 d�gitos!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Data � obrigat�ria!")]
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