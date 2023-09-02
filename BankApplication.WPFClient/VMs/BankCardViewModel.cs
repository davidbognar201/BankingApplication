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
    public class BankCardViewModel : ObservableRecipient
    {
        public List<string> cardTypeList = new List<string>()
        {
            "Mastercard",
            "Visa"
        };

        public List<string> CardTypes { get { return cardTypeList; }  }

        private BankCard selectedBankCard;
		public BankCard SelectedBankCard

        {
			get { return selectedBankCard; }
			set 
			{ 
				if(value != null)
				{
                    selectedBankCard = new BankCard() {
                        CardId = value.CardId,
                        Type = value.Type,
                        CVCCode = value.CVCCode,
                        CardNumber = value.CardNumber,
                        AttachedAccountId = value.AttachedAccountId,
                        AttachedAccount = value.AttachedAccount
					};
				}
                ;
				OnPropertyChanged();
				(RemoveBankCardCommand as RelayCommand).NotifyCanExecuteChanged();
			}
		}

        public RestCollection<BankCard> BankCardCollection { get; set; }
        
		public ICommand UpdateBankCardCommand { get; set; }
        public ICommand RemoveBankCardCommand { get; set; }
        public ICommand CreateBankCardCommand { get; set; }
        public bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
		public BankCardViewModel()
		{
            if (!IsInDesignMode)
            {
                BankCardCollection = new RestCollection<BankCard>("http://localhost:10928/", "bankcard", "hub");
                ;

                UpdateBankCardCommand = new RelayCommand(() =>
                {
                    BankCardCollection.Update(SelectedBankCard);
                });

                RemoveBankCardCommand = new RelayCommand(() =>
                {
                    BankCardCollection.Delete(SelectedBankCard.CardId);
                },
                () =>
                {
                    return SelectedBankCard != null;
                });

                CreateBankCardCommand = new RelayCommand(() =>
                {
                    BankCardCollection.Add(new BankCard()
                    {
                        Type = SelectedBankCard.Type,
                        CVCCode = SelectedBankCard.CVCCode,
                        CardNumber = SelectedBankCard.CardNumber
                    });
                });

                SelectedBankCard = new BankCard();
            }
            ;
        }


    }
}
