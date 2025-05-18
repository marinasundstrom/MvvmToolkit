using System.Threading.Tasks;

using FlaUI.Core.AutomationElements;

using Xunit;

namespace MvvmSample.UITests;

public class MainUITest : TestsBase
{
    private TextBox SearchTextBoxElement => SearchTextBox.AsTextBox();
    private Button SearchButtonElement => SearchButton.AsButton();

    [Fact(DisplayName = "Search button is disabled by default")]
    public void SearchButtonIsDisabledByDefault()
    {
        Assert.False(SearchButtonElement.IsEnabled);
    }

    [Fact(DisplayName = "Enter text and Search button is enabled")]
    public void InputTextAndSearchButtonNotDisabled()
    {
        SearchTextBoxElement.Enter("Foo");

        Assert.True(SearchButtonElement.IsEnabled);
    }

    [Fact(DisplayName = "Clear input box and Search button is disabled")]
    public void ClearInputBoxAndSearchButtonIsDisabled()
    {
        SearchTextBoxElement.Text = ""; // Clears the text

        Assert.False(SearchButtonElement.IsEnabled);
    }

    [Fact(DisplayName = "Enter text, click Search button and result loads")]
    public async Task InputTextAndClickSearchButtonAndResultLoads()
    {
        SearchTextBoxElement.Enter("Foo");
        SearchButtonElement.Click();

        await Task.Delay(1000); // Consider replacing with polling logic if flaky

        var resultItem = SearchResults.FindFirstDescendant(cf => cf.ByName("Result 1"));

        Assert.NotNull(resultItem);
    }
}