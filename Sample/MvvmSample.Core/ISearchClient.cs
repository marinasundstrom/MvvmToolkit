using System.Collections.Generic;

namespace MvvmSample
{
    public interface ISearchClient
    {
        IAsyncEnumerable<SearchResults> SearchAsync(string searchText);

        //Task<IEnumerable<SearchResults>> SearchAsync(string searchText);
    }
}