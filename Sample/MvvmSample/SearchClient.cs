using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvvmSample
{
    internal class SearchClient : ISearchClient
    {
        private readonly Random random = new Random();

        public async IAsyncEnumerable<SearchResults> SearchAsync(string searchText)
        {
            foreach (int result in Enumerable.Range(1, 10))
            {
                yield return new SearchResults
                {
                    Title = $"Result {result}",
                    Date = DateTime.Now,
                    Description = "Lorem ipsum dolor sit amor...",
                    Link = new Uri($"http://localhost/foo/{result}")
                };

                await Task.Delay(random.Next(10, 1000));
            }
        }

        //public async Task<IEnumerable<SearchResults>> SearchAsync(string searchText)
        //{
        //    var results = new List<SearchResults>();
        //    foreach (int result in Enumerable.Range(1, 10))
        //    {
        //        results.Add(new SearchResults
        //        {
        //            Title = $"Result {result}",
        //            Date = DateTime.Now,
        //            Description = "Lorem ipsum dolor sit amor...",
        //            Link = new Uri($"http://localhost/foo/{result}")
        //        });

        //        await Task.Delay(200);
        //    }
        //    return results;
        //}
    }
}
