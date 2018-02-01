using Astra.Core.Interfaces;
using System;
using System.Data.Entity;

namespace Astra.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private DbContextTransaction _transaction;

        public Database Session { get; private set; }

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Session = _context.Database;
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (_transaction != null)
                    _transaction.Commit();
            }
            catch
            {
                // rollback if there was an exception
                if (_transaction != null)
                    _transaction.Rollback();

                throw;
            }
            
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null)
                    _transaction.Rollback();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
