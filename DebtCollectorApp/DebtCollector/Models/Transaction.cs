using System;
using Prism.Mvvm;

namespace DebtCollector.Models
{
    public class Transaction : BindableBase
    {
        string _date;
        double _amount;
        
        public Transaction() 
        {
            Date = DateTime.Now.ToString("g"); 
        }
        
        public Transaction(double amount)
        {
            Date = DateTime.Now.ToString("g");
            Amount = amount;
        }

        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public double Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
    }
}