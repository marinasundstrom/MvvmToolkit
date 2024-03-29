﻿using System.Threading.Tasks;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

using Xunit;

namespace MvvmSample.UITests;

public class MainUITest : TestsBase
{
    [Fact(DisplayName = "Search button is disabled by default", Skip = "Foo")]
    public void SearchButtonIsDisabledByDefault()
    {
        Assert.False(SearchButton.Enabled);
    }

    [Fact(DisplayName = "Enter text and Search button is enabled", Skip = "Foo")]
    public void InputTextAndSearchButtonNotDisabled()
    {
        SearchTextBox.SendKeys("Foo");

        Assert.True(SearchButton.Enabled);
    }

    [Fact(DisplayName = "Clear input box and Search button is disabled", Skip = "Foo")]
    public void ClearInputBoxAndSearchButtonIsDisabled()
    {
        SearchTextBox.Clear();

        Assert.False(SearchButton.Enabled);
    }

    [Fact(DisplayName = "Enter text, click Search button and result loads", Skip = "Foo")]
    public async Task InputTextAndClickSearchButtonAndResultLoads()
    {
        SearchTextBox.SendKeys("Foo");
        SearchButton.Click();

        await Task.Delay(1000);

        AppiumWebElement resultItem = SearchResults.FindElementByXPath("//*[contains(@Name, \"Result 1\")]");

        Assert.NotNull(resultItem);
    }
}
