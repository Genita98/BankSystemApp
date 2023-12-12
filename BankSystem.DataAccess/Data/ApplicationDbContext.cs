
using BankSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystemApp.DataAcces.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client { Id=1,Name="Genita",Surname="Azizi",Address="Gjilan",Email="genitaaa98@gmail.com",PhoneNumber="045513622"},
                new Client { Id =2, Name = "Greta", Surname = "Azizi", Address = "Gjilan", Email = "greta.azizi@gmail.com", PhoneNumber = "045683797" }

                );
        }
    }
}
