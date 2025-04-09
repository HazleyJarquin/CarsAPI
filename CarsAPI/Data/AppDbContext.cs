using CarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

    }
}
