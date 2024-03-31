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
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace _3_Project
{
    /// <summary>
    /// Interaction logic for Harc.xaml
    /// </summary>
    public partial class Harc : Window
    {
        string path = "D:\\Suli\\Project\\Geri\\Project\\3-Project\\3-Project\\kepek\\";

        //Timer
		int left = 0;
        int right = 0;
		int playerSpeed = 50;
        int enemySpeed = 50;


		public Harc()
        {
            InitializeComponent();
            Start();
            Wait();
		}

        Character test;
        Character testEnemy;

		private void Start()
        {
            string _name = "Szebasztian";
            string _source = path + "test.jpg";
            int _maxHp = 150;
            int _currentHp = _maxHp;
            int _strength = 10;
            int _luck = 2;
            int _agility = 6;
			test = new (_name, _source, _maxHp, _currentHp, _strength, _luck, _agility);

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
            testEnemy = new Character(_enemyName, _enemySource, _enemyMaxHp, _enemyCurrentHp, _enemyStrength, _enemyLuck, _enemyAgility);

            BitmapImage EnemyImage = new BitmapImage();
            EnemyImage.BeginInit();
            EnemyImage.UriSource = new Uri(testEnemy.Source);
            EnemyImage.EndInit();

            EnemyKep.Source = EnemyImage;
            EnemyName.Content = testEnemy.Name;
            enemyPB.Maximum = testEnemy.MaxHp;
            enemyPB.Value = testEnemy.CurrentHp;
            enemyHPLabel.Content = testEnemy.CurrentHp;
        }

        private void Hit()
        {
			var timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromMilliseconds(10); 
			timer.Start();
			timer.Tick += _timer_Tick;
            Damage(test, testEnemy);
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

        public async void Wait()
        {
			TamadasTipusok tamadasTipusok = new TamadasTipusok();
			tamadasTipusok.Show();
			await Task.Delay(TimeSpan.FromSeconds(10));
            Hit();
		}

		private void Damage(Character player, Character bot)
        {
            bot.CurrentHp -= player.Strength;
			player.CurrentHp -= bot.Strength;
            Refresh(player, bot);
		}
		private void Refresh(Character player, Character bot)
        {
			playerPB.Value = player.CurrentHp;
			playerHPLabel.Content = player.CurrentHp;

			enemyPB.Value = bot.CurrentHp;
			enemyHPLabel.Content = bot.CurrentHp;
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
