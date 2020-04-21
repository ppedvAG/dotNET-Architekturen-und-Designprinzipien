namespace ppedv.TransportVisu.Model
{
    public class Sensor : Entity
    {
        public string Bezeichnung { get; set; }
        public int Schwellwert { get; set; }
        public int Zustand { get; set; }
        public virtual Datenplatz Datenplatz { get; set; }
    }

}
