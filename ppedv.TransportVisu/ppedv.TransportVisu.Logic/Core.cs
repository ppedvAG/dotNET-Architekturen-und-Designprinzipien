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

        public SensorServices SensorServices { get =>  new SensorServices(this); }


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
