namespace SPP.Data.Repositories
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        Transaction GetTransactionById(int id);
        IEnumerable<Transaction> GetAllTransactions();
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int id);
    }
}