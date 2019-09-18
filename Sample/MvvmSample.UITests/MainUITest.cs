using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using Xunit;

namespace MvvmSample.UITests
{
    public class MainUITest : TestsBase
    {
        [Fact(DisplayName = "Search button is disabled by default")]
        public void SearchButtonIsDisabledByDefault()
        {
            Assert.False(session.FindElementByAccessibilityId("SearchButton").Enabled);
        }

        [Fact(DisplayName = "Enter text and Search button is enabled")]
        public void InputTextAndSearchButtonNotDisabled()
        {
            session.FindElementByAccessibilityId("SearchTextBox").SendKeys("Foo");

            Assert.True(session.FindElementByAccessibilityId("SearchButton").Enabled);
        }

        [Fact(DisplayName = "Clear input box and Search button is disabled")]
        public void ClearInputBoxAndSearchButtonIsDisabled()
        {
            session.FindElementByAccessibilityId("SearchTextBox").Clear();

            Assert.False(session.FindElementByAccessibilityId("SearchButton").Enabled);
        }

        [Fact(DisplayName = "Enter text, click Search button and result loads")]
        public async Task InputTextAndClickSearchButtonAndResultLoads()
        {
            session.FindElementByAccessibilityId("SearchTextBox").SendKeys("Foo");
            session.FindElementByAccessibilityId("SearchButton").Click();

            await Task.Delay(1000);

            WindowsElement searchResults = session.FindElementByAccessibilityId("SearchResults");

            AppiumWebElement resultItem = searchResults.FindElementByXPath("//*[contains(@Name, \"Result 1\")]");

            Assert.NotNull(resultItem);
        }
    }
}
