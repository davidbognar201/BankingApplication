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
    public class GetCustomersByCardCountViewModel : ObservableRecipient
    {
        public int MinCardCnt { get; set; }
        public List<Customer> CustomerCollection { get; set; }
        public bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public GetCustomersByCardCountViewModel(int minCardCnt)
        {
            MinCardCnt = minCardCnt;
            if (!IsInDesignMode)
            {
                MinCardCnt = minCardCnt;
                RestService restService = new RestService("http://localhost:10928/", typeof(Customer).Name);
                CustomerCollection = restService.Get<Customer>($"NonCrud/GetCustomersByCardCount?cardCnt={MinCardCnt}");
                ;
            }
        }
    }
}
