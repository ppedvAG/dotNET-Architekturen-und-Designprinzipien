using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.TransportVisu.Model;
using ppedv.TransportVisu.Model.Contracts;

namespace ppedv.TransportVisu.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetAktiveSensors_null_throws_ArgumentNullException()
        {
            var core = new Core(null);

            Assert.ThrowsException<ArgumentNullException>(() => core.SensorServices.GetAktiveSensors(null));
        }

        [TestMethod]
        public void Core_GetAktiveSensors_empty_sensor_list_returns_empty_list()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();

            var result = core.SensorServices.GetAktiveSensors(sensors);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Core_GetAktiveSensors_single_Sensor_is_over()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 12 });

            var result = core.SensorServices.GetAktiveSensors(sensors);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Core_GetAktiveSensors_single_Sensor_is_exact_on()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 10 });

            var result = core.SensorServices.GetAktiveSensors(sensors);

            Assert.AreEqual(1, result.Count());
        }


        [TestMethod]
        public void Core_GetAktiveSensors_only_one_Sensor_is_over()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 12 });
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 4 });

            var result = core.SensorServices.GetAktiveSensors(sensors);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Core_GetAktiveSensors_no_Sensor_is_over()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 8 });
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 4 });

            var result = core.SensorServices.GetAktiveSensors(sensors);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Core_GetAktiveSensors_all_Sensor_is_over()
        {
            var core = new Core(null);
            var sensors = new List<Sensor>();
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 16 });
            sensors.Add(new Sensor() { Schwellwert = 10, Zustand = 14 });

            var result = core.SensorServices.GetAktiveSensors(sensors);

            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Core_GetSensorWithMostOffSet_2_Sensors()
        {
            var core = new Core(new TestRepository());

            var result = core.SensorServices.GetSensorWithMostOffSet();

            Assert.AreEqual("S2", result.Bezeichnung);

        }

        [TestMethod]
        public void Core_GetSensorWithMostOffSet_2_Sensors_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Sensor>())
                .Returns(() =>
                 {
                     var s1 = new Sensor() { Bezeichnung = "S1", Schwellwert = 100, Zustand = 100 };
                     var s2 = new Sensor() { Bezeichnung = "S2", Schwellwert = 50, Zustand = 100 };
                     return new[] { s1, s2 };
                 });

            var core = new Core(mock.Object);

            var result = core.SensorServices.GetSensorWithMostOffSet();

            Assert.AreEqual("S2", result.Bezeichnung);

        }


        [TestMethod]
        public void Core_GetSensorWithMostOffSet_2_Sensors_with_same_offset_more_Zustand_should_win_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Sensor>())
                .Returns(() =>
                {
                    var s1 = new Sensor() { Bezeichnung = "S1", Schwellwert = 50, Zustand = 100 };
                    var s2 = new Sensor() { Bezeichnung = "S2", Schwellwert = 100, Zustand = 150 };
                    return new[] { s1, s2 };
                });

            var core = new Core(mock.Object);

            var result = core.SensorServices.GetSensorWithMostOffSet();

            Assert.AreEqual("S2", result.Bezeichnung);

        }
    }
}
