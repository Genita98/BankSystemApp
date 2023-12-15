using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IClientRepository Client { get;  }
        ICurrentAccountRepository CurrentAccount { get; }

        void Save();

    }
}
