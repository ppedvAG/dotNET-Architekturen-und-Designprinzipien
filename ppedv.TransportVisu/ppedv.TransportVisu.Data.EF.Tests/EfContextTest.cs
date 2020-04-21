using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.TransportVisu.Data.EF.Tests
{
    [TestClass]
    public class EfContextTest
    {
        [TestMethod]
        public void EfContext_can_create_DB()
        {
            using (var con = new EfContext())
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                con.Database.Create();

                Assert.IsTrue(con.Database.Exists());
            }
        }
    }
}
