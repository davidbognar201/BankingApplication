using BankApplication.Models;
using BankApplication.WPFClient.Editor.Windows.NonCrud.Windows;
using BankApplication.WPFClient.Editor.Windows.NonCrud.Windows.Settings.Windows;
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

namespace BankApplication.WPFClient.Editor.Windows
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if ((sender as Button).Equals(currencyAggButton))
            {
                CardsAggregatedByCurrencyWindow noncrudWindow = new CardsAggregatedByCurrencyWindow();
                noncrudWindow.ShowDialog();
            }
            else if ((sender as Button).Equals(countryAggButton))
            {
                AggregateCustomerByCountryWindow noncrudWindow = new AggregateCustomerByCountryWindow();
                noncrudWindow.ShowDialog();
            }
            else if ((sender as Button).Equals(minBalanceAggButton))
            {
                GetCustomersByMinBalanceSettingsWindow noncrudWindow = new GetCustomersByMinBalanceSettingsWindow();
                noncrudWindow.ShowDialog();
            }
            else if ((sender as Button).Equals(cardCountryAggButton))
            {
                AggregateCardsByCountrySettingWindow noncrudWindow = new AggregateCardsByCountrySettingWindow();
                noncrudWindow.ShowDialog();
            }
            else if ((sender as Button).Equals(cardCntAggButton))
            {
                GetCustomersByCardCountSettingsWindow noncrudWindow = new GetCustomersByCardCountSettingsWindow();
                noncrudWindow.ShowDialog();
            }
            else
            {
                this.Close();
            }
        }
    }
}
