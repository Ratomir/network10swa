using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace api
{
    public static class MessageCreate
    {
        [FunctionName("MessageCreate")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "message")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            MessageModel data = JsonSerializer.Deserialize<MessageModel>(requestBody, serializeOptions);
            MessageData.AddMessage(data);

            return new OkObjectResult(data);
        }
    }
}
