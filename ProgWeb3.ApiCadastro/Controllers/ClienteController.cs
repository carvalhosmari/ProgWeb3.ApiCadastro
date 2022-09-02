using Microsoft.AspNetCore.Mvc;
using ProgWeb3.ApiCadastro.Repository;

namespace ProgWeb3.ApiCadastro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;

        public List<Cliente> Clientes { get; set; }

        public RepositorioCliente _repoCliente;

        public ClienteController(IConfiguration configuration)
        {
            Clientes = new List<Cliente>();
            _repoCliente = new RepositorioCliente(configuration);

        }

        [HttpGet("/clientes/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(_repoCliente.Get());
        }

        [HttpGet("/cliente/{cpf}/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> Get2(string cpf)
        {
            if (_repoCliente.Get2(cpf) == null)
            {
                return NotFound();
            }

            return Ok(_repoCliente.Get2(cpf));
        }

        [HttpPost("/cliente/inserir")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Cliente> Insert([FromBody] Cliente novoCliente)
        {
            if (!_repoCliente.Insert(novoCliente))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Insert), novoCliente);
        }

        [HttpPut("/cliente/{cpf}/atualizar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(string cpf, Cliente clienteAtualizado)
        {
            if (!_repoCliente.Update(_repoCliente.GetId(cpf), clienteAtualizado))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("/cliente/{cpf}/deletar")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(string cpf)
        {
            if (!_repoCliente.Delete(_repoCliente.GetId(cpf)))
            {
                return NotFound();
            }

           return NoContent();
        }
    }
}