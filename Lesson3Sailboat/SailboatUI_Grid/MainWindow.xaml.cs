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

namespace SailboatUI_Grid
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
            PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.L:
                    {
                        if (Keyboard.Modifiers == ModifierKeys.Control & FontSize < 42)
                        {
                            FontSize += 2;
                            e.Handled = true;
                        }
                    }
                    break;

                case Key.S:
                    {
                        if (Keyboard.Modifiers == ModifierKeys.Control & FontSize > 12)
                        {
                            FontSize -= 2;
                            e.Handled = true;
                        }
                    }
                    break;                

                default:
                    break;
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(tbxName);
        }

        private void tbxLength_TextChanged(object sender, TextChangedEventArgs e)
        {
       
            if (tbxLength.Text.Trim() != "")
            {
                try
                {
                    sailboat.Length = Double.Parse(tbxLength.Text);
                }
                catch 
                {
                    MessageBox.Show("Length can only be expressed using numbers");
                    tbxLength.Text = "";
                }
            }
        }

        private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            sailboat.Name = tbxName.Text;
        }

        private void btnCalculateHullSpeed_Click(object sender, RoutedEventArgs e)
        {
            tbxHullSpeed.Text = sailboat.Hullspeed().ToString("F1");
            
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tbxName.Text.Trim() != "")
                MessageBox.Show($"This boat is named {sailboat.Name}");
            else         
                MessageBox.Show("This boat aint got a name yet!");
            
        }
    }
}
