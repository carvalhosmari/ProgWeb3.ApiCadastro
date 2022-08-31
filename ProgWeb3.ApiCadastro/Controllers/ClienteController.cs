using Microsoft.AspNetCore.Mvc;

namespace ProgWeb3.ApiCadastro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        private static readonly string[] Nomes = new[]
        {
        "Maria", "João", "Roberto", "Mario", "Solange", "Carla", "Rodrigo", "Marina", "Gabriel", "Fernanda"
        };
        private static readonly string[] Cpfs = new[]
        {
        "50278864031", "61419918079", "07867549072", "56774210066", "49679613046", "64927334015", "58437767008", "72847994041", "48756520034", "01159638047"
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

        [HttpGet("/clientes/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(Clientes);
        }

        [HttpGet("/cliente/{cpf}/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> Get2(string cpf)
        {
            var cpfCadastrado = Clientes.Find(Clientes => Clientes.Cpf == cpf);

            if (cpfCadastrado == null)
            {
                return NotFound();
            }

            return Ok(cpfCadastrado);
        }

        [HttpPost("/cliente/inserir")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Cliente> Insert([FromBody] Cliente novoCliente)
        {
            Clientes.Add(novoCliente);
            return CreatedAtAction(nameof(Get), novoCliente);
        }

        [HttpPut("/cliente/{cpf}/atualizar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> Update(string cpf, Cliente cliente)
        {
            var cpfCadastrado = Clientes.Find(Clientes => Clientes.Cpf == cpf);

            if (cpfCadastrado == null)
            {
                return NotFound();
            }

            cpfCadastrado.Nome = cliente.Nome;
            cpfCadastrado.Cpf = cliente.Cpf;
            cpfCadastrado.DataNasc = cliente.DataNasc;

            return Ok(cpfCadastrado);
        }

        [HttpDelete("/cliente/{cpf}/deletar")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(string cpf)
        {
            var cpfCadastrado = Clientes.Find(Clientes => Clientes.Cpf == cpf);

            if (cpfCadastrado == null)
            {
                return NotFound();
            }

            Clientes.Remove(cpfCadastrado);

            return NoContent();
        }
    }
}