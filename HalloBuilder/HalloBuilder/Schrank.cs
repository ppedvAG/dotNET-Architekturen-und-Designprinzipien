using System;

namespace HalloBuilder
{
    public class Schrank
    {
        private Schrank()
        { }

        public int AnzahlTüren { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        public string Farbe { get; private set; }
        public int AnzahlBöden { get; private set; }

        public class Builder
        {

            private Schrank schrank = new Schrank();

            public Builder SetAnzahlTüren(int anz)
            {
                if (anz < 2)
                    throw new ArgumentException("Es müssen mindestens 2 Türen sein!!!");
                if (anz > 7)
                    throw new ArgumentException("Es dürfen max 7 Türen sein!!!");

                schrank.AnzahlTüren = anz;
                return this;
            }

            public Builder SetAnzahlBöden(int anz)
            {
                schrank.AnzahlBöden = anz;
                return this;
            }

            public Builder SetOber(Oberfläche ob)
            {
                schrank.Oberfläche = ob;
                return this;
            }

            public Builder SetFarbe(string farbe)
            {
                if (schrank.Oberfläche == Oberfläche.Natur || schrank.Oberfläche == Oberfläche.Wachs)
                    throw new ArgumentException("Farbe nur bei lack!!");

                schrank.Farbe = farbe;
                return this;
            }


            public Schrank Create()
            {
                return schrank;
            }
        }
    }

    public enum Oberfläche
    {
        Natur,
        Wachs,
        Lack
    }
}
