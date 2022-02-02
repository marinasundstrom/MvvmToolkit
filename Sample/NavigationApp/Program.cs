using System;

namespace NavigationApp;

internal static class Program
{
    [STAThread]
    private static int Main(string[] args)
    {
        var app = new App();
        return app.Run();
    }
}
