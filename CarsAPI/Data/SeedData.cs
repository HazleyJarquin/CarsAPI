using CarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, IHostEnvironment env)
        {
            // Crear un scope para la resolución del DbContext
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServiceProvider = scope.ServiceProvider;

                // Ahora puedes resolver el DbContextOptions desde el scope
                var dbContextOptions = scopedServiceProvider.GetRequiredService<DbContextOptions<AppDbContext>>();

                // Crear una instancia del contexto con las opciones resueltas
                using (var context = new AppDbContext(dbContextOptions))
                {
                    // Asegurarse de que la base de datos está creada (opcional)
                    context.Database.EnsureCreated();

                    // Agregar los vehículos si no existen
                    if (!context.Cars.Any())
                    {
                        context.Cars.AddRange(
                            new Car { Id = "1", Name = "Model S", Brand = "Tesla", price = 79999.99m },
                            new Car { Id = "2", Name = "Civic", Brand = "Honda", price = 22000.50m },
                            new Car { Id = "3", Name = "Mustang", Brand = "Ford", price = 45000.75m }
                        );
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
