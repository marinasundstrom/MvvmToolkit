using System.Threading.Tasks;

using Reqnroll;

using Shouldly;

namespace MvvmSample.UITests.StepDefinitions;

[Scope(Scenario = "Search box is disabled when searching")]
[Binding]
public class Search2Steps : TestsBase
{
    [Given(@"that I have entered something in the Search box")]
    public void GivenThatIHaveEnteredSomethingInTheSearchBox()
    {
        SearchTextBox.Enter("Foo");
    }

    [When(@"I click the Search button")]
    public async Task WhenIClickTheSearchButton()
    {
        SearchButton.Click();
        await Task.Delay(50); // allow time for UI update
    }

    [Then(@"the Search box should be disabled")]
    public void ThenTheSearchBoxShouldBeDisabled()
    {
        SearchTextBox.IsEnabled.ShouldBeFalse();
    }
}