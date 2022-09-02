using System.Data.SqlClient;
using Dapper;

namespace ProgWeb3.ApiCadastro.Repository
{
    public class RepositorioCliente
    {
        private readonly IConfiguration _configuration;

        public RepositorioCliente(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cliente> Get()
        {
            var query = "SELECT * FROM clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<Cliente>(query).ToList();
        }

        public Cliente Get2(string cpf)
        {
            var query = "SELECT * FROM clientes WHERE cpf = @cpf";

            var parameter = new DynamicParameters();
            parameter.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Cliente>(query, parameter);
        }

        public bool Insert(Cliente cliente)
        {
            var query = "INSERT INTO clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";

            var parameter = new DynamicParameters();
            parameter.Add("nome", cliente.Nome);
            parameter.Add("cpf", cliente.Cpf);
            parameter.Add("dataNascimento", cliente.DataNasc);
            parameter.Add("idade", cliente.Idade);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameter) == 1;
        }

        public bool Update(long id, Cliente cliente)
        {
            cliente.Id = id;

            var query = "UPDATE clientes SET cpf = @cpf, nome = @nome, dataNascimento = @dataNascimento, idade = @idade WHERE id = @id";

            var parameter = new DynamicParameters();
            parameter.Add("id", id);
            parameter.Add("nome", cliente.Nome);
            parameter.Add("cpf", cliente.Cpf);
            parameter.Add("dataNascimento", cliente.DataNasc);
            parameter.Add("idade", cliente.Idade);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameter) == 1;
        }

        public bool Delete(long id)
        {
            var query = "DELETE FROM clientes WHERE id = @id";

            var parameter = new DynamicParameters();
            parameter.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameter) == 1;
        }

        public int GetId(string cpf)
        {
            var query = "DECLARE @retorno AS INT = 0; SELECT @retorno = id FROM clientes WHERE cpf = @cpf; SELECT @retorno;";

            var parameter = new DynamicParameters();
            parameter.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<int>(query, parameter).SingleOrDefault();
        }
    }
}
