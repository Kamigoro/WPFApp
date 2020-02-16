using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DatabaseTestWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour ConfigurationPage.xaml
    /// </summary>
    public partial class ConfigurationPage : Page
    {
        public ConfigurationPage()
        {
            InitializeComponent();
            LoadComPortList();
        }

        private void BTNRefreshComPortList_Click(object sender, RoutedEventArgs e)
        {
            LoadComPortList();
        }

        private void LoadComPortList()
        {
            CBXComPort.Items.Clear();
            foreach(string comPortFound in SerialPort.GetPortNames())
            {
                CBXComPort.Items.Add(comPortFound);
            }
        }

        /// <summary> Permet de bloquer l'entrée de caractère non numérique dans une textbox </summary>
        private void NumericalTextBoxHandler(object sender, TextCompositionEventArgs e)
        {
            //Si l'input ne correspond pas à l'expression régulière, nous n'acceptons pas
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
    }
}
