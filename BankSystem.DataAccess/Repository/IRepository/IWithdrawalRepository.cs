using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DataAccess.Repository.IRepository
{
    public interface IWithdrawalRepository : IRepository<Withdrawal>
    {
         void WithdrawalAmount(int accountId, double amount);
        

    }
}
