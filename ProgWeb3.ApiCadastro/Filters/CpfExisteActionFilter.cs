using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProgWeb3.ApiCadastro.Core.Interface;
using ProgWeb3.ApiCadastro.Core.Model;

namespace ProgWeb3.ApiCadastro.Filters
{
    public class CpfExisteActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;

        public CpfExisteActionFilter(IClienteService clienteService)
        { 
            _clienteService = clienteService;
        }
    
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cliente novoCliente = (Cliente)context.ActionArguments["novoCliente"];

            if (_clienteService.Get2(novoCliente.Cpf) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
