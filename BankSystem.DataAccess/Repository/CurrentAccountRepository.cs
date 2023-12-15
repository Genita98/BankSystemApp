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
    public class CurrentAccountRepository : Repository<CurrentAccount>, ICurrentAccountRepository
    {
        private ApplicationDbContext _db;

        public CurrentAccountRepository (ApplicationDbContext db) : base(db)  
        {
            _db = db;   
        }



        public void Update(CurrentAccount obj)
        {
            _db.CurrentAccount.Update(obj);
        }

        
    }
}
