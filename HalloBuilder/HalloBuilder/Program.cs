using System;

namespace HalloBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Schrank meinSchrank = new Schrank.Builder()
                                     .SetAnzahlBöden(12)
                                     .SetAnzahlTüren(4)
                                     .SetOber(Oberfläche.Lack)
                                     .SetFarbe("Grün")
                                     .Create();

            Schrank.Builder builder = new Schrank.Builder();
            builder.SetAnzahlBöden(12);
            builder.SetAnzahlTüren(4);
            Schrank meinSchrank2 = builder.Create();

            Console.WriteLine("Ende");
        }
    }
}
