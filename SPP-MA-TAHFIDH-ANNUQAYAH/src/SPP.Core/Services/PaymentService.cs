using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPP.Core.Models;
using SPP.Data.Repositories;

namespace SPP.Core.Services
{
    public class PaymentService
    {
        private readonly ITransactionRepository _transactionRepository;

        public PaymentService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<bool> ProcessPayment(Transaction transaction)
        {
            if (transaction == null || transaction.Amount <= 0)
            {
                throw new ArgumentException("Invalid transaction details.");
            }

            // Logic to process the payment
            // This could involve calling an external payment gateway API

            // Assuming payment is processed successfully
            await _transactionRepository.AddTransactionAsync(transaction);
            return true;
        }

        public async Task<List<Transaction>> GetTransactionsByStudentId(int studentId)
        {
            return await _transactionRepository.GetTransactionsByStudentIdAsync(studentId);
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await _transactionRepository.GetAllTransactionsAsync();
        }
    }
}