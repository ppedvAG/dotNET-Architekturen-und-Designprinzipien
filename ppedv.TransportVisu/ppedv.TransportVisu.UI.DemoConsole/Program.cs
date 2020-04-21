using ppedv.TransportVisu.Logic;
using ppedv.TransportVisu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TransportVisu.UI.DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** TransportViso v0.1 Demo Console ***");

            var core = new Core();

            foreach (var a in core.Repository.GetAll<Artikel>())
            {
                Console.WriteLine($"{a.Bezeichnung}");
                foreach (var w in a.Waesche)
                {
                    Console.WriteLine($"\t{w.Artikelnummer} {w.Bezeichnung}");
                }
            }

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
