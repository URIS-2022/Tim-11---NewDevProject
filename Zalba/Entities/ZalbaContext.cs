using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zalba.Entities
{

        public class ZalbaContext : DbContext
        {
            public ZalbaContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<Zalba> Zalba { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Zalba>()
                    .HasData(new
                    {
                        ZalbaId = Guid.Parse("9d8bab08-f442-4297-8ab5-ddfe08e335f3"),
                        DatumPodnosenja = DateTime.Parse("2021-11-11T11:00:00"),
                        DatumResenja = DateTime.Parse("2021-12-12T12:00:00"),
                        Obrazlozenje = "Nevalidnost podataka",
                        Status = "Usvojena"
                    }
                    );

            modelBuilder.Entity<Zalba>()
    .HasData(new
    {
        TipZalbeId = Guid.Parse("9d8bab08-f442-4297-8ab5-ddfe08e336f3"),
        Opis="Zalba na tok javnog nadmetanja"
    }
    ) ;
        }

        }
    }

