using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _3_Project
{
    class Karakter
    {
        public string Nev { get; set; }
        public string Forras { get; set; }
        public int MaxHp { get; set; }
        public int Ero { get; set; }
        public int Szerencse { get; set; }
        public int Gyorsasag { get; set; }

        public Karakter(string nev, string forras, int maxHp, int ero, int szerencse, int gyorsasag)
        {
            Nev = nev;
            Forras = forras;
            MaxHp = maxHp;
            Ero = ero;
            Szerencse = szerencse;
            Gyorsasag = gyorsasag;
        }
    }
}
