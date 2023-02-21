using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using UplataService.Entities;
using UplataService.Entities.cs;
using System.Reflection.Emit;

namespace UplataService.Entities
{
    public class UplataContext : DbContext
    {

        public DbSet<Uplata> Uplata { get; set; }
        public DbSet<Banka> Banka { get; set; }

        public UplataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uplata>()
                .HasData(
                new Uplata
                {
                    uplataId = Guid.Parse("f7a20259-5aeb-3135-64ea-32cf7a96b98a"),
                    bankaId = Guid.Parse("ce4a6a8a-b25d-d5d0-9364-3dee56521821"),
                    datumUplate = "1/2/2023",
                    svrhaUplate = "uplata depozita za prijavu",
                    iznos = 150000,
                    brojRacuna = "1234"
                },
                new Uplata
                {
                    uplataId = Guid.Parse("e8920f41-e035-da6d-27d1-ee8909f6271d"),
                    bankaId = Guid.Parse("22caf793-fbaa-a3f5-8266-7fc3dcc798dc"),
                    datumUplate = "2/2/2023",
                    svrhaUplate = "uplata depozita za prijavu",
                    iznos = 100000,
                    brojRacuna = "12345"
                }
                );
            modelBuilder.Entity<Banka>()
                .HasData(
                new Banka
                {
                    bankaId = Guid.Parse("9d8004cb-fad6-40a9-9d9e-978ff4f98481"),
                    naziv = "Erste Bank"
                }
                );
        }
    }
}