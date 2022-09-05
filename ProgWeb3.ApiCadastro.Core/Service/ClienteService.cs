using ProgWeb3.ApiCadastro.Core.Interface;
using ProgWeb3.ApiCadastro.Core.Model;

namespace ProgWeb3.ApiCadastro.Core.Service
{
    public class ClienteService : IClienteService
    {
        public IRepositorioCliente _repositorioCliente;

        public ClienteService(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public List<Cliente> Get()
        {
            return _repositorioCliente.Get();
        }

        public Cliente Get2(string cpf)
        {
            return _repositorioCliente.Get2(cpf);
        }

        public bool Insert(Cliente cliente)
        {
            return _repositorioCliente.Insert(cliente);
        }

        public bool Update(long id, Cliente cliente)
        {
            return _repositorioCliente.Update(id, cliente);
        }

        public bool Delete(long id)
        {
            return _repositorioCliente.Delete(id);
        }

        public int GetId(string cpf)
        {
            return _repositorioCliente.GetId(cpf);
        }
    }
}