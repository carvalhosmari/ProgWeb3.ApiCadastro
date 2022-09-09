using Microsoft.AspNetCore.Mvc;
using ProgWeb3.ApiCadastro.Core.Interface;
using ProgWeb3.ApiCadastro.Core.Model;
using ProgWeb3.ApiCadastro.Filters;

namespace ProgWeb3.ApiCadastro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(LogTempoExecucaoResourceFilter))]
    public class ClienteController : ControllerBase
    {
        public IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("/clientes/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(_clienteService.Get());
        }

        [HttpGet("/cliente/{cpf}/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> Get2(string cpf)
        {
            if (_clienteService.Get2(cpf) == null)
            {
                return NotFound();
            }

            return Ok(_clienteService.Get2(cpf));
        }

        [HttpPost("/cliente/inserir")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ServiceFilter(typeof(CpfExisteActionFilter))]
        public ActionResult<Cliente> Insert([FromBody] Cliente novoCliente)
        {
            if (!_clienteService.Insert(novoCliente))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Insert), novoCliente);
        }

        [HttpPut("/cliente/{cpf}/atualizar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(ValidaUpdateActionFilter))]
        public IActionResult Update(string cpf, Cliente clienteAtualizado)
        {
            _clienteService.Update(_clienteService.GetId(cpf), clienteAtualizado);

            return NoContent();
        }

        [HttpDelete("/cliente/{cpf}/deletar")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(string cpf)
        {
            if (!_clienteService.Delete(_clienteService.GetId(cpf)))
            {
                return NotFound();
            }

           return NoContent();
        }
    }
}