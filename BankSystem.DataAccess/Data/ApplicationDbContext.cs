
using BankSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankSystemApp.DataAcces.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<CurrentAccount> CurrentAccount { get; set; }

        public DbSet<Deposit> Deposit { get; set; }

        public DbSet<Withdrawal> Withdrawal { get; set; }
        public DbSet<ApplicationUser>  ApplicationUsers { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }



    }
}
