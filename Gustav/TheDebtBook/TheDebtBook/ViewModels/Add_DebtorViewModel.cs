using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class Add_DebtorViewModel : BindableBase
    {
        public Add_DebtorViewModel(string title, Debtor debtor)
        {
            Title = title;
            CurrentDebtor = debtor;
            CurrentTransaction = new Transaction();
        }

        #region Properties     
        
        string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
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
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(CurrentDebtor.Name))
                    isValid = false;
                return isValid;
            }
        }

        #endregion


        #region Commands

        ICommand _saveBtnCommand;

        public ICommand SaveBtnCommand => _saveBtnCommand ??= new DelegateCommand(SaveBtnCommand_Execute)
                  .ObservesProperty(() => CurrentDebtor.Name)
                  .ObservesProperty(() => CurrentTransaction.Amount);

        private void SaveBtnCommand_Execute()
        {}

        #endregion
    }
}