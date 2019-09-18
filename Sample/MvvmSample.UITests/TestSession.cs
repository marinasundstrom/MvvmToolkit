using System;
using System.IO;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using Xunit;

namespace MvvmSample.UITests
{
    public abstract class TestsBase : IDisposable
    {
        // Note: append /wd/hub to the URL if you're directing the test at Appium
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4727";

        protected static WindowsDriver<WindowsElement> session;

        protected TestsBase()
        {
            if (session == null)
            {
                string executablePath = Path.GetFullPath(@"..\..\..\..\MvvmSample\bin\Debug\netcoreapp3.0\MvvmSample.exe");


                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", executablePath);
                appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);

                Assert.NotNull(session);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            }
        }

        public void Dispose()
        {
            // Close the application and delete the session
            if (session != null)
            {
                session.Quit();
                session = null;
            }
        }
    }
}
