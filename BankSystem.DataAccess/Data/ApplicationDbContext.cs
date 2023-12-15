
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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{ 
        //}


    }
}
