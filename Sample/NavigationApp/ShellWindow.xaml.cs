using System.Windows;

namespace NavigationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShellWindow : Window
    {
        public ShellWindow(ShellViewModel shellViewModel)
        {
            InitializeComponent();

            DataContext = shellViewModel;

            Loaded += ShellWindow_Loaded;
        }

        private void ShellWindow_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as ShellViewModel).Initialize();
        }
    }
}
