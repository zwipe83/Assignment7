using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment7.UI.Wpf.Windows;
using WpfApp2;

namespace Assignment7.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnSightings_Click(object sender, RoutedEventArgs e)
        {
            SightingsWindow window = new SightingsWindow();
            window.ShowDialog();
        }

        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            AnimalWindow window = new AnimalWindow();
            window.ShowDialog();
        }

        private void btnAddSighting_Click(object sender, RoutedEventArgs e)
        {
            SightingWindow window = new SightingWindow();
            window.ShowDialog();
        }
    }
}