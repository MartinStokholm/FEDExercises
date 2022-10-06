using DebtCollector.Models;
using System.Windows;
using DebtCollector.ViewModels;


namespace DebtCollector.Views
{
    /// <summary>
    /// Interaction logic for LogTransactionView.xaml
    /// </summary>
    public partial class LogTransactionView : Window
    {
        public LogTransactionView()
        {
            InitializeComponent();
        }

        private void button_add_value_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as LogTransactionViewModel;
            Transaction transaction = new Transaction();
            transaction.Amount = vm.CurrentTransaction.Amount;
            vm.CurrentDebtor.Transactions.Add(transaction);
            DataTrans.Items.Refresh();
        }
    }
}
