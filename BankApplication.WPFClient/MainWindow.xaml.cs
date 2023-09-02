using BankApplication.WPFClient.Editor.Windows;
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

namespace BankApplication.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Equals(custButton))
            {
                CardsAggregatedByCuurencyWindow customerEditorWindow = new CardsAggregatedByCuurencyWindow();
                customerEditorWindow.ShowDialog();
            }
            else if((sender as Button).Equals(cardButton))
            {
                BankCardEditorWindow cardEditorWindow = new BankCardEditorWindow();
                cardEditorWindow.ShowDialog();
            }
            else if ((sender as Button).Equals(caButton))
            {
                CurrentAccountEditorWindow caEditorWindow = new CurrentAccountEditorWindow();
                caEditorWindow.ShowDialog();
            }
            else if ((sender as Button).Equals(noncrudButton))
            {
                ReportWindow reportWindow = new ReportWindow();
                reportWindow.Show();
            }
            else
            {
                this.Close();
            }

        }
    }
}
