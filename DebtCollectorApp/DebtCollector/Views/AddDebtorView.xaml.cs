using DebtCollector.ViewModels;
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

namespace DebtCollector.Views
{
    /// <summary>
    /// Interaction logic for DeptorView.xaml
    /// </summary>
    public partial class AddDebtorView : Window
    {
        public AddDebtorView()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as AddDebtorViewModel;
            if (vm.IsValid)
            {
                vm.CurrentDebtor.Transactions.Add(vm.CurrentTransaction);
                DialogResult = true;
            }
            else
                MessageBox.Show("Enter values for Name and Initial Value", "Missing data");

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
