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
                _context.Sedes.Add(new Sede
                {
                    Name = "Envigado",
                    TipoLicors = new List<TipoLicor>()
            {
                new TipoLicor()
                {
                    Name = "Vodka",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Smirnoff" },
                        new Licor() { Name = "Absolut" },
                        new Licor() { Name = "Level" },
                        new Licor() { Name = "Skyy" },
                        new Licor() { Name = "Military" },
                        new Licor() { Name = "Grey Goose" },
                    }
                },
                new TipoLicor()
                {
                    Name = "Ron",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Caldas" },
                        new Licor() { Name = "Medellin" },
                        new Licor() { Name = "Bacardi" },
                        new Licor() { Name = "Havana club" },
                        new Licor() { Name = "Captain morgan" },
                    }
                },
            }
                });
                _context.Sedes.Add(new Sede
                {
                    Name = "Itagüí",
                    TipoLicors = new List<TipoLicor>()
            {
                new TipoLicor()
                {
                    Name = "Aguardiente",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Antioqueño" },
                        new Licor() { Name = "Nectar" },
                        new Licor() { Name = "Llanero" },
                        new Licor() { Name = "Cristal" },
                        new Licor() { Name = "Tapa roja" },
                    }
                },
                new TipoLicor()
                {
                    Name = "Mezcal",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Real minero" },
                        new Licor() { Name = "Union" },
                        new Licor() { Name = "Fidencio" },

                    }
                },
                new TipoLicor()
                {
                    Name = "Tequila",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Jose cuervo" },
                        new Licor() { Name = "Don julio" },
                        new Licor() { Name = "Patron" },
                        new Licor() { Name = "Olmeca" },
                        new Licor() { Name = "1800" },
                        new Licor() { Name = "Alacran" },
                    }
                },
            }
                });
                _context.Sedes.Add(new Sede
                {
                    Name = "Bello",
                    TipoLicors = new List<TipoLicor>()
            {
                new TipoLicor()
                {
                    Name = "Tequila",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Jose cuervo" },
                        new Licor() { Name = "Don julio" },
                        new Licor() { Name = "Patron" },
                        new Licor() { Name = "Olmeca" },
                        new Licor() { Name = "1800" },
                        new Licor() { Name = "Alacran" },
                    }
                },
                new TipoLicor()
                {
                    Name = "Vino",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Altos del eden" },
                        new Licor() { Name = "La loba" },
                        new Licor() { Name = "8000" },
                        new Licor() { Name = "Gato negro" },
                    }
                },
            }
                });
                _context.Sedes.Add(new Sede
                {
                    Name = "Medellín",
                    TipoLicors = new List<TipoLicor>()
            {
                new TipoLicor()
                {
                    Name = "Tequila",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Jose cuervo" },
                        new Licor() { Name = "Don julio" },
                        new Licor() { Name = "Patron" },
                    }
                },
                new TipoLicor()
                {
                    Name = "Vino",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Altos del eden" },
                        new Licor() { Name = "La loba" },
                        new Licor() { Name = "Gato negro" },
                    }
                },
                 new TipoLicor()
                {
                    Name = "Mezcal",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Real minero" },
                        new Licor() { Name = "Union" },
                        new Licor() { Name = "Fidencio" },

                    }
                },
                new TipoLicor()
                {
                    Name = "Aguardiente",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Antioqueño" },
                        new Licor() { Name = "Nectar" },
                        new Licor() { Name = "Tapa roja" },
                    }
                },
                new TipoLicor()
                {
                    Name = "Vodka",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Smirnoff" },
                        new Licor() { Name = "Absolut" },
                        new Licor() { Name = "Level" },
                        new Licor() { Name = "Skyy" },
                        new Licor() { Name = "Military" },
                        new Licor() { Name = "Grey Goose" },
                    }
                },
                new TipoLicor()
                {
                    Name = "Ron",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Caldas" },
                        new Licor() { Name = "Medellin" },
                        new Licor() { Name = "Bacardi" },
                        new Licor() { Name = "Havana club" },
                        new Licor() { Name = "Captain morgan" },
                    }
                },
            }
                });
            }

            await _context.SaveChangesAsync();
        }

    }
}

