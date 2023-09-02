using BankApplication.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApplication.WPFClient.VMs.NonCrudVMs
{
    public class GetCustomersByMinBalanceViewModel : ObservableRecipient
    {
        public List<Customer> CustomerCollection { get; set; }
        public int MinimumAccountBalance { get; set; }

        public bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public GetCustomersByMinBalanceViewModel(int minAccountBalance)
        {
            if (!IsInDesignMode)
            {
                MinimumAccountBalance = minAccountBalance;
                RestService restService = new RestService("http://localhost:10928/", typeof(Customer).Name);
                CustomerCollection = restService.Get<Customer>($"NonCrud/GetCustomersByMinBalance?min={MinimumAccountBalance}");
                ;
            }
        }


    }
}
