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
            var sequence10First = sequenceRaw.Take(20);
            foreach (var item in sequence10First)
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
        public static IEnumerable<Planeta> ExistujeZivot(this IEnumerable<Planeta> seq)
        {
            return seq.Where(e => e.ExistujeZivot);
        }
    }
}
