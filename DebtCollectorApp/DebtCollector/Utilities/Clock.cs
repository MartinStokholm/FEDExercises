using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DebtCollector.Utilities
{
    public class Clock : INotifyPropertyChanged
    {

        string date;
        string time;

        public Clock()
        {
            Update();
        }

        public void Update()
        {
            Date = DateTime.Now.ToLongDateString();
            Time = DateTime.Now.ToLongTimeString();
        }

        public string Date
        {
            get { return date; }
            private set
            {
                if (date != value)
                {
                    date = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Time
        {
            get { return time; }
            private set
            {
                if (time != value)
                {
                    time = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
