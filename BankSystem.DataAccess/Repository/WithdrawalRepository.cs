using BankSystem.DataAccess.Repository.IRepository;
using BankSystem.Models;
using BankSystemApp.DataAcces.Data;
using Microsoft.CSharp.RuntimeBinder;
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
            var existingAccount = _db.CurrentAccount.Find(AccountId);

            var datetimeNow = DateTime.Now;
            if (existingAccount != null)
            {
                var actualBalance = existingAccount.AccountBalance;
                if (actualBalance >= amount)
                {
                    existingAccount.AccountBalance = actualBalance - amount;

                    var withdrawal = new Withdrawal
                    {
                        AccountId = existingAccount.AccountId,
                        Amount = amount,
                        TransactionDate = datetimeNow
                    };

                    _db.Withdrawal.Add(withdrawal);
                    _db.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Insufficient balance for withdrawal.");

                }
            }
        }
    }
}
