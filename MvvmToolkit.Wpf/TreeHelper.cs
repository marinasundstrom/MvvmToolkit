using System.Windows;
using System.Windows.Media;

namespace MvvmToolkit.Wpf;

public static class TreeHelper
{
    public static T GetParent<T>(DependencyObject child)
        where T : DependencyObject
    {
        DependencyObject parentObject = VisualTreeHelper.GetParent(child);

        if (parentObject == null)
        {
            return null;
        }

        var parent = parentObject as T;
        if (parent != null)
        {
            return parent;
        }
        else
        {
            return GetParent<T>(parentObject);
        }
    }
}
