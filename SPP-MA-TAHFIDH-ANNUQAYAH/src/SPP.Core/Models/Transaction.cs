using System;

namespace SPP.Core.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

        public Transaction(int studentId, decimal amount, string paymentMethod)
        {
            StudentId = studentId;
            Amount = amount;
            PaymentMethod = paymentMethod;
            TransactionDate = DateTime.Now;
            Status = "Pending"; // Default status
        }

        public void CompleteTransaction()
        {
            Status = "Completed";
        }

        public void CancelTransaction()
        {
            Status = "Cancelled";
        }
    }
}