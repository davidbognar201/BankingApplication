using BankApplication.WPFClient.VMs.NonCrudVMs;
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

namespace BankApplication.WPFClient.Editor.Windows.NonCrud.Windows.Settings.Windows
{
    /// <summary>
    /// Interaction logic for AggregateCardsByCountrySettingWindow.xaml
    /// </summary>
    public partial class AggregateCardsByCountrySettingWindow : Window
    {
        public AggregateCardsByCountrySettingWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Button).Equals(allButton))
            {
                //var asd = new AggregateCardsByCountryViewModel("ALL");
                AggregateCardsByCountryWindow aggCardWindow = new AggregateCardsByCountryWindow("ALL");
                aggCardWindow.Show();
            }
            else if((sender as Button).Equals(visaButton))
            {
                AggregateCardsByCountryWindow aggCardWindow = new AggregateCardsByCountryWindow("VISA");
                aggCardWindow.Show();
            }
            else if ((sender as Button).Equals(mcButton))
            {
                AggregateCardsByCountryWindow aggCardWindow = new AggregateCardsByCountryWindow("MASTERCARD");
                aggCardWindow.Show();
            }
        }
    }
}
