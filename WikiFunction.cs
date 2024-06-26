using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.Design;

namespace WikiSQL.Function
{
    public class WikiFunction
    {
        private readonly ILogger _logger;

        public WikiFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<WikiFunction>();
        }
        [Function("WikiFunction")]
        [SqlOutput("[dbo].[wikipedia_weather_articles]", "SqlConnectionString")]
        public async Task<IEnumerable<Article>> Run(
            [SqlTrigger("[dbo].[wikipedia_weather_articles]", "SqlConnectionString")] IReadOnlyList<SqlChange<Article>> changes, FunctionContext context)
        {
            _logger.LogInformation("SQL Changes: " + JsonConvert.SerializeObject(changes));

            //extract the changes from the trigger that are insert operations
            var insertChanges = changes.Where(c => c.Operation == SqlChangeOperation.Insert);

            var items = await ProcessArticles(changes);
            return items; //update table
        }


        private async Task<List<Article>> ProcessArticles(IReadOnlyList<SqlChange<Article>> changes)
        {
            List<Article> articles = new List<Article>();
            foreach (var change in changes)
            {
                if (change.Operation == SqlChangeOperation.Insert)
                {
                    var a = await GetWikiDetails(change.Item.title, change.Item.id);
                    _logger.LogInformation("Item: " + JsonConvert.SerializeObject(change.Item));
                    articles.Add(a);
                }
            }
            return articles;
        }

        private async Task<Article> GetWikiDetails(string? title, int? id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://api.wikimedia.org/core/v1/wikipedia/en/page/{title}/description");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadFromJsonAsync<Article>();

                Article article = new Article
                {
                    id = id,
                    url = "https://en.wikipedia.org/wiki/" + title,
                    title = title,
                    description = responseBody.description
                };

                return article;
            }
        }
    }
}
