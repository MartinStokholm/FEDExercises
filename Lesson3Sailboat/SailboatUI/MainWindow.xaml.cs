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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SailboatUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sailboat sailboat;
        public MainWindow()
        {
            InitializeComponent();
            sailboat = new Sailboat();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(tbxName);
        }

        private void tbxLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            sailboat.Length = Double.Parse(tbxLength.Text);
        }

        private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            sailboat.Name = tbxName.Text;
        }

        private void btnCalculateHullSpeed_Click(object sender, RoutedEventArgs e)
        {
            tbxHullSpeed.Text = sailboat.Hullspeed().ToString("F1");
            
        }
    }
}
