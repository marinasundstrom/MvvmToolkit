using Reqnroll;

using Shouldly;

namespace MvvmSample.UITests.StepDefinitions;

[Scope(Scenario = "Cannot search when not having entered search term")]
[Binding]
public class SearchSteps : TestsBase
{
    [Given(@"that the Search box is empty")]
    public void GivenThatTheSearchBoxIsEmpty()
    {
        SearchTextBox.Text.ShouldBeEmpty();
    }

    [Then(@"the Search button should be disabled")]
    public void ThenTheSearchButtonShouldBeDisabled()
    {
        SearchButton.IsEnabled.ShouldBeFalse();
    }
}