using System;
using System.IO;

using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

using Xunit;

namespace MvvmSample.UITests;

public abstract class TestsBase : IDisposable
{
    private static Application? _application;
    private static AutomationBase? _automation;
    private static Window? _mainWindow;

    protected TestsBase()
    {
        if (_application == null)
        {
            string executablePath = Path.GetFullPath(@"..\..\..\..\MvvmSample\bin\Debug\net9.0-windows\MvvmSample.exe");

            _application = Application.Launch(executablePath);
            _automation = new UIA3Automation();
            _mainWindow = _application.GetMainWindow(_automation);

            Assert.NotNull(_mainWindow);
        }
    }

    protected Window MainWindow => _mainWindow!;

    public TextBox SearchTextBox =>
        MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("SearchTextBox"))!.AsTextBox();

    public Button SearchButton =>
        MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("SearchButton"))!.AsButton();

    public ListBox SearchResults =>
        MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("SearchResults"))!.AsListBox();

    public void Dispose()
    {
        _automation?.Dispose();
        _application?.Close();
        _application = null;
        _automation = null;
        _mainWindow = null;
    }
}