using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace api
{
    public static class GetConfigurations
    {
        [FunctionName("GetConfigurations")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "configurations")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string configValue = Environment.GetEnvironmentVariable("superConfig");

            var arrayOfConfigs = new[] { configValue };

            return new OkObjectResult(arrayOfConfigs);
        }
    }
}
