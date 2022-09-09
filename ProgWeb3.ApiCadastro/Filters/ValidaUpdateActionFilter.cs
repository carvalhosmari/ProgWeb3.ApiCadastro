using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProgWeb3.ApiCadastro.Core.Interface;

namespace ProgWeb3.ApiCadastro.Filters
{
    public class ValidaUpdateActionFilter : IActionFilter
    {
        public IClienteService _clienteService;

        public ValidaUpdateActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var cpf = context.ActionArguments["cpf"].ToString();

            if (_clienteService.Get2(cpf) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
