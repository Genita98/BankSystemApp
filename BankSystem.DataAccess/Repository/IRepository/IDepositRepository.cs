using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DataAccess.Repository.IRepository
{
    public interface IDepositRepository : IRepository<Deposit>
    {
        void DepositAmount(int accountId, double obj);

    }
}
