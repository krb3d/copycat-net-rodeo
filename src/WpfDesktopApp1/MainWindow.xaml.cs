using System.Windows;
using WpfDesktopApp1.ViewModel;

namespace WpfDesktopApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(
            IMainWindowViewModel context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}
