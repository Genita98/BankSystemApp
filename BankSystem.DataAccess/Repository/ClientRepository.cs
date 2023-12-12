using BankSystem.DataAccess.Repository.IRepository;
using BankSystem.Models;
using BankSystemApp.DataAcces.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DataAccess.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository 
    {
        private ApplicationDbContext _db;

        public  ClientRepository(ApplicationDbContext db) : base(db)  
        {
            _db = db;   
        }

        public  void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Client obj)
        {
            _db.Clients.Update(obj);
        }

        
    }
}
