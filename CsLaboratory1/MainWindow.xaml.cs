using System.Windows;

namespace CsLaboratory1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DateApplicationViewModel();
        }

    }
}
