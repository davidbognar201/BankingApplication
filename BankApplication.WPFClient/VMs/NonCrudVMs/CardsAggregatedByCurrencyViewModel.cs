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
    public class CardsAggregatedByCurrencyViewModel : ObservableRecipient
    {
        public List<CardByCurrencyInfo> CurrencyDTOCollection { get; set; }

        public bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public CardsAggregatedByCurrencyViewModel()
        {
            if (!IsInDesignMode)
            {
                RestService restService = new RestService("http://localhost:10928/", typeof(Customer).Name);
                CurrencyDTOCollection = restService.Get<CardByCurrencyInfo>("NonCrud/AggregateCardByCurrency");
            }
            ;
        }
    }
}
