using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BeaverCalc
{
    public static class Addition
    {
        [FunctionName("Addition")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string first = req.Query["first"];
            string second = req.Query["second"];

            double varone;
            if (!double.TryParse(first, out varone)) 
            {
                return new BadRequestObjectResult("First value is not a valid number");
            }

            double vartwo;
            if (!double.TryParse(second, out vartwo))
            {
                return new BadRequestObjectResult("Second value is not a valid number");
            }

            return new OkObjectResult((varone + vartwo).ToString());
        }
    }
}
