using ppedv.TransportVisu.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ppedv.TransportVisu.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Beladeposition> Beladepositionen { get; set; }
        public DbSet<Datenplatz> Datenplaetze { get; set; }
        public DbSet<Puffer> Puffer { get; set; }
        public DbSet<Sensor> Sensoren { get; set; }
        public DbSet<Speicherbahn> Speicherbahnen { get; set; }
        public DbSet<Waesche> Waesche { get; set; }
        public DbSet<Waschmaschine> Waschmaschinen { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Waschmaschine>().ToTable("Waschmaschine");
            modelBuilder.Entity<Puffer>().ToTable("Puffer");
            modelBuilder.Entity<Beladeposition>().ToTable("Beladepositionen");

            modelBuilder.Entity<Waschmaschine>().Property(x => x.Bezeichnung)
                                                .HasColumnName("Bezi")
                                                .HasMaxLength(79)
                                                .IsRequired();

            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }


        public EfContext() : this("Server=(localdb)\\mssqllocaldb;Database=TransportVisu_dev;Trusted_Connection=true")
        { }

        public EfContext(string conString) : base(conString)
        { }
    }
}
