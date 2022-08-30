namespace ProgWeb3.ApiCadastro
{
    public class Cliente
    {
        public string? Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNasc { get; set; }
        public int Idade => CalculaIdade();


        public int CalculaIdade()
        {
            var idade = DateTime.Now.Year - DataNasc.Year;

            if (DataNasc.DayOfYear > DateTime.Now.DayOfYear)
            {
                idade--;
            }
            
            return idade;
        }
    }
}