using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace WikiSQL.Function
{
    public class WikiInputFunction
    {
        private readonly ILogger _logger;

        public WikiInputFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<WikiInputFunction>();
        }

        [Function("WikiInputFunction")]
        [SqlOutput("[dbo].[wikipedia_weather_articles]", "SqlConnectionString")]
        public async Task<Article> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger with SQL Output Binding function processed a request.");

            var item = await req.ReadFromJsonAsync<Article>() ?? new Article
            {
                title = "Weather",
                url = "",
                description = ""
            };
            
            return item;
        }      
    }
}