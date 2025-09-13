using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace SPP.App.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private string _welcomeMessage;
        private ObservableCollection<string> _studentList;

        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                _welcomeMessage = value;
                OnPropertyChanged(nameof(WelcomeMessage));
            }
        }

        public ObservableCollection<string> StudentList
        {
            get => _studentList;
            set
            {
                _studentList = value;
                OnPropertyChanged(nameof(StudentList));
            }
        }

        public ICommand LoadStudentsCommand { get; }

        public DashboardViewModel()
        {
            WelcomeMessage = "Welcome to the Dashboard!";
            StudentList = new ObservableCollection<string>();
            LoadStudentsCommand = new RelayCommand(LoadStudents);
        }

        private void LoadStudents()
        {
            // Logic to load students from the database or service
            StudentList.Clear();
            StudentList.Add("Student 1");
            StudentList.Add("Student 2");
            StudentList.Add("Student 3");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}