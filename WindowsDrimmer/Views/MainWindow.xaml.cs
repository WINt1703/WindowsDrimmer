using System.Windows;
using System.Windows.Input;

namespace WindowsDimmer.Views
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

        private void HiddenButton(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private void CloseButton(object sender, RoutedEventArgs e) => this.Close();

        private void MinMaxButton(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal) this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;                       
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) => this.DragMove();
    }
}
