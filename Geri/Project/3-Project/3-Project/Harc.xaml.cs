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
            Start();
		}

		private void Start()
        {
            string _name = "Szebasztian";
            string _source = @"D:\Suli\Project\Geri\Project\3-Project\3-Project\kepek\test.jpg";
            int _maxHp = 150;
            int _strength = 10;
            int _luck = 2;
            int _agility = 6;
			Character test = new Character(_name, _source, _maxHp, _strength, _luck, _agility);

            BitmapImage PlayerImage = new BitmapImage();
            PlayerImage.BeginInit();
            PlayerImage.UriSource = new Uri(test.Source);
            PlayerImage.EndInit();

            PlayerCurrentHp = test.MaxHp;


            PlayerKep.Source = PlayerImage;
            PlayerName.Content = test.Name;
            playerPB.Maximum = test.MaxHp;
            playerPB.Value = PlayerCurrentHp;
            playerHPLabel.Content = PlayerCurrentHp;

            string _enemyName = "Viking";
            string _enemySource = @"D:\Suli\Project\Geri\Project\3-Project\3-Project\kepek\enemy.jfif";
            int _enemyMaxHp = 100;
            int _enemyStrength = 5;
            int _enemyLuck = 0;
            int _enemyAgility = 3;
            Character testEnemy = new Character(_enemyName, _enemySource, _enemyMaxHp, _enemyStrength, _enemyLuck, _enemyAgility);

            BitmapImage EnemyImage = new BitmapImage();
            EnemyImage.BeginInit();
            EnemyImage.UriSource = new Uri(testEnemy.Source);
            EnemyImage.EndInit();

            PlayerCurrentHp = testEnemy.MaxHp;


            EnemyKep.Source = EnemyImage;
            EnemyName.Content = testEnemy.Name;
            enemyPB.Maximum = testEnemy.MaxHp;
            enemyPB.Value = PlayerCurrentHp;
            enemyHPLabel.Content = PlayerCurrentHp;
        }

        private void Attack()
        {

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
