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
    public static class MessageEdit
    {
        [FunctionName("MessageEdit")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "message/{id}")] HttpRequest req,
            ILogger log, int id)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            MessageModel data = JsonSerializer.Deserialize<MessageModel>(requestBody, serializeOptions);

            var messageModel = MessageData.EditMessage(id, data.Message);

            return new OkObjectResult(messageModel);
        }
    }
}
