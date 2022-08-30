using Microsoft.AspNetCore.Mvc;

namespace ProgWeb3.ApiCadastro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private static readonly string[] Nomes = new[]
        {
        "Maria", "João", "Roberto", "Mario", "Solange", "Carla", "Rodrigo", "Marina", "Gabriel", "Fernanda"
        };
        private static readonly string[] Cpfs = new[]
        {
        "502.788.640-31", "614.199.180-79", "078.675.490-72", "567.742.100-66", "496.796.130-46", "649.273.340-15", "584.377.670-08", "728.479.940-41", "487.565.200-34", "011.596.380-47"
        };

        private readonly ILogger<ClienteController> _logger;

        public List<Cliente> Clientes { get; set; }

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;

            Clientes = Enumerable.Range(1, 5).Select(index => new Cliente
            {
                Nome = Nomes[Random.Shared.Next(Nomes.Length)],
                Cpf = Cpfs[Random.Shared.Next(Cpfs.Length)],
                DataNasc = DateTime.Now.AddDays(-Random.Shared.Next(6450, 38349))
            }).ToList();
            
        }

        [HttpGet]
        public List<Cliente> Get()
        {
            return Clientes;
        }

        [HttpPost]
        public Cliente Insert(Cliente novoCliente)
        {
            Clientes.Add(novoCliente);
            return novoCliente;
        }

        [HttpPut] 
        public Cliente Update(int index, Cliente cliente)
        {
            Clientes[index] = cliente;
            return Clientes[index];
        }

        [HttpDelete]
        public List<Cliente> Delete(int index)
        {
            Clientes.RemoveAt(index);
            return Clientes;
        }
    }
}