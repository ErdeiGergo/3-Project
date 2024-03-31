using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace _3_Project
{
    class Character
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int Strength { get; set; }
        public int Luck { get; set; }
        public int Agility { get; set; }

        public string Kaszt { get; set; }
        
        public string Race { get; set; }

        public Character(string name, string kaszt, string race, int strength, int luck, int agility) {
            Name = name;
            Kaszt = kaszt;
            Race = race;
            Strength = strength;
            Luck = luck;
            Agility = agility;
            Source = "";
        }

        public Character(string name, string source, int maxHp, int currentHp, int strength, int luck, int agility)
        {
            Name = name;
            Source = source;
            MaxHp = maxHp;
            CurrentHp = currentHp;
            Strength = strength;
            Luck = luck;
            Agility = agility;
            Kaszt = "warrior";
            Race = "human";
        }
    }
}
