using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AgentApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Agent> agents;

        public MainWindowViewModel() 
        {
            agents = new ObservableCollection<Agent>();
            agents.Add(new Agent("1", "James Bond", "Espionage", "MI6"));
            agents.Add(new Agent("2", "Ethan Hunt", "Espionage", "IMF"));
            agents.Add(new Agent("3", "Jason Bourne", "Espionage", "Treadstone"));
            CurrentAgent = agents[0];
        }
        Agent currentAgent = null;

        public Agent CurrentAgent 
        {
            get { return currentAgent; }
            set
            {
                if (currentAgent != value)
                {
                    currentAgent = value;
                    NotifyPropertyChanged();
                }
            }
        }
   
        public ObservableCollection<Agent> Agents
        {
            get
            {
                return agents;
            }
        }

        public void AddNewAgent()
        {
            agents.Add(new Agent());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
