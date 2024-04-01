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
using System.Windows.Threading;

namespace _3_Project
{
	/// <summary>
	/// Interaction logic for TamadasTipusok.xaml
	/// </summary>
	public partial class TamadasTipusok : Window
	{
		public string tamadasTipus { get; set; }

		public TamadasTipusok()
		{
			InitializeComponent();
			Wait();
			WaitingBar();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			tamadasTipus = "gyors";
			TamadasLeirasa();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			tamadasTipus = "normal";
			TamadasLeirasa();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			tamadasTipus = "eros";
			TamadasLeirasa();
		}

		private async void Wait()
		{
			await Task.Delay(TimeSpan.FromSeconds(8));
			this.Close();
		}

		private void TamadasLeirasa()
		{
			switch (tamadasTipus)
			{
				case "gyors":
					tamadasLeirasaLabel.Content = "Gyors támadás: kisebb sebzés, de nagyobb esély a sikeres találatra.";
					break;
				case "normal":
					tamadasLeirasaLabel.Content = "Normál támadás: normál sebzés, átlagos eséllyel talál sikerrel.";
					break;
				case "eros":
					tamadasLeirasaLabel.Content = "Erős támadás: nagy sebzés, de kisebb eséllyel talál be.";
					break;
			}
		}

		private void WaitingBar()
		{
			var timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromMilliseconds(10);
			timer.Start();
			timer.Tick += _timer_Tick;
		}

		private void _timer_Tick(object? sender, EventArgs e)
		{
			pbTime.Value -= 20;
		}

	}
}
