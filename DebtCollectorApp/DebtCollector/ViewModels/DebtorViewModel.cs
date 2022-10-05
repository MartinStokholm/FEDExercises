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
    public class DebtorViewModel : BindableBase
    {
        public DebtorViewModel(string title, Debtor debtor)
        {
            Title = title;
            CurrentDebtor = debtor;
        }

        private string _title;
        
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        Debtor _currentDebtor;
        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }
            set { SetProperty(ref _currentDebtor, value); }
        }
    }
}
