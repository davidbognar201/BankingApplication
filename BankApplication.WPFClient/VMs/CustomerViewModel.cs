using BankApplication.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankApplication.WPFClient.VMs
{
    public class CustomerViewModel : ObservableRecipient
    {
		private Customer selectedCustomer;

		public Customer SelectedCustomer
        {
			get { return selectedCustomer; }
			set 
            { 
                if(value != null)
                {
                    selectedCustomer = new Customer()
                    {
                        CustId = value.CustId,
                        CustName = value.CustName,
                        Cust_XSell_score = value.Cust_XSell_score,
                        CustomerAccounts = value.CustomerAccounts,
                        Country = value.Country,
                        AverageIncome = value.AverageIncome,
                        YearOfBirth = value.YearOfBirth
                    };
                    OnPropertyChanged();
                    (RemoveCustomerCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
		}
        public RestCollection<Customer> CustomerCollection { get; set; }
        public ICommand UpdateCustomerCommand { get; set; }
        public ICommand RemoveCustomerCommand { get; set; }
        public ICommand CreateCustomerCommand { get; set; }
        public bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        } 

        public CustomerViewModel()
		{
            if(!IsInDesignMode)
            {
                CustomerCollection = new RestCollection<Customer>("http://localhost:10928/", "customer", "hub");

                UpdateCustomerCommand = new RelayCommand(() =>
                {
                    CustomerCollection.Update(SelectedCustomer);
                });

                RemoveCustomerCommand = new RelayCommand(() => 
                {
                    CustomerCollection.Delete(SelectedCustomer.CustId);
                },
                () =>
                {
                    return SelectedCustomer != null;
                });

                CreateCustomerCommand = new RelayCommand(() =>
                {
                    CustomerCollection.Add(new Customer()
                    {
                        CustName = SelectedCustomer.CustName,
                        Cust_XSell_score = SelectedCustomer.Cust_XSell_score,
                        CustomerAccounts = SelectedCustomer.CustomerAccounts,
                        Country = SelectedCustomer.Country,
                        AverageIncome = SelectedCustomer.AverageIncome,
                        YearOfBirth = SelectedCustomer.YearOfBirth
                    }) ;
                });

                SelectedCustomer = new Customer();
            }
		}

    }
}
