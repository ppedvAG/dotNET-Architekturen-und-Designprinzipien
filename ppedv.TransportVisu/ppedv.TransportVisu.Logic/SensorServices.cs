using ppedv.TransportVisu.Model;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.TransportVisu.Logic
{
    public class SensorServices
    {
        Core core;
  
        public SensorServices(Core core)
        {
            this.core = core;
        }

        public IEnumerable<Sensor> GetAktiveSensors(IEnumerable<Sensor> sensors)
        {
            return sensors.Where(x => x.Zustand >= x.Schwellwert);
        }

        public Sensor GetSensorWithMostOffSet()
        {
            return core.Repository.GetAll<Sensor>().OrderByDescending(x => x.Zustand - x.Schwellwert)
                                                   .ThenByDescending(x => x.Zustand)
                                                   .FirstOrDefault();
        }


        public void CreateDemoSensorDaten()
        {
            var s1 = new Sensor() { Bezeichnung = "Belegsensor #1", Schwellwert = 100, Zustand = 100 };
            var s2 = new Sensor() { Bezeichnung = "Belegsensor #2", Schwellwert = 50, Zustand = 100 };
            var s3 = new Sensor() { Bezeichnung = "Belegsensor #3", Schwellwert = 50, Zustand = 10 };
            var s4 = new Sensor() { Bezeichnung = "Belegsensor #4", Schwellwert = 50, Zustand = 50 };

            core.Repository.Add(s1);
            core.Repository.Add(s2);
            core.Repository.Add(s3);
            core.Repository.Add(s4);
            
            core.Repository.SaveAll();
        }

    }
}
