using BankSystem.DataAccess.Repository.IRepository;
using BankSystem.Models;
using BankSystemApp.DataAcces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DataAccess.Repository
{
    public class WithdrawalRepository : Repository <Withdrawal>, IWithdrawalRepository
    {

        private ApplicationDbContext _db;

        public WithdrawalRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void WithdrawalAmount(int AccountId,double amount)
        {
            throw new Exception();
        }
    }
}
