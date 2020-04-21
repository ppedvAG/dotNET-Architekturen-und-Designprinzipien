using System.Collections.Generic;

namespace ppedv.TransportVisu.Model
{
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
