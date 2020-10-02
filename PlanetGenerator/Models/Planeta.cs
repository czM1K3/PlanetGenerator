using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlanetGenerator.Models
{
    class Planeta
    {
        public Planeta(Random rnd, int id)
        {
            Pozice = new Souradnice(rnd);
            UID = id;
            ExistujeZivot = rnd.Next(0, 2) == 0;
            VzdalenostOdZeme = rnd.Next();
            generateName(rnd);
        }

        public string Nazev { get; private set; }
        public int UID { get; private set; }
        public int VzdalenostOdZeme { get; private set; }
        public bool ExistujeZivot { get; private set; }
        public Souradnice Pozice { get; private set; }

        void generateName(Random rnd)
        {
            string name = "";
            int cast1 = rnd.Next(2, 5);
            for (int i = 0; i < cast1; i++)
            {
                name += (char)rnd.Next(65, 91);
            }
            name += "-"+ rnd.Next(1000, 1000000);
            Nazev = name;
        }
    }

    struct Souradnice
    {
        public Souradnice(Random rnd)
        {
            X = rnd.Next();
            Y = rnd.Next();
            Z = rnd.Next();
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
    }
}
