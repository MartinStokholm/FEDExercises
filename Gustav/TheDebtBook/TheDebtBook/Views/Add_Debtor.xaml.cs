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
using TheDebtBook.ViewModels;

namespace TheDebtBook.Views
{
    /// <summary>
    /// Interaction logic for Add_Debtor.xaml
    /// </summary>
    public partial class Add_Debtor : Window
    {
        public Add_Debtor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as Add_DebtorViewModel;
            if (vm.IsValid)
            {
                vm.CurrentDebtor.Transactions.Add(vm.CurrentTransaction);
                DialogResult = true;
            }
            else
                MessageBox.Show("Enter values for Name and Initial Value", "Missing data");
        }

        private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
