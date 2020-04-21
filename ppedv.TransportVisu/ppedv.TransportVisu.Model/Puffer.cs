namespace ppedv.TransportVisu.Model
{
    public class Puffer : Datenplatz
    {
        public bool Gesperrt { get; set; }
        public virtual Speicherbahn Speicherbahn { get; set; }
    }

}
