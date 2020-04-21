using System;
using System.Collections.Generic;

namespace ppedv.TransportVisu.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public abstract class Datenplatz : Entity
    {
        public string Bezeichnung { get; set; }
        public virtual HashSet<Sensor> Sensoren { get; set; } = new HashSet<Sensor>();
        public virtual HashSet<Waesche> Waesche { get; set; } = new HashSet<Waesche>();

    }

    public class Waschmaschine : Datenplatz
    {
        public string Hersteller { get; set; }
        public string Waschmittel { get; set; }
    }


    public class Beladeposition : Datenplatz
    {
        public bool IstVollständigBeladen { get; set; }
    }
    public class Puffer : Datenplatz
    {
        public bool Gesperrt { get; set; }
        public virtual Speicherbahn Speicherbahn { get; set; }
    }

    public class Speicherbahn : Entity
    {
        public string Bezeichnung { get; set; }
        public virtual HashSet<Puffer> Puffer { get; set; } = new HashSet<Puffer>();
    }

    public class Sensor : Entity
    {
        public string Bezeichnung { get; set; }
        public int Schwellwert { get; set; }
        public int Zustand { get; set; }
        public virtual Datenplatz Datenplatz { get; set; }
    }

    public class Artikel : Entity
    {
        public string Bezeichnung { get; set; }
        public virtual HashSet<Waesche> Waesche { get; set; } = new HashSet<Waesche>();

    }
    public class Waesche : Entity
    {
        public string Bezeichnung { get; set; }
        public string Artikelnummer { get; set; }
        public string Kundennummer { get; set; }
        public string BatchId { get; set; }
        public virtual Datenplatz Datenplatz { get; set; }
        public virtual HashSet<Artikel> Artikel { get; set; } = new HashSet<Artikel>();
    }

}
