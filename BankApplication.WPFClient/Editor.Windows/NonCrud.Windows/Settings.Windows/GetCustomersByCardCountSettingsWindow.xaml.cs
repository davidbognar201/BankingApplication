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
    /// Interaction logic for GetCustomersByCardCountSettingsWindow.xaml
    /// </summary>
    public partial class GetCustomersByCardCountSettingsWindow : Window
    {
        public GetCustomersByCardCountSettingsWindow()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            int minCardCnt = int.Parse(minAmount.Text);
            GetCustomersByCardCountWindow minBalanceWindow = new GetCustomersByCardCountWindow(minCardCnt);
            minBalanceWindow.ShowDialog();
        }
    }
}
