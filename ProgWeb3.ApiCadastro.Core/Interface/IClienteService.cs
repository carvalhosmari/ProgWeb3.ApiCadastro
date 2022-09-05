using ProgWeb3.ApiCadastro.Core.Model;

namespace ProgWeb3.ApiCadastro.Core.Interface
{
    public interface IClienteService
    {
        List<Cliente> Get();

        Cliente Get2(string cpf);

        bool Insert(Cliente cliente);

        bool Update(long id, Cliente cliente);

        public bool Delete(long id);

        int GetId(string cpf);
    }
}
