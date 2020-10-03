using PlanetGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequenceRaw = GenerujPlanety();

            var sequence10PlanetSZivotem = sequenceRaw.ExistujeZivot(10);
            var sequenceBlizkoZeme = sequenceRaw.BlizkoZeme(10000,10);
            var sequenceVyhledatString = sequenceRaw.VyhledatString("ABC",1);
            var sequenceVyhledatSouradnice = sequenceRaw.VyhledatSouradnice(new Souradnice(123465789, 123465789,123465789),1000000);
            var sequenceUID = sequenceRaw.VyhledatUID(50);
            

            foreach (var item in sequenceUID)
            {
                item.Vypis();
            }
            Console.ReadLine();
        }

        static IEnumerable<Planeta> GenerujPlanety()
        {
            Random rnd = new Random();
            int pocet = 0;
            while (true)
            {
                yield return new Planeta(rnd, pocet++);
            }
        }
    }

    static class MyExtensionUtils
    {
        public static IEnumerable<Planeta> ExistujeZivot(this IEnumerable<Planeta> seq, int count)
        {
            return seq.Where(e => e.ExistujeZivot).Take(count);
        }

        public static IEnumerable<Planeta> BlizkoZeme(this IEnumerable<Planeta> seq, int vzdalenost, int count)
        {
            return seq.Where(e => e.VzdalenostOdZeme <= vzdalenost).Take(count);
        }

        public static IEnumerable<Planeta> VyhledatString(this IEnumerable<Planeta> seq, string input, int count)
        {
            return seq.Where(e => e.Nazev.Split('-')[0] == input ).Take(count);
        }

        public static IEnumerable<Planeta> VyhledatInt(this IEnumerable<Planeta> seq, int input, int count)
        {
            return seq.Where(e => Convert.ToInt32(e.Nazev.Split('-')[1]) == input).Take(count);
        }

        public static IEnumerable<Planeta> VyhledatSouradnice(this IEnumerable<Planeta> seq, Souradnice cordinates, int tolerance)
        {
            return seq.Where(e =>
            e.Pozice.X > cordinates.X - tolerance &&
            e.Pozice.X < cordinates.X + tolerance &&
            e.Pozice.Y > cordinates.Y - tolerance &&
            e.Pozice.Y < cordinates.Y + tolerance &&
            e.Pozice.Z > cordinates.Z - tolerance &&
            e.Pozice.Z < cordinates.Z + tolerance
            ).Take(1);
        }

        public static IEnumerable<Planeta> VyhledatUID(this IEnumerable<Planeta> seq, int id)
        {
            return seq.Where(e =>e.UID == id).Take(1);
        }
    }
}
