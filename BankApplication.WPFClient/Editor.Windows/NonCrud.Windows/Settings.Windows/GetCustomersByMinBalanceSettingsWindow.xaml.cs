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
    /// Interaction logic for GetCustomersByMinBalanceSettingsWindow.xaml
    /// </summary>
    public partial class GetCustomersByMinBalanceSettingsWindow : Window
    {
        public GetCustomersByMinBalanceSettingsWindow()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            int minBalance = int.Parse(minAmount.Text);
            GetCustomersByMinBalanceWindow minBalanceWindow = new GetCustomersByMinBalanceWindow(minBalance);
            minBalanceWindow.ShowDialog();
        }
    }
}
