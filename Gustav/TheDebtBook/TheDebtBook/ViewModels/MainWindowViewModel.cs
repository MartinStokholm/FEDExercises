using TheDebtBook.Models;
using TheDebtBook.Views;
using TheDebtBook.Data;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;
using System.Collections.Generic;
using Microsoft.Win32;
using System.IO;

namespace TheDebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly string AppTitle = "The Debt Book";
        private string filePath = "";

        public MainWindowViewModel()
        {

            Debtors = new ObservableCollection<Debtor>();
            Debtors.Add(new Debtor("Test1", 1000.00));
            Debtors.Add(new Debtor("Test2", -200.00));
            CurrentDebtor = Debtors[0];
        }


        #region Properties

        Debtor currentDebtor;
        public Debtor CurrentDebtor
        {
            get { return currentDebtor; }
            set { SetProperty(ref currentDebtor, value); }
        }

        private ObservableCollection<Debtor> debtors;
        public ObservableCollection<Debtor> Debtors
        {
            get { return debtors; }
            set { SetProperty(ref debtors, value); }
        }

        private int currentIndex;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set { SetProperty(ref currentIndex, value); }
        }

        private string filename = "";
        public string Filename
        {
            get { return filename; }
            set
            {
                SetProperty(ref filename, value);
                RaisePropertyChanged("Title");
            }
        }

        private bool dirty = false;
        public bool Dirty
        {
            get { return dirty; }
            set
            {
                SetProperty(ref dirty, value);
                RaisePropertyChanged("Title");
            }
        }

        public string Title
        {
            get
            {
                var s = "";
                if (Dirty)
                    s = "*";
                return Filename + s + " - " + AppTitle;
            }
        }

        #endregion


        #region Methods
        #endregion


        #region Commands

        private DelegateCommand _checkBalanceCommand;

        public DelegateCommand CheckBalanceCommand =>
            _checkBalanceCommand ?? (_checkBalanceCommand = new DelegateCommand(ExecuteCheckBalanceCommand, CanExecuteCheckBalanceCommand)
            .ObservesProperty(() => CurrentIndex));

        void ExecuteCheckBalanceCommand()
        {
            var tempDebtor = CurrentDebtor.Clone();
            var balancevm = new Balance_CheckViewModel("Balance", tempDebtor)
            {};

            var dlg = new Balance_Check
            {
                DataContext = balancevm,
                Owner = Application.Current.MainWindow
            };

            if (dlg.ShowDialog() != true)
            {
                CurrentDebtor.Transactions = tempDebtor.Transactions;
                CurrentDebtor.CalcBalance();
                Dirty = true;
            }
        }

        bool CanExecuteCheckBalanceCommand()
        {
            return CurrentIndex >= 0;
        }

        private DelegateCommand addCommand;
        public DelegateCommand AddCommand =>
            addCommand ?? (addCommand = new DelegateCommand(ExecuteAddCommand));

        void ExecuteAddCommand()
        {
            var newDebtor = new Debtor();
            var debtorvm = new Add_DebtorViewModel("Add Debtor", newDebtor);

            var dlg = new Add_Debtor
            {
                DataContext = debtorvm
            };

            if (dlg.ShowDialog() == true)
            {
                Debtors.Add(newDebtor);
                CurrentDebtor = newDebtor;
                CurrentDebtor.CalcBalance();
                Dirty = true;
            }
        }

        DelegateCommand _NewFileCommand;
        public DelegateCommand NewFileCommand
        {
            get { return _NewFileCommand ??= new DelegateCommand(NewFileCommand_Execute); }
        }

        private void NewFileCommand_Execute()
        {
            MessageBoxResult res = MessageBox.Show("Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Debtors.Clear();
                Filename = "";
                Dirty = false;
            }
        }

        DelegateCommand _OpenFileCommand;
        public DelegateCommand OpenFileCommand
        {
            get { return _OpenFileCommand ??= new DelegateCommand(OpenFileCommand_Execute); }
        }

        private void OpenFileCommand_Execute()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Debtor documents|*.dbt|All Files|*.*",
                DefaultExt = "dbt"
            };
            if (filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);

            if (dialog.ShowDialog(Application.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                Filename = Path.GetFileName(filePath);
                try
                {
                    Debtors = Repository.ReadFile(filePath);
                    Dirty = false;
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
            if (filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);

            if (dialog.ShowDialog(Application.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                Filename = Path.GetFileName(filePath);
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
            return filename != "" && Debtors.Count > 0;
        }

        private void SaveFile()
        {
            try
            {
                Repository.SaveFile(filePath, Debtors);
                Dirty = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}