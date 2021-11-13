using MS.AFORO255.Withdrawal.Models;
using MS.AFORO255.Withdrawal.Repositories;

namespace MS.AFORO255.Withdrawal.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ContextDatabase _contextDatabase;

        public TransactionService(ContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public Transaction Withdrawal(Transaction transaction)
        {
            _contextDatabase.Transaction.Add(transaction);
            _contextDatabase.SaveChanges();
            return transaction;
        }

        public Transaction WithdrawalReverse(Transaction transaction)
        {
            _contextDatabase.Transaction.Add(transaction);
            _contextDatabase.SaveChanges();
            return transaction;
        }
    }
}
