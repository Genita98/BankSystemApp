
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

        public DbSet<CurrentAccount> CurrentAccount { get; set; }

        public DbSet<Deposit> Deposit { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    IdCardClient = 11111111,
                    Name = "Bank",
                    Surname = "Account",
                    Email = "bankaccount@gmail.com",
                    Address = "Prishtine",
                    PhoneNumber = "+38344111222"
                }
                );
            

        }



    }
}
