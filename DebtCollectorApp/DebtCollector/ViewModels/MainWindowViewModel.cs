using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using DebtCollector.Models;
using DebtCollector.Views;

namespace DebtCollector.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        private readonly string AppTitle = "The Debt book";

        public MainWindowViewModel()
        {
            Debtors = new ObservableCollection<Debtor>();
            Debtors.Add(new Debtor("Bob", "100"));
            Debtors.Add(new Debtor("Bobby", "200"));
            CurrentDebtor = Debtors[0];
        }
        
        private Debtor _currentDebtor;
        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }
            set
            {
                SetProperty(ref _currentDebtor, value);
            }
        }

        private ObservableCollection<Debtor> _debtors;
        public ObservableCollection<Debtor> Debtors
        {
            get { return _debtors; }
            set { SetProperty(ref _debtors, value); }
        }

        private DelegateCommand addCommand;
        public DelegateCommand AddCommand =>
            addCommand ?? (addCommand = new DelegateCommand(ExecuteAddCommand));
        void ExecuteAddCommand()
        {
            var newDebtor = new Debtor();
            var vm = new DebtorViewModel("Add new debtor", newDebtor);

            var dlg = new AddDebtorView
            {
                DataContext = vm
            };
            if (dlg.ShowDialog() == true)
            {
                Debtors.Add(newDebtor);
                CurrentDebtor = newDebtor; // Or CurrentIndex = Agents.Count - 1;
                
            }
        }
        
        private DelegateCommand _editCommand;
        public DelegateCommand EditCommand =>
            _editCommand ?? (_editCommand = new DelegateCommand(ExecuteEditCommand));

        void ExecuteEditCommand()
        {
            var tempDebtor = CurrentDebtor.Clone();
            var vm = new DebtorViewModel("Edit Debtor", tempDebtor)
            {
                //Specialities = specialities
            };
            var dlg = new LogTransactionView
            {
                DataContext = vm,
                Owner = Application.Current.MainWindow
            };
            if (dlg.ShowDialog() == true)
            {
                // Copy values back
               
                
                
            }
        }

    }
}
