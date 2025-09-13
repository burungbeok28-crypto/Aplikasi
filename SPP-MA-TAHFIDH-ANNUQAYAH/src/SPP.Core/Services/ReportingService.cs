using System;
using System.Collections.Generic;
using System.Linq;

namespace SPP.Core.Services
{
    public class ReportingService
    {
        private readonly ITransactionRepository _transactionRepository;

        public ReportingService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<TransactionReport> GenerateTransactionReport(DateTime startDate, DateTime endDate)
        {
            var transactions = _transactionRepository.GetTransactionsByDateRange(startDate, endDate);
            var report = transactions.GroupBy(t => t.StudentId)
                                     .Select(g => new TransactionReport
                                     {
                                         StudentId = g.Key,
                                         TotalAmount = g.Sum(t => t.Amount),
                                         TransactionCount = g.Count()
                                     });

            return report.ToList();
        }
    }

    public class TransactionReport
    {
        public int StudentId { get; set; }
        public decimal TotalAmount { get; set; }
        public int TransactionCount { get; set; }
    }
}