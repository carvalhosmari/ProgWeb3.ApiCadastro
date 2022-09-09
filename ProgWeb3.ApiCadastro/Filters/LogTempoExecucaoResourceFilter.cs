using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ProgWeb3.ApiCadastro.Filters
{
    public class LogTempoExecucaoResourceFilter : IResourceFilter
    {
        Stopwatch stopwatch = new Stopwatch();
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            stopwatch.Stop();
            Console.WriteLine($"Tempo de execução: {stopwatch.ElapsedMilliseconds}ms");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            stopwatch.Start();
        }
    }
}
