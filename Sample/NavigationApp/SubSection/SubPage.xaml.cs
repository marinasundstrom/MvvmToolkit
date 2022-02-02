using MvvmToolkit.Navigation.WPF;

namespace NavigationApp.SubSection;

/// <summary>
/// Interaction logic for MainPage.xaml
/// </summary>
public partial class SubPage : BasePage
{
    public SubPage(SubViewModel subViewModel)
        : base(subViewModel)
    {
        InitializeComponent();
    }
}
