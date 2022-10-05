using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheDebtBook.Models
{
    public class Transaction : BindableBase
    {
        string _date;
        double amount;

        public Transaction()
        {
            _date = DateTime.Now.ToString("g");
        }

        public Transaction(double anAmount)
        {
            amount = anAmount;
            _date = DateTime.Now.ToString("g");
        }

        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public double Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }
    }
}