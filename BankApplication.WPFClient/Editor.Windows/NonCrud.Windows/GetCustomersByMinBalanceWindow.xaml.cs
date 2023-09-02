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

namespace BankApplication.WPFClient.Editor.Windows.NonCrud.Windows
{
    /// <summary>
    /// Interaction logic for GetCustomersByMinBalanceWindow.xaml
    /// </summary>
    public partial class GetCustomersByMinBalanceWindow : Window
    {
        public GetCustomersByMinBalanceWindow(int minAccountBalance)
        {
            InitializeComponent();
            this.DataContext = new GetCustomersByMinBalanceViewModel(minAccountBalance);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
