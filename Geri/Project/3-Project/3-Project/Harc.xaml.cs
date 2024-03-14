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

        int PlayerCurrentHp;
        int EnemyCurrentHp;
        public Harc()
        {
            InitializeComponent();
            Kezdes();


        }

        private void Kezdes()
        {
            string _nev = "Bela";
            string _forras = @"C:\Users\erdei.gergo.janos\source\repos\3-Project\Geri\Project\3-Project\3-Project\kepek\test.jpg";
            int _maxHp = 150;
            int _ero = 10;
            int _szerencse = 2;
            int _gyorsasag = 6;
            Karakter teszt = new Karakter(_nev, _forras, _maxHp, _ero, _szerencse, _gyorsasag);

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(teszt.Forras);
            logo.EndInit();

            PlayerCurrentHp = teszt.MaxHp;


            PlayerKep.Source = logo;
            PlayerName.Content = teszt.Nev;
            playerPB.Maximum = teszt.MaxHp;
            playerPB.Value = PlayerCurrentHp;
            playerHPLabel.Content = PlayerCurrentHp;

            string _Enev = "Viking";
            string _Eforras = @"C:\Users\erdei.gergo.janos\source\repos\3-Project\Geri\Project\3-Project\3-Project\kepek\enemy.jfif";
            int _EmaxHp = 100;
            int _Eero = 5;
            int _Eszerencse = 0;
            int _Egyorsasag = 3;
            Karakter tesztEnemy = new Karakter(_Enev, _Eforras, _EmaxHp, _Eero, _Eszerencse, _Egyorsasag);

            BitmapImage enemyImg = new BitmapImage();
            enemyImg.BeginInit();
            enemyImg.UriSource = new Uri(tesztEnemy.Forras);
            enemyImg.EndInit();

            PlayerCurrentHp = tesztEnemy.MaxHp;


            EnemyKep.Source = enemyImg;
            EnemyName.Content = tesztEnemy.Nev;
            enemyPB.Maximum = tesztEnemy.MaxHp;
            enemyPB.Value = PlayerCurrentHp;
            enemyHPLabel.Content = PlayerCurrentHp;
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
