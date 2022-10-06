using Prism.Mvvm;
using System.Collections.Generic;

namespace DebtCollector.Models
{
  
    public class Debtor : BindableBase
    {
        string _name;
        double _saldo;
        List<Transaction> _transactions;

        public Debtor() 
        {
            _transactions = new List<Transaction>();
        }
        
        public Debtor(string name, double initialAmount)
        {
            Name = name;
            Transactions = new List<Transaction>();
            var FirstTransaction = new Transaction(initialAmount);
            Transactions.Add(FirstTransaction);
            CalculateSaldo();
        }
        
        public Debtor Clone()
        {
            return this.MemberwiseClone() as Debtor;
        }
        
        public void CalculateSaldo()
        {
            double saldo = 0;
            foreach (Transaction item in Transactions)
            {
                saldo += item.Amount;
            }
            _saldo = saldo;
        }
        
        public string Name 
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public double Saldo
        {
            get { return _saldo; }
            set { SetProperty(ref _saldo, value); }
        }    
        
        public List<Transaction> Transactions 
        {
            get { return _transactions; }
            set { SetProperty(ref _transactions, value); }
        }
    }
}