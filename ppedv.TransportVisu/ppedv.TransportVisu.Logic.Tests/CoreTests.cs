using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.TransportVisu.Model;

namespace ppedv.TransportVisu.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetAktiveSensors_null_throws_ArgumentNullException()
        {
            var core = new Core(null);

            Assert.ThrowsException<ArgumentNullException>(() => core.GetAktiveSensors(null));
        }

        [TestMethod]
        public void Core_GetAktiveSensors_empty_sensor_list_returns_empty_list()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();

            var result = core.GetAktiveSensors(sensors);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Core_GetAktiveSensors_single_Sensor_is_over()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 12 });

            var result = core.GetAktiveSensors(sensors);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Core_GetAktiveSensors_single_Sensor_is_exact_on()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 10 });

            var result = core.GetAktiveSensors(sensors);

            Assert.AreEqual(1, result.Count());
        }


        [TestMethod]
        public void Core_GetAktiveSensors_only_one_Sensor_is_over()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 12 });
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 4 });

            var result = core.GetAktiveSensors(sensors);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Core_GetAktiveSensors_no_Sensor_is_over()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 8 });
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 4 });

            var result = core.GetAktiveSensors(sensors);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Core_GetAktiveSensors_all_Sensor_is_over()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 16 });
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 14 });

            var result = core.GetAktiveSensors(sensors);

            Assert.AreEqual(2, result.Count());
        }
    }
}
