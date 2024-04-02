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
		string path = "D:\\Suli\\Project\\new\\Geri\\Project\\3-Project\\3-Project\\kepek\\";

		Character player;
		Character enemy;

		int rounds = 1;

		int left = 0;
		int right = 0;
		int playerSpeed = 60;
		int enemySpeed = 60;

		string tamadasTipusa;

		public Harc()
		{
			InitializeComponent();
			Start();
			Round();
		}

		private void Start()
		{
			string _name = "Szebasztian";
			string _source = path + "test.jpg";
			int _maxHp = 150;
			int _currentHp = _maxHp;
			int _strength = 30;
			int _luck = 2;
			int _agility = 6;
			player = new(_name, _source, _maxHp, _currentHp, _strength, _luck, _agility);

			BitmapImage PlayerImage = new BitmapImage();
			PlayerImage.BeginInit();
			PlayerImage.UriSource = new Uri(player.Source);
			PlayerImage.EndInit();

			PlayerKep.Source = PlayerImage;
			PlayerName.Content = player.Name;
			playerPB.Maximum = player.MaxHp;
			playerPB.Value = player.CurrentHp;
			playerHPLabel.Content = player.CurrentHp;

			string _enemyName = "Viking";
			string _enemySource = path + "enemy.jfif";
			int _enemyMaxHp = 100;
			int _enemyCurrentHp = _enemyMaxHp;
			int _enemyStrength = 5;
			int _enemyLuck = 0;
			int _enemyAgility = 3;
			enemy = new Character(_enemyName, _enemySource, _enemyMaxHp, _enemyCurrentHp, _enemyStrength, _enemyLuck, _enemyAgility);

			BitmapImage EnemyImage = new BitmapImage();
			EnemyImage.BeginInit();
			EnemyImage.UriSource = new Uri(enemy.Source);
			EnemyImage.EndInit();

			EnemyKep.Source = EnemyImage;
			EnemyName.Content = enemy.Name;
			enemyPB.Maximum = enemy.MaxHp;
			enemyPB.Value = enemy.CurrentHp;
			enemyHPLabel.Content = enemy.CurrentHp;
		}

		private async void Round()
		{
			RoundCounter();
			await Fight();
			while (player.CurrentHp > 0 && enemy.CurrentHp > 0)
			{
				RoundCounter();
				await Fight();
				rounds++;
			}
		}

		private async Task Fight()
		{
			await Task.Delay(TimeSpan.FromSeconds(2));
			TamadasTipusok tamadasTipusok = new TamadasTipusok();
			tamadasTipusok.ShowDialog();
			tamadasTipusa = tamadasTipusok.tamadasTipus;
			Hit();
		}

		private void Hit()
		{
			left = 0;
			right = 0;
			playerSpeed = 50;
			enemySpeed = 50;

			var timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromMilliseconds(10);
			timer.Start();
			timer.Tick += _timer_Tick;

			Damage();
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

		private void Damage()
		{
			int playerDamage;
			switch (tamadasTipusa)
			{
				case "gyors":
					playerDamage = player.Strength - 5;
					break;
				case "normal":
					playerDamage = player.Strength;
					break;
				case "eros":
					playerDamage = player.Strength + 5;
					break;
				default:
					playerDamage = player.Strength;
					break;
			}
			enemy.CurrentHp -= playerDamage;

			player.CurrentHp -= enemy.Strength;
			Refresh();
		}

		private void Refresh()
		{
			playerPB.Value = player.CurrentHp;
			playerHPLabel.Content = player.CurrentHp;

			enemyPB.Value = enemy.CurrentHp;
			enemyHPLabel.Content = enemy.CurrentHp;
		}

		private void RoundCounter()
		{
			roundsLabel.Content = rounds;
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
