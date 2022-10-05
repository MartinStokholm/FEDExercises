using Prism.Mvvm;
using System.Collections.Generic;
using System.Transactions;

namespace TheDebtBook.Models
{
    public class Debtor : BindableBase
    {
        string? name;
        double balance;
        List<Transaction> transactions;

        public Debtor()
        {
            transactions = new List<Transaction>();
        }

        public Debtor(string aname, double atransaction)
        {
            name = aname;
            transactions = new List<Transaction>();
            var FirstTrans = new Transaction(atransaction);
            transactions.Add(FirstTrans);
            CalcBalance();

        }

        public Debtor Clone()
        {
            return MemberwiseClone() as Debtor;
        }

        public void CalcBalance()
        {
            double NewBalance = 0;
            foreach (Transaction t in transactions)
            {
                NewBalance += t.Amount;

            }
            balance = NewBalance;
        }

        public string? Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public List<Transaction> Transactions
        {
            get { return transactions; }
            set { transactions = value; }
        }
    }
}