using System.Collections.Generic;

namespace ppedv.TransportVisu.Model
{
    public abstract class Datenplatz : Entity
    {
        public string Bezeichnung { get; set; }
        public virtual HashSet<Sensor> Sensoren { get; set; } = new HashSet<Sensor>();
        public virtual HashSet<Waesche> Waesche { get; set; } = new HashSet<Waesche>();

    }

}
