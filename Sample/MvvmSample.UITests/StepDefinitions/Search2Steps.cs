using TechTalk.SpecFlow;
using Shouldly;
using System.Threading.Tasks;

namespace MvvmSample.UITests.StepDefinitions;

[Scope(Scenario = "Should not be able to search while search is being performed")]
[Binding]
public class Search2Steps : TestsBase
{
    [Given(@"that you have entered a search term")]
    public void ThatIHaveEnteredASearchTerm()
    {
        SearchTextBox.SendKeys("Foo");
    }

    [When(@"you initiate a new search")]
    public async Task WhenYouInitiateANewSearch() 
    {
        SearchButton.Click();

        await Task.Delay(50); 
    }

    [Then(@"you cannot start another search")]
    public void ThenYouCannotStartAnotherSearch()
    {
        SearchTextBox.Enabled.ShouldBeFalse();
    }
}