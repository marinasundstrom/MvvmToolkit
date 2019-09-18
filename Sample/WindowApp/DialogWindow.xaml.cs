using MvvmToolkit.Windowing.WPF;

namespace WindowApp
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : BaseDialog<DialogResult>
    {
        public DialogWindow(DialogViewModel dialogViewModel)
            : base(dialogViewModel)
        {
            InitializeComponent();
        }
    }
}
