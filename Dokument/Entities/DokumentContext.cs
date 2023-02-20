using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dokument.Entities
{
    public class DokumentContext : DbContext
    {
        public DokumentContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Dokument> Dokument { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dokument>()
                .HasData(new
                {
                    DokumentId = Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                    DatumIzdavanja=DateTime.Parse("2022-12-11T10:00:00")
                }
                ) ;
        }
    }
}
