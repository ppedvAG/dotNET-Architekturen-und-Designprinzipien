using System.Collections.Generic;

namespace ppedv.TransportVisu.Model
{
    public class Artikel : Entity
    {
        public string Bezeichnung { get; set; }
        public virtual HashSet<Waesche> Waesche { get; set; } = new HashSet<Waesche>();

    }

}
