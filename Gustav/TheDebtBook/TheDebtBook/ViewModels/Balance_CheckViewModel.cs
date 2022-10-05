using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class Balance_CheckViewModel : BindableBase
    {
        public Balance_CheckViewModel(string title, Debtor debtor)
        {
            Title = title;
            CurrentDebtor = debtor;
            Transactions = new ObservableCollection<Transaction>();
            CurrentTransaction = new Transaction();
        }

        #region Properties
        
        string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private ObservableCollection<Transaction> transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get { return transactions; }
            set { SetProperty(ref transactions, value); }
        }

        Debtor currentDebtor;
        public Debtor CurrentDebtor
        {
            get { return currentDebtor; }
            set { SetProperty(ref currentDebtor, value); }
        }

        Transaction currentTransaction;
        public Transaction CurrentTransaction
        {
            get { return currentTransaction; }
            set { SetProperty(ref currentTransaction, value); }
        }

        public bool IsValid
        {
            get
            {
                bool IsValid = true;
                return IsValid;
            }
        }

        #endregion


        #region Commands

        ICommand _add_Value_btnCommand;
        public ICommand Add_Value_btnCommand => _add_Value_btnCommand ??= new DelegateCommand(
                    Add_Value_Command_Execute, Add_Value_Command_CanExecute);

        private void Add_Value_Command_Execute()
        {}

        private bool Add_Value_Command_CanExecute()
        {
            return IsValid;
        }

        #endregion
    }
}