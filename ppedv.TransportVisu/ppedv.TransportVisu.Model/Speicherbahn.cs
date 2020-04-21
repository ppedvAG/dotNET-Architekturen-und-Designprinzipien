using System.Collections.Generic;

namespace ppedv.TransportVisu.Model
{
    public class Speicherbahn : Entity
    {
        public string Bezeichnung { get; set; }
        public virtual HashSet<Puffer> Puffer { get; set; } = new HashSet<Puffer>();
    }

}
