using MvvmToolkit.Windowing.WPF;

namespace WindowApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : BaseWindow
{
    public MainWindow(MainViewModel mainViewModel)
             : base(mainViewModel)
    {
        InitializeComponent();
    }
}
