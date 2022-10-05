using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheDebtBook.Models;
using TheDebtBook.ViewModels;

namespace TheDebtBook.Views
{
    /// <summary>
    /// Interaction logic for Balance_Check.xaml
    /// </summary>
    public partial class Balance_Check : Window
    {
        public Balance_Check()
        {
            InitializeComponent();
        }

        private void button_add_value_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as Balance_CheckViewModel;
            Transaction Trans = new Transaction();
            Trans.Amount = vm.CurrentTransaction.Amount;
            vm.CurrentDebtor.Transactions.Add(Trans);
            DataTrans.Items.Refresh();
        }
    }
}