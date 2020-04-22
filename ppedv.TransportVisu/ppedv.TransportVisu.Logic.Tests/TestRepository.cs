using System;
using System.Collections.Generic;
using ppedv.TransportVisu.Model;
using ppedv.TransportVisu.Model.Contracts;

namespace ppedv.TransportVisu.Logic.Tests
{
    class TestRepository : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            if (typeof(T) == typeof(Sensor))
            {
                yield return new Sensor() { Bezeichnung = "S1", Schwellwert = 100, Zustand = 100 } as T;
                yield return new Sensor() { Bezeichnung = "S2", Schwellwert = 50, Zustand = 100 } as T;
            }
            else
                throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
