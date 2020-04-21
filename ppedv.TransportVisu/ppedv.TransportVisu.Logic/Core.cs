using ppedv.TransportVisu.Model.Contracts;

namespace ppedv.TransportVisu.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }




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
