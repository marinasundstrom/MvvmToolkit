using Reqnroll;

using Shouldly;

namespace MvvmSample.UITests.StepDefinitions;

[Scope(Scenario = "Cannot search when not having entered search term")]
[Binding]
public class SearchSteps : TestsBase
{
    [Given(@"that you have not entered a search term")]
    public void GivenThatYouHaveNotEnteredASearchTerm()
    {
        SearchTextBox.Text.ShouldBeEmpty();
    }

    [Then(@"you should not be able to search")]
    public void ThenYouShouldNotBeAbleToSearch()
    {
        SearchButton.IsEnabled.ShouldBeFalse();
    }
}