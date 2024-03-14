using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            Kezdes();
        }

        private void Kezdes()
        {
            string _nev = "Bela";


            Image _kep = new Image();
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream iconStream = asm.GetManifestResourceStream("Kepek/test.jpg");
            PngBitmapDecoder iconDecoder = new PngBitmapDecoder(iconStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            ImageSource iconSource = iconDecoder.Frames[0];
            _kep.Source = iconSource;

            int _maxHp = 150;
            int _ero = 10;
            int _szerencse = 2;
            int _gyorsasag = 6;
            Karakter teszt = new Karakter(_nev, _kep, _maxHp, _ero, _szerencse, _gyorsasag);

            PlayerKep = teszt.Kep;
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
