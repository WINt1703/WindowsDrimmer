using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WindowsDrimmer.Config;

namespace WindowsDrimmer.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void HiddenButton(object sender, RoutedEventArgs e)
        {
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinMaxButton(object sender, RoutedEventArgs e)
        {
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
