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

namespace _3_Project
{
    /// <summary>
    /// Interaction logic for Harc.xaml
    /// </summary>
    public partial class Harc : Window
    {
        public Harc()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
