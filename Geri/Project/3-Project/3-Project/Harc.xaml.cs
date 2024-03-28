using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace _3_Project
{
    /// <summary>
    /// Interaction logic for Harc.xaml
    /// </summary>
    public partial class Harc : Window
    {
        string path = "D:\\Suli\\Project\\Geri\\Project\\3-Project\\3-Project\\kepek\\";

		int left = 0; // this is the left int variable with the value 0
        int right = 0;
		int playerSpeed = 50; // this integer called speed will determine how fast the blue circle will go
        int enemySpeed = 50;


		public Harc()
        {
            InitializeComponent();
            Start();
		}

		private void Start()
        {
            string _name = "Szebasztian";
            string _source = path + "test.jpg";
            int _maxHp = 150;
            int _currentHp = _maxHp;
            int _strength = 10;
            int _luck = 2;
            int _agility = 6;
			Character test = new Character(_name, _source, _maxHp, _currentHp, _strength, _luck, _agility);

            BitmapImage PlayerImage = new BitmapImage();
            PlayerImage.BeginInit();
            PlayerImage.UriSource = new Uri(test.Source);
            PlayerImage.EndInit();

            PlayerKep.Source = PlayerImage;
            PlayerName.Content = test.Name;
            playerPB.Maximum = test.MaxHp;
            playerPB.Value = test.CurrentHp;
            playerHPLabel.Content = test.CurrentHp;

            string _enemyName = "Viking";
            string _enemySource = path + "enemy.jfif";
            int _enemyMaxHp = 100;
            int _enemyCurrentHp = _enemyMaxHp;
            int _enemyStrength = 5;
            int _enemyLuck = 0;
            int _enemyAgility = 3;
            Character testEnemy = new Character(_enemyName, _enemySource, _enemyMaxHp, _enemyCurrentHp, _enemyStrength, _enemyLuck, _enemyAgility);

            BitmapImage EnemyImage = new BitmapImage();
            EnemyImage.BeginInit();
            EnemyImage.UriSource = new Uri(testEnemy.Source);
            EnemyImage.EndInit();

            EnemyKep.Source = EnemyImage;
            EnemyName.Content = testEnemy.Name;
            enemyPB.Maximum = testEnemy.MaxHp;
            enemyPB.Value = testEnemy.CurrentHp;
            enemyHPLabel.Content = testEnemy.CurrentHp;


			var timer = new DispatcherTimer(); // creating a new timer
			timer.Interval = TimeSpan.FromMilliseconds(10); // this timer will trigger every 10 milliseconds
			timer.Start(); // starting the timer
			timer.Tick += _timer_Tick; // with each tick it will trigger this function


        }


		private void _timer_Tick(object? sender, EventArgs e)
		{
			left += playerSpeed;
            right += enemySpeed;
			PlayerKep.Margin = new Thickness(left, 0, 0, 0);
            EnemyKep.Margin = new Thickness(0, 0, right, 0);
			if (left > 750)
				playerSpeed = -10;
			if (left <= 30)
                playerSpeed = 0;
            if (right > 750)
                enemySpeed = -10;
            if (right <= 30)
                enemySpeed = 0;
		}



		

		private void Attack(Character p, Character e)
        {
            e.CurrentHp -= p.Strength;
			p.CurrentHp -= e.Strength;
		}
		private void Refresh(Character p, Character e)
        {
			playerPB.Value = p.CurrentHp;
			playerHPLabel.Content = p.CurrentHp;

			enemyPB.Value = e.CurrentHp;
			enemyHPLabel.Content = e.CurrentHp;

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
