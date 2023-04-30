using Distribuidora.API.Data;
using Distribuidora.Shared.Entities;

namespace Distribuidora.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckSedesAsync();
        }

        private async Task CheckSedesAsync()
        {
            if (!_context.Sedes.Any())
            {
                _context.Sedes.Add(new Sede { Name = "Medellin" });
                _context.Sedes.Add(new Sede { Name = "Bello" });
                _context.Sedes.Add(new Sede { Name = "Envigado" });

            }

            await _context.SaveChangesAsync();
        }
    }
}

