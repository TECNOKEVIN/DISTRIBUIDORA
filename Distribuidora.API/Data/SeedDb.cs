﻿using Distribuidora.API.Data;
using Distribuidora.Shared.Entities;
using Distribuidora.API.Services;
using Microsoft.EntityFrameworkCore;
using Distribuidora.Shared.Responses;
using Distribuidora.API.Helpers;
using Distribuidora.Shared.Enums;

namespace Distribuidora.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IApiService apiService, IUserHelper userHelper)
        {
            _context = context;
            _apiService = apiService;
            _userHelper = userHelper;
        }



        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckSedesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "KL", "KL", "kl@yopmail.com", "300445555", "CR 78 9687", UserType.Admin);

        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                //var city = await _context.Cities.FirstOrDefaultAsync(x => x.Name == "Medellín");
                //if (city == null)
                //{
                //    city = await _context.Cities.FirstOrDefaultAsync();
                //}

                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                   // City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };
                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
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
                        new Licor() { Name = "Smirnoff", Price = 86000 , Stock = 8},
                        new Licor() { Name = "Absolut", Price = 73500 , Stock = 6 },
                        new Licor() { Name = "Level", Price = 60000 , Stock = 1 },
                        new Licor() {Name = "Skyy", Price = 72000, Stock = 2},
                        new Licor() {Name = "Military", Price = 80000, Stock = 1},
                        new Licor() {Name = "Grey Goose", Price = 70000, Stock = 2},
                    }
                },
                new TipoLicor()
                {
                    Name = "Ron",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Caldas", Price = 48000 , Stock = 9 },
                        new Licor() {Name = "Medellin", Price = 44000, Stock = 4},
                        new Licor() {Name = "Bacardi", Price = 45000, Stock = 5},
                        new Licor() {Name = "Havana club", Price = 47000, Stock = 3},
                        new Licor() {Name = "Captain morgan", Price = 42000, Stock = 3},
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
                        new Licor() {Name = "Antioqueño", Price = 48000, Stock = 6},
                        new Licor() {Name = "Nectar", Price = 33000, Stock = 6},
                        new Licor() {Name = "Llanero", Price = 30000, Stock = 2},
                        new Licor() {Name = "Cristal", Price = 32000, Stock = 1},
                        new Licor() {Name = "Tapa roja", Price = 42000, Stock = 2},
                    }
                },
                new TipoLicor()
                {
                    Name = "Mezcal",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Real minero", Price = 182000 , Stock = 2 },
                        new Licor() { Name = "Union", Price = 190000 , Stock = 3 },
                        new Licor() {Name = "Fidencio", Price = 186000, Stock = 1},

                    }
                },
                new TipoLicor()
                {
                    Name = "Tequila",
                    Licors = new List<Licor>() {
                        new Licor() {Name = "Jose cuervo", Price = 85000, Stock = 7},
                        new Licor() {Name = "Don julio", Price = 80000, Stock = 5},
                        new Licor() {Name = "Patron", Price = 65000, Stock = 3},
                        new Licor() {Name = "Olmeca", Price = 70000, Stock = 3},
                        new Licor() {Name = "1800", Price = 80000, Stock = 4},
                        new Licor() {Name = "Alacran", Price = 75000, Stock = 2},
                        new Licor() {Name = "Gran malo", Price = 182000, Stock = 2},
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
                        new Licor() { Name = "Jose cuervo", Price = 85000, Stock = 5 },
                        new Licor() { Name = "Don julio", Price = 80000, Stock = 3 },
                        new Licor() { Name = "Patron", Price = 65000, Stock = 3 },
                        new Licor() { Name = "Olmeca", Price = 70000, Stock = 1 },
                        new Licor() { Name = "1800", Price = 80000, Stock = 3 },
                        new Licor() { Name = "Alacran", Price = 75000, Stock = 1 },
                    }
                },
                new TipoLicor()
                {
                    Name = "Vino",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Altos del eden", Price = 50000, Stock = 2 },
                        new Licor() { Name = "La loba", Price = 48000, Stock = 1 },
                        new Licor() { Name = "8000", Price = 52000, Stock = 5 },
                        new Licor() { Name = "Gato negro", Price = 58000, Stock = 7 },
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
                        new Licor() { Name = "Jose cuervo", Price = 85000, Stock = 12 },
                        new Licor() { Name = "Don julio", Price = 80000, Stock = 9 },
                        new Licor() { Name = "Patron", Price = 65000, Stock = 4 },
                    }
                },
                new TipoLicor()
                {
                    Name = "Vino",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Altos del eden", Price = 50000, Stock = 6 },
                        new Licor() { Name = "8000", Price = 52000, Stock = 10 },
                        new Licor() { Name = "Gato negro", Price = 58000, Stock = 20 },
                    }
                },
                 new TipoLicor()
                {
                    Name = "Mezcal",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Real minero", Price = 182000 , Stock = 5 },
                        new Licor() { Name = "Union", Price = 190000 , Stock = 9 },
                        new Licor() {Name = "Fidencio", Price = 186000, Stock = 3},

                    }
                },
                new TipoLicor()
                {
                    Name = "Aguardiente",
                    Licors = new List<Licor>() {
                        new Licor() {Name = "Antioqueño", Price = 48000, Stock = 18},
                        new Licor() {Name = "Nectar", Price = 33000, Stock = 6},
                        new Licor() {Name = "Tapa roja", Price = 42000, Stock = 5},
                    }
                },
                new TipoLicor()
                {
                    Name = "Vodka",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Smirnoff", Price = 86000 , Stock = 14},
                        new Licor() { Name = "Absolut", Price = 73500 , Stock = 12 },
                        new Licor() { Name = "Level", Price = 60000 , Stock = 6 },
                        new Licor() {Name = "Skyy", Price = 72000, Stock = 4},
                        new Licor() {Name = "Military", Price = 80000, Stock = 2},
                        new Licor() {Name = "Grey Goose", Price = 70000, Stock = 4},
                    }
                },
                new TipoLicor()
                {
                    Name = "Ron",
                    Licors = new List<Licor>() {
                        new Licor() { Name = "Caldas", Price = 48000 , Stock = 13 },
                        new Licor() {Name = "Medellin", Price = 44000, Stock = 8},
                        new Licor() {Name = "Bacardi", Price = 45000, Stock = 5},
                        new Licor() {Name = "Havana club", Price = 47000, Stock = 4},
                        new Licor() {Name = "Captain morgan", Price = 42000, Stock = 2},
                    }
                },
            }
                });
            }

            await _context.SaveChangesAsync();
        }

    }
}

