using Microsoft.EntityFrameworkCore.Storage;
using Waves.Domain;

namespace Waves.Services.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private IDbContextTransaction _transaction;
        private readonly WavesDbContext _context;
        public TransactionService(WavesDbContext context)
        {
            _context = context;
        }
        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

        }

        public void RollBack()
        {
            _transaction.Rollback();
        }
    }
}
