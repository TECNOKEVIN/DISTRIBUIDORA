﻿using Distribuidora.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Distribuidora.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>options): base(options)
        {
              
        }

        public DbSet<Sede> Sedes { get; set; }
        public DbSet<TipoLicor> TipoLicors{ get; set; }
        public DbSet<Licor> Licors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sede>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<TipoLicor>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<Licor>().HasIndex(s => s.Name).IsUnique();
        }

    }
}
