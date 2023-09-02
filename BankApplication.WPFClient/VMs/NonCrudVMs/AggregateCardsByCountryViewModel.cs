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
    public class AggregateCardsByCountryViewModel : ObservableRecipient
    {
        public List<CardInfoByCountry> CountryDTOCollection { get; set; }
        public string UsedCardType { get; set; }

        public bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public AggregateCardsByCountryViewModel(string usedCardType)
        {

            if (!IsInDesignMode)
            {
                UsedCardType = usedCardType;
                RestService restService = new RestService("http://localhost:10928/", typeof(Customer).Name);
                CountryDTOCollection = restService.Get<CardInfoByCountry>($"NonCrud/AggregateCardsByCountry?cardType={usedCardType}");
                ;
            }
            ;
        }
    }
}
