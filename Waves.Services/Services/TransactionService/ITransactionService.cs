using System;

namespace Waves.Services.Services.TransactionService
{
    public interface ITransactionService : IDisposable
    {
        void Commit();
        void BeginTransaction();
        void RollBack();
    }
}
