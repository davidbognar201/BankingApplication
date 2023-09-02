using BankApplication.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace BankApplication.WPFClient.VMs
{
    public class CurrentAccountViewModel : ObservableRecipient
    {
        private CurrentAccount selectedAccount;
        public CurrentAccount SelectedAccount

        {
            get { return selectedAccount; }
            set
            {
                if (value != null)
                {
                    selectedAccount = new CurrentAccount()
                    {
                        AccountId = value.AccountId,
                        AccountBalance = value.AccountBalance,
                        AccountNumber = value.AccountNumber,
                        AccountCurrency = value.AccountCurrency,
                        OwnerId = value.OwnerId,
                        AttachedCards = value.AttachedCards,
                        AccountOwner = value.AccountOwner

                    };
                }
                OnPropertyChanged();
                (RemoveCurrentAccountCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public RestCollection<CurrentAccount> CurrentAccountCollection { get; set; }
        public ICommand UpdateCurrentAccountCommand { get; set; }
        public ICommand RemoveCurrentAccountCommand { get; set; }
        public ICommand CreateCurrentAccountCommand { get; set; }
        public bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public CurrentAccountViewModel()
        {
            if (!IsInDesignMode)
            {
                CurrentAccountCollection = new RestCollection<CurrentAccount>("http://localhost:10928/", "currentaccount", "hub");
                ;

                UpdateCurrentAccountCommand = new RelayCommand(() =>
                {
                    CurrentAccountCollection.Update(SelectedAccount);
                });

                RemoveCurrentAccountCommand = new RelayCommand(() =>
                {
                    CurrentAccountCollection.Delete(SelectedAccount.AccountId);
                },
                () =>
                {
                    return SelectedAccount != null;
                });

                CreateCurrentAccountCommand = new RelayCommand(() =>
                {
                    CurrentAccountCollection.Add(new CurrentAccount()
                    {
                        AccountBalance = SelectedAccount.AccountBalance,
                        AccountCurrency = SelectedAccount.AccountCurrency,
                        AccountNumber = SelectedAccount.AccountNumber
                    });
                });
                SelectedAccount = new CurrentAccount();
            }
        }
    }
}
