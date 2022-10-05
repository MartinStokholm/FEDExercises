using System.Collections.Generic;
using System.Windows;

namespace AgentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Agent> agents = new List<Agent>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = agents;
        }
    }
}
