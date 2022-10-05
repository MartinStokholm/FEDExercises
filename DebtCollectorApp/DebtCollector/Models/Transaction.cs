using Prism.Mvvm;

namespace DebtCollector.Models
{
    public class Transaction : BindableBase
    {
        string _date;
        string _amount;
        
        public Transaction() { }
        public Transaction(string date, string amount)
        {
            _date = date;
            _amount = amount;
        }

        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public string Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
    }
}
