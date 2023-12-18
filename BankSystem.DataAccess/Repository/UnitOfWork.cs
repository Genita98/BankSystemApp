using BankSystem.DataAccess.Repository.IRepository;
using BankSystemApp.DataAcces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DataAccess.Repository
{
    public  class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;
        public IClientRepository Client { get; private set; }

        public ICurrentAccountRepository CurrentAccount { get; private set; }
        public IDepositRepository Deposit { get; private set; }

        public IWithdrawalRepository Withdrawal { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Client = new ClientRepository(_db);
            CurrentAccount = new CurrentAccountRepository(_db);
            Deposit = new DepositRepository(_db);
            Withdrawal = new WithdrawalRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public void UpdateEntity<TEntity>(TEntity entity) where TEntity : class
        {
            var entry = _db.Entry(entity);
            entry.State = EntityState.Modified;
        }

    }
}
