using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace api
{
    public static class MessageDelete
    {
        [FunctionName("MessageDelete")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "message/{id}")] HttpRequest req,
            ILogger log, int id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            MessageData.DeleteMessage(id);

            return new OkResult();
        }
    }
}
