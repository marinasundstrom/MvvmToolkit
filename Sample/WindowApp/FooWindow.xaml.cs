using MvvmToolkit.Windowing.WPF;

namespace WindowApp;

/// <summary>
/// Interaction logic for FooWindow.xaml
/// </summary>
public partial class FooWindow : BaseWindow
{
    public FooWindow(FooViewModel fooViewModel)
        : base(fooViewModel)
    {
        InitializeComponent();
    }
}
