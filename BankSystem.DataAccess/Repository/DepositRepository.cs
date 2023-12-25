using BankSystem.DataAccess.Repository.IRepository;
using BankSystem.Models;
using BankSystemApp.DataAcces.Data;

namespace BankSystem.DataAccess.Repository
{
    public class DepositRepository : Repository<Deposit>, IDepositRepository
    {
        private ApplicationDbContext _db;

        public DepositRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


       
        public void DepositAmount(int accountId, double amount)
        {
            var existingAccount = _db.CurrentAccount.Find(accountId);
          
            var datetimeNow = DateTime.Now;

            if (existingAccount != null) {

                double actualBalance = existingAccount.AccountBalance;

                actualBalance = actualBalance + amount;
                existingAccount.AccountBalance = actualBalance;

                var deposit = new Deposit
                {
                    AccountId = existingAccount.AccountId,
                    Amount = amount,
                    TransactionDate = datetimeNow
                };
                _db.Deposit.Add(deposit);
                _db.SaveChanges();


            }
        }
    }  
}
