using Microsoft.EntityFrameworkCore;
using Project06_ApiWeather.Entities;

namespace Project06_ApiWeather.Context
{
    public class WeatherContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server='(localdb)\\MSSQLLocalDB';initial catalog='Db6Project20'; integrated security= true");
        }

        public DbSet<City> Citys { get; set; }
    }
}
