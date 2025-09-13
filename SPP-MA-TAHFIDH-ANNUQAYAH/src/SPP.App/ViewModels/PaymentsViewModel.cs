using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using SPP.Core.Models;
using SPP.Core.Services;

namespace SPP.App.ViewModels
{
    public class PaymentsViewModel : INotifyPropertyChanged
    {
        private readonly PaymentService _paymentService;
        private ObservableCollection<Transaction> _transactions;
        private string _selectedStudent;
        private decimal _amount;

        public PaymentsViewModel()
        {
            _paymentService = new PaymentService();
            Transactions = new ObservableCollection<Transaction>();
            ProcessPaymentCommand = new RelayCommand(ProcessPayment);
            LoadTransactions();
        }

        public ObservableCollection<Transaction> Transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;
                OnPropertyChanged(nameof(Transactions));
            }
        }

        public string SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public ICommand ProcessPaymentCommand { get; }

        private void LoadTransactions()
        {
            // Load transactions from the payment service
            var transactions = _paymentService.GetTransactions();
            Transactions.Clear();
            foreach (var transaction in transactions)
            {
                Transactions.Add(transaction);
            }
        }

        private void ProcessPayment()
        {
            if (string.IsNullOrEmpty(SelectedStudent) || Amount <= 0)
            {
                // Handle validation error
                return;
            }

            var transaction = new Transaction
            {
                StudentName = SelectedStudent,
                Amount = Amount,
                Date = DateTime.Now
            };

            _paymentService.ProcessPayment(transaction);
            LoadTransactions();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}