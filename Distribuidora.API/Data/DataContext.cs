using Distribuidora.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Distribuidora.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>options): base(options)
        {
              
        }

        public DbSet<Sede> Sedes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sede>().HasIndex(s => s.Name).IsUnique();
        }

    }
}
