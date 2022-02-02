using TechTalk.SpecFlow;
using Shouldly;
using System.Threading.Tasks;

namespace MvvmSample.UITests.StepDefinitions;

[Scope(Scenario = "Search box is disabled when searching")]
[Binding]
public class Search2Steps : TestsBase
{
    [Given(@"that i have entered something in the Search box")]
    public void GivenThatIHaveEnteredSomethingInTheSearchBox()
    {
        SearchTextBox.SendKeys("Foo");
    }

    [When(@"I click the Search button")]
    public async Task WhenIClickTheSearchButton() 
    {
        SearchButton.Click();

        await Task.Delay(50); 
    }

    [Then(@"the Search box should be disabled")]
    public void ThenTheSearchBoxShouldBeDisabled()
    {
        SearchTextBox.Enabled.ShouldBeFalse();
    }
}