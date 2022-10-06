using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using DebtCollector.Models;
using DebtCollector.Views;
using System;
using DebtCollector.Data;
using Microsoft.Win32;
using System.IO;

namespace DebtCollector.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        private readonly string AppTitle = "The Debt book";
        private Debtor _currentDebtor;
        private ObservableCollection<Debtor> _debtors;
        private string _filePath = "";
        private string _fileName = "No file loaded";
        private bool _dirty = false;
        private int _currentIndex;
        public MainWindowViewModel()
        {
            Debtors = new ObservableCollection<Debtor>();
            Debtors.Add(new Debtor("Bob", 100));
            Debtors.Add(new Debtor("Boeg", -50));
            Debtors.Add(new Debtor("Bobby", 0));
            CurrentDebtor = Debtors[0];
        }

        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }
            set
            {
                SetProperty(ref _currentDebtor, value);
            }
        }

        public ObservableCollection<Debtor> Debtors
        {
            get { return _debtors; }
            set { SetProperty(ref _debtors, value); }
        }

        public string FileName 
        {
            get { return _fileName; }
            set 
            { 
                SetProperty(ref _fileName, value);
                RaisePropertyChanged("Title");
            }
        }

        public bool Dirty
        {
            get { return _dirty; }
            set
            {
                SetProperty(ref _dirty, value);
                RaisePropertyChanged("Title");
            }
        }
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { SetProperty(ref _currentIndex, value); }
        }
        public string Title
        {
            get
            {
                var s = "";
                if (Dirty)
                    s = "*";
                return FileName + s + " - " + AppTitle;
            }
        }

        private DelegateCommand checkSaldoCommand;
        public DelegateCommand CheckSaldoCommand =>
            checkSaldoCommand ?? (checkSaldoCommand = new DelegateCommand(ExecuteCheckSaldoCommand, CanExecuteCheckSaldoCommand)
            .ObservesProperty(() => CurrentIndex));

        void ExecuteCheckSaldoCommand()
        {
            var tempDebtor = CurrentDebtor.Clone();
            var logTransactionvm = new LogTransactionViewModel("Saldo", tempDebtor)
            { };

            var dlg = new LogTransactionView
            {
                DataContext = logTransactionvm,
                Owner = Application.Current.MainWindow
            };

            if (dlg.ShowDialog() != true)
            {
                CurrentDebtor.Transactions = tempDebtor.Transactions;
                CurrentDebtor.CalculateSaldo();
                Dirty = true;
            }
        }

        bool CanExecuteCheckSaldoCommand()
        {
            return CurrentIndex >= 0;
        }

        private DelegateCommand addCommand;
        public DelegateCommand AddCommand =>
            addCommand ?? (addCommand = new DelegateCommand(ExecuteAddCommand));
        void ExecuteAddCommand()
        {
            var newDebtor = new Debtor();
            var vm = new AddDebtorViewModel("Add new debtor", newDebtor);

            var dlg = new AddDebtorView
            {
                DataContext = vm
            };
            if (dlg.ShowDialog() == true)
            {
                Debtors.Add(newDebtor);
                CurrentDebtor = newDebtor; 
                CurrentDebtor.CalculateSaldo();
                Dirty = true;
                
            }
        }
        
        private DelegateCommand _editCommand;
        public DelegateCommand EditCommand =>
            _editCommand ?? (_editCommand = new DelegateCommand(ExecuteEditCommand));

        void ExecuteEditCommand()
        {
            var tempDebtor = CurrentDebtor.Clone();
            var vm = new AddDebtorViewModel("Edit Debtor", tempDebtor)
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
        DelegateCommand _NewFileCommand;
        public DelegateCommand NewFileCommand
        {
            get { return _NewFileCommand = new DelegateCommand(NewFileCommand_Execute); }
        }

        private void NewFileCommand_Execute()
        {
            MessageBoxResult res = MessageBox.Show("Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Debtors.Clear();
                FileName = "";
               
            }
        }

        DelegateCommand _OpenFileCommand;
        public DelegateCommand OpenFileCommand
        {
            get { return _OpenFileCommand = new DelegateCommand(OpenFileCommand_Execute); }
        }

        private void OpenFileCommand_Execute()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Debtor documents|*.dbt|All Files|*.*",
                DefaultExt = "dbt"
            };
            if (_filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(_filePath);

            if (dialog.ShowDialog(Application.Current.MainWindow) == true)
            {
                _filePath = dialog.FileName;
                FileName = Path.GetFileName(_filePath);
                try
                {
                    Debtors = Repository.ReadFile(_filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        DelegateCommand _SaveAsCommand;
        public DelegateCommand SaveAsCommand
        {
            get { return _SaveAsCommand ?? (_SaveAsCommand = new DelegateCommand(SaveAsCommand_Execute)); }
        }

        private void SaveAsCommand_Execute()
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Debtor documents|*.dbt|All Files|*.*",
                DefaultExt = "dbt"
            };
            if (_filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(_filePath);

            if (dialog.ShowDialog(Application.Current.MainWindow) == true)
            {
                _filePath = dialog.FileName;
                FileName = Path.GetFileName(_filePath);
                SaveFile();
            }
        }

        DelegateCommand _SaveCommand;
        public DelegateCommand SaveCommand
        {
            get
            {
                return _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute)
                  .ObservesProperty(() => Debtors.Count));
            }
        }

        private void SaveFileCommand_Execute()
        {
            SaveFile();
        }

        private bool SaveFileCommand_CanExecute()
        {
            return FileName != "" && Debtors.Count > 0;
        }

        private void SaveFile()
        {
            try
            {
                Repository.SaveFile(_filePath, Debtors);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
