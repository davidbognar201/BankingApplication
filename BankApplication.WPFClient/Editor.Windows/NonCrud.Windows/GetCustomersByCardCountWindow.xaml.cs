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
    /// Interaction logic for GetCustomersByCardCountWindow.xaml
    /// </summary>
    public partial class GetCustomersByCardCountWindow : Window
    {
        public GetCustomersByCardCountWindow(int minCardCnt)
        {
            InitializeComponent();
            this.DataContext = new GetCustomersByCardCountViewModel(minCardCnt);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
