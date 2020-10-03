using PlanetGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlanetGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequenceRaw = GenerujPlanety();

            var sequenceExistujeZivot = sequenceRaw.ExistujeZivot(10);
            var sequenceBlizkoZeme = sequenceRaw.BlizkoZeme(10000,10);
            var sequenceVyhledatString = sequenceRaw.VyhledatStringVeJmene("ABC",1);
            var sequenceVyhledatInt = sequenceRaw.VyhledatIntVeJmene(11,1);
            var sequenceVyhledatSouradnice = sequenceRaw.VyhledatSouradnice(new Souradnice(123465789, 123465789,123465789),1000000);
            var sequenceUID = sequenceRaw.VyhledatUID(50);
            var sequenceNejbliasiPlanetaSZivotem = sequenceRaw.NejblizsiPlanetaSZivotem(1000);
            var sequenceNejblizsiZemi = sequenceRaw.NejblizsiZemi(10,100000);
            var sequenceVyhledatSoucastUID = sequenceRaw.VyhledatSoucastUID(123, 10000);
            var sequenceVyhledatLicheUID = sequenceRaw.VyhledatLicheUID(10);

            foreach (var item in sequenceExistujeZivot)
            {
                item.Vypis();
            }
            Console.ReadKey();
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

        public static IEnumerable<Planeta> VyhledatStringVeJmene(this IEnumerable<Planeta> seq, string input, int count)
        {
            return seq.Where(e => e.Nazev.Split('-')[0] == input ).Take(count);
        }

        public static IEnumerable<Planeta> VyhledatIntVeJmene(this IEnumerable<Planeta> seq, int input, int count)
        {
            return seq.Where(e => Convert.ToInt32(e.Nazev.Split('-')[1]) == input).Take(count);
        }

        public static Planeta VyhledatSouradnice(this IEnumerable<Planeta> seq, Souradnice cordinates, int tolerance)
        {
            return seq.Where(e =>
            e.Pozice.X > cordinates.X - tolerance &&
            e.Pozice.X < cordinates.X + tolerance &&
            e.Pozice.Y > cordinates.Y - tolerance &&
            e.Pozice.Y < cordinates.Y + tolerance &&
            e.Pozice.Z > cordinates.Z - tolerance &&
            e.Pozice.Z < cordinates.Z + tolerance
            ).First();
        }

        public static Planeta VyhledatUID(this IEnumerable<Planeta> seq, int id)
        {
            return seq.Where(e => e.UID == id).First();
        }

        public static Planeta NejblizsiPlanetaSZivotem(this IEnumerable<Planeta> seq, int count)
        {
            /*IEnumerable<Planeta> sequence = seq.Where(e => e.ExistujeZivot).Take(count);
            Planeta result = sequence.First();
            foreach (var item in sequence)
            {
                if (result.VzdalenostOdZeme > item.VzdalenostOdZeme) result = item;
            }
            return result;*/
            return seq.Take(count).Where(e => e.ExistujeZivot).OrderBy(x => x.VzdalenostOdZeme).First();
        }

        public static IEnumerable<Planeta> NejblizsiZemi(this IEnumerable<Planeta> seq, int count, int toscan)
        {
            return seq.Take(toscan).OrderBy(x => x.VzdalenostOdZeme).Take(count);
        }

        public static IEnumerable<Planeta> VyhledatSoucastUID(this IEnumerable<Planeta> seq, int soucast, int toscan)
        {
            return seq.Take(toscan).Where(x => x.UID.ToString().Contains(soucast.ToString()));
        }

        public static IEnumerable<Planeta> VyhledatLicheUID(this IEnumerable<Planeta> seq, int count)
        {
            return seq.Where(x => x.UID % 2 == 1).Take(count);
        }
    }
}
