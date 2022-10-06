using DebtCollector.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;


namespace DebtCollector.ViewModels
{
    public class LogTransactionViewModel : BindableBase
    {
        string _title;
        Debtor _currentDebtor;
        ObservableCollection<Transaction> _transactions;
        Transaction _currentTransaction;
        
        public LogTransactionViewModel(string title, Debtor debtor)
        {
            Title = title;
            CurrentDebtor = debtor;
            Transactions = new ObservableCollection<Transaction>();
            CurrentTransaction = new Transaction();
        }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }
            set { SetProperty(ref _currentDebtor, value); }
        }
        public bool IsValid
        {
            get
            {
                bool IsValid = true;
                return IsValid;
            }
        }

        public ObservableCollection<Transaction> Transactions
        {
            get { return _transactions; }
            set { SetProperty(ref _transactions, value); }
        }

        public Transaction CurrentTransaction
        {
            get { return _currentTransaction; }
            set { SetProperty(ref _currentTransaction, value); }
        }

        private DelegateCommand addValuebtnCommand;
        public DelegateCommand AddValuebtnCommand =>
            addValuebtnCommand ?? (addValuebtnCommand = new DelegateCommand(
                ExecuteAddValuebtnCommand, CanExecuteAddValuebtnCommand));        

        private void ExecuteAddValuebtnCommand()
        { }

        private bool CanExecuteAddValuebtnCommand()
        {
            return IsValid;
        }
    }
}
