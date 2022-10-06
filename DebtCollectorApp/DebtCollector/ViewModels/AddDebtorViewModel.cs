using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using DebtCollector.Models;

namespace DebtCollector.ViewModels
{
    public class AddDebtorViewModel : BindableBase
    {
        private string _title;
        Debtor _currentDebtor;
        Transaction _currentTransaction;
        
        public AddDebtorViewModel(string title, Debtor debtor)
        {
            Title = title;
            CurrentDebtor = debtor;
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
        public Transaction CurrentTransaction
        {
            get { return _currentTransaction; }
            set { SetProperty(ref _currentTransaction, value); }
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
        private DelegateCommand saveBtnCommand;
        public DelegateCommand SaveBtnCommand =>
         saveBtnCommand ?? (saveBtnCommand = new DelegateCommand(ExecuteSaveBtnCommand))
            .ObservesProperty(() => CurrentDebtor.Name)
            .ObservesProperty(() => CurrentTransaction.Amount);

        private void ExecuteSaveBtnCommand()
        {}
    }
}
