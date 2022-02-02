using System.Threading.Tasks;

using MvvmToolkit.Windowing;

namespace WindowApp;

internal static class WindowManagerExtensions
{
    public static async Task<DialogResult> ShowDialogAsync(this IWindowManager windowManager)
    {
        return await windowManager.ShowDialogAsync<DialogResult>("DialogWindow");
    }
}
