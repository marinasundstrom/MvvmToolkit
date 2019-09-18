using MvvmToolkit.Navigation.WPF;

namespace NavigationApp
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : BasePage
    {
        public MainPage(MainViewModel mainViewModel)
            : base(mainViewModel)
        {
            InitializeComponent();
        }
    }
}
