using System.Collections.Generic;
using System.Threading.Tasks;

using Moq;

using MvvmToolkit;

using Xunit;

namespace MvvmSample.Tests;

public class SearchViewModelTest
{
    [Fact(DisplayName = "SearchCommand cannot execute when SearchText is not set")]
    public void SearchCommandCanNotExecuteWhenSearchTextIsNotSet()
    {
        // Arrange
        var searchClientMock = new Mock<ISearchClient>();

        var searchViewModel = new SearchViewModel(searchClientMock.Object);

        // Act
        bool canExecute = (searchViewModel.SearchCommand as Command).CanExecute();

        // Assert
        Assert.False(canExecute);
    }

    [Fact(DisplayName = "SearchCommand can execute when SearchText is set")]
    public void SearchCommandCanExecuteWhenSearchTextIsSet()
    {
        // Arrange
        var searchClientMock = new Mock<ISearchClient>();

        var searchViewModel = new SearchViewModel(searchClientMock.Object)
        {
            SearchText = "Foo"
        };

        // Act
        bool canExecute = (searchViewModel.SearchCommand as Command).CanExecute();

        // Assert
        Assert.True(canExecute);
    }

    [Fact(DisplayName = "Executing SearchCommand yields SearchResults")]
    public async Task ExecutingSearchCommandYieldsSearchResults()
    {
        // Arrange
        var searchClientMock = new Mock<ISearchClient>();
        searchClientMock
            .Setup(scm => scm.SearchAsync(It.IsAny<string>()))
            .Returns(GetAsyncEnumerable());

        var searchViewModel = new SearchViewModel(searchClientMock.Object)
        {
            SearchText = "Foo"
        };

        // Act
        await (searchViewModel.SearchCommand as Command).Execute();

        // Assert
        Assert.Equal(3, searchViewModel.SearchResults.Count);
    }

    private async IAsyncEnumerable<SearchResults> GetAsyncEnumerable()
    {
        await Task.Delay(20);

        yield return new SearchResults();

        await Task.Delay(20);

        yield return new SearchResults();

        await Task.Delay(10);

        yield return new SearchResults();
    }
}
