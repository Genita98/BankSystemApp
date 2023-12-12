using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DataAccess.Repository.IRepository
{
     public interface IClientRepository : IRepository <Client>
    {
        void Update(Client obj);
        void Save();

    }
}
