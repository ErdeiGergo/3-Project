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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace _3_Project
{
    /// <summary>
    /// Interaction logic for KarakterGen.xaml
    /// </summary>
    public partial class KarakterGen : Window
    {
        public const int maxPoints = 15;
        public int strenght;
        public int agility;
        public int luck;
        public string kaszt;
        public string race;
        public string name;
        private RandomNameManager randomNameManager;
        

        public KarakterGen()
        {
            InitializeComponent();
            strenght = 3;
            agility = 3;
            luck = 3;
            kaszt = "warrior";
            race = "human";
            randomNameManager = new RandomNameManager();
        }

        public void IncLuck(object sender, RoutedEventArgs e)
        {
           if (this.RemainingPoints() > 0)
            {
                this.luck++;
                this.RefreshPoints(); ;
            }
        }

        public void DecLuck(object sender, RoutedEventArgs e)
        {
            if (this.luck > 0)
            {
                this.luck--;
                this.RefreshPoints();
            }
        }

        public void IncStrength(object sender, RoutedEventArgs e)
        {
            if (this.RemainingPoints() > 0)
            {
                this.strenght++;
                this.RefreshPoints();
            }
        }

        public void DecStrength(object sender, RoutedEventArgs e)
        {
            if (this.strenght > 0)
            {
                this.strenght--;
                this.RefreshPoints();
            }
        }

        public void IncAgility(object sender, RoutedEventArgs e)
        {
            if (this.RemainingPoints() > 0)
            {
                this.agility++;
                this.RefreshPoints();
            }
        }

        public void DecAgility(object sender, RoutedEventArgs e)
        {
            if (this.agility > 0)
            {
                this.agility--;
                this.RefreshPoints();
            }
        }

        public void ChooseWarrior(object sender, RoutedEventArgs e)
        {
            this.kaszt = "warrior";
            this.strenght = 5;
            this.agility = 2;
            this.luck = 2;
            RefreshPoints();
        }

        public void ChooseMage(object sender, RoutedEventArgs e)
        {
            this.kaszt = "mage";
            this.strenght = 2;
            this.agility = 3;
            this.luck = 4;
            RefreshPoints();
        }

        public void ChooseHunter(object sender, RoutedEventArgs e)
        {
            this.kaszt = "hunter";
            this.strenght = 2;
            this.agility = 6;
            this.luck = 1;
            RefreshPoints();
        }

        public void ChooseHuman(object sender, RoutedEventArgs e)
        {
            this.race = "human";
        }

        public void ChooseOrk(object sender, RoutedEventArgs e)
        {
            this.race = "ork";
        }
        public void ChooseGnome(object sender, RoutedEventArgs e)
        {
            this.race = "gnome";
        }
        public void ChooseElf(object sender, RoutedEventArgs e)
        {
            this.race = "elf";
        }

        public void GetRandomName(object sender, RoutedEventArgs e)
        {
            NameInput.Text = randomNameManager.GetRandomName();
        }

        public void SaveCharacter(object sender, RoutedEventArgs e)
        {
            this.name = NameInput.Text;
            if (!this.Valid())
            {
                NameInput.Text = "Please enter your name here...";
            }
            else
            {
                Character newCharacter = new Character(this.name, this.kaszt, this.race, this.strenght, this.luck, this.agility);
                Console.WriteLine(newCharacter.ToString());
                CharacterManager.SaveCharacter(newCharacter);
            }
        }


        // Megmondja, hogy mennyi pontot tudsz meg felhasznalni a skillekhez
        private int RemainingPoints()
        {
            return maxPoints - this.strenght - this.agility - this.luck;
        }

        // Frissiot a UIon a felhasznalhato pontok szamat
        private void RefreshAvailablePoints()
        {
            AvailablePoints.Text =  "Remaining Points: " + RemainingPoints().ToString();
        }

        // Frissito a UIon a szovegben a pontok szamat

        private void RefreshPoints()
        {
            AgilityText.Text = this.agility.ToString();
            StrengthText.Text = this.strenght.ToString();
            LuckText.Text = this.luck.ToString();
            RefreshAvailablePoints();
        }

        // Megnezi, ha helyesek e az adatok 
        // Pl adtal e meg neki nevet, de lehet boviteni, ha teszunk bele tobb dolgot pl Karakter Leiras stb..
        private bool Valid()
        {
            if (this.name.Equals(""))
            {
                return false;
            }
            
            return true;
        }

    }
}
