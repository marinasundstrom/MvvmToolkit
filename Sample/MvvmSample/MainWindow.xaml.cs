using System.Windows;

namespace MvvmSample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new SearchViewModel(
            new SearchClient());
    }
}
