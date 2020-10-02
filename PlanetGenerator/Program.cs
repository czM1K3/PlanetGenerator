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
            Random rnd = new Random();
            Planeta bum = new Planeta(rnd,0);
        }
    }
}
