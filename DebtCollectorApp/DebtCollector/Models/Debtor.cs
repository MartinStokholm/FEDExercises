using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace DebtCollector.Models
{
  
    public class Debtor : BindableBase
    {
        string _name;
        string _saldo;
        ObservableCollection<Transaction> _history;

        public Debtor() {}
        public Debtor(string name, string saldo)
        {
            _name = name;
            _saldo = saldo;
        }
        public Debtor Clone()
        {
            return this.MemberwiseClone() as Debtor;
        }

        public ObservableCollection<Transaction> History 
        {
            get { return _history; }
            set { SetProperty(ref _history, value); }
        }

        public string Name 
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
     
        public string Saldo 
        {
            get { return _saldo; }
            set { SetProperty(ref _saldo, value); }
        }    
    }
}
