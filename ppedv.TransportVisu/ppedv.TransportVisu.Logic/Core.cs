using ppedv.TransportVisu.Model;
using ppedv.TransportVisu.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.TransportVisu.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }


        public IEnumerable<Sensor> GetAktiveSensors(IEnumerable<Sensor> sensors)
        {
            return sensors.Where(x => x.Zustand >= x.Schwellwert);
        }


        public void CreateDemoSensorDatenDaten()
        {
            var s1 = new Sensor() { Bezeichnung = "Belegsensor #1", Schwellwert = 100, Zustand = 100 };
            var s2 = new Sensor() { Bezeichnung = "Belegsensor #2", Schwellwert = 50, Zustand = 100 };
            var s3 = new Sensor() { Bezeichnung = "Belegsensor #3", Schwellwert = 50, Zustand = 10 };
            var s4 = new Sensor() { Bezeichnung = "Belegsensor #4", Schwellwert = 50, Zustand = 50 };

            Repository.Add(s1);
            Repository.Add(s2);
            Repository.Add(s3);
            Repository.Add(s4);

            Repository.SaveAll();
        }

        //dependency Injection goes into here
        public Core(IRepository repo)
        {
            this.Repository = repo;
        }

        //feste verdrahtung für den faulen dev
        public Core() : this(new Data.EF.EfRepository())
        { }
    }
}
