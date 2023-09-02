using Castle.Core.Resource;
using BankApplication.Logic;
using BankApplication.Models;
using BankApplication.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Test
{
    public class CustomerLogicTester
    {
        CustomerLogic mockCustomerLogic;
        Mock<IRepositroy<Customer>> mockCustomerRepository;

        [SetUp]
        public void Init()
        {
            Customer mockCustomer1 = new Customer(1, "Customer One", 2000, 3, 10000, "Hungary");
            Customer mockCustomer2 = new Customer(2, "Customer Two", 2000, 3, 10000, "Austria");
            Customer mockCustomer3 = new Customer(3, "Customer Three", 2000, 3, 10000, "Croatia");
            Customer mockCustomer4 = new Customer(4, "Customer Four", 2000, 3, 10000, "Hungary");

            CurrentAccount mockAccount1 = new CurrentAccount(1, 2000, "HUF", "", 1);
            CurrentAccount mockAccount2 = new CurrentAccount(2, 1000, "EUR", "", 2);
            CurrentAccount mockAccount3 = new CurrentAccount(3, 5000, "GBP", "", 3);
            CurrentAccount mockAccount4 = new CurrentAccount(4, 3100, "GBP", "", 3);
            CurrentAccount mockAccount5 = new CurrentAccount(5, 5000, "GBP", "", 4);

            BankCard mockCard1 = new BankCard(1, "5323-4234-3234-2122", "Visa", 432, 1);
            BankCard mockCard2 = new BankCard(2, "4343-5425-1123-8533", "MasterCard", 315, 2);
            BankCard mockCard3 = new BankCard(3, "5323-2333-2355-6424", "Visa", 111, 2);
            BankCard mockCard4 = new BankCard(4, "2342-3242-9732-3222", "MasterCard", 224, 3);
            BankCard mockCard5 = new BankCard(5, "2342-3242-9732-4443", "MasterCard", 542, 3);
            BankCard mockCard6 = new BankCard(6, "5234-2323-9732-6642", "MasterCard", 412, 3);


            mockAccount1.AccountOwner=mockCustomer1;
            mockAccount2.AccountOwner=mockCustomer2;
            mockAccount3.AccountOwner=mockCustomer3;
            mockAccount4.AccountOwner = mockCustomer3;
            mockAccount5.AccountOwner = mockCustomer4;

            mockAccount1.AttachedCards = new List<BankCard>() { mockCard1 };
            mockAccount2.AttachedCards = new List<BankCard>() { mockCard2 };
            mockAccount3.AttachedCards = new List<BankCard>() { mockCard3 };
            mockAccount4.AttachedCards = new List<BankCard>() { mockCard4 };
            mockAccount5.AttachedCards = new List<BankCard>() { mockCard5, mockCard6 };

            mockCustomer1.CustomerAccounts = new List<CurrentAccount>() { mockAccount1 };
            mockCustomer2.CustomerAccounts = new List<CurrentAccount>() { mockAccount2 };
            mockCustomer3.CustomerAccounts = new List<CurrentAccount>() { mockAccount3, mockAccount4 };
            mockCustomer4.CustomerAccounts = new List<CurrentAccount>() { mockAccount5 };
            ;
            mockCustomerRepository = new Mock<IRepositroy<Customer>>();
            mockCustomerRepository.Setup(x => x.ReadAll()).Returns(new List<Customer>(){ mockCustomer1, mockCustomer2, mockCustomer3, mockCustomer4 }.AsQueryable());


            mockCustomerLogic = new CustomerLogic(mockCustomerRepository.Object);
        }

        [Test]
        public void CreateCustomerWithInvalidName()
        {
            var customerWithTooShortName = new Customer(12, "a", 2000, 3, 100000, "Hungary");
            var customerWithNameConsistingSpecialChars = new Customer(10, "Béla&", 2000, 3, 100000, "Hungary");

            try
            {
                mockCustomerLogic.Create(customerWithTooShortName);
                mockCustomerLogic.Create(customerWithNameConsistingSpecialChars);
            }
            catch (Exception)
            {


            }
            mockCustomerRepository.Verify(r => r.Create(customerWithTooShortName), Times.Never);
            mockCustomerRepository.Verify(r => r.Create(customerWithNameConsistingSpecialChars), Times.Never);
        }
        [Test]
        public void CreateCustomerWithValidName()
        {
            var customerWithValidName = new Customer(12, "Arnold", 2000, 3, 100000, "Hungary");

            try
            {
                mockCustomerLogic.Create(customerWithValidName);
            }
            catch (Exception)
            {


            }
            mockCustomerRepository.Verify(r => r.Create(customerWithValidName), Times.Once);
        }
        [Test]
        public void CreateCustomerWithInvalidArgument()
        {
            try
            {
                mockCustomerLogic.Create(null);
            }
            catch (Exception)
            {

                
            }
            mockCustomerRepository.Verify(r => r.Create(null), Times.Never);
            Assert.Throws<ArgumentNullException>(() => mockCustomerLogic.Create(null));
        }
        [Test]
        public void GetCustomersByMinBalanceTest()
        {
            int validInput = 3400;

            var expected = new List<Customer>() 
            {
                new Customer(3, "Customer Three", 2000, 3, 10000, "Croatia"),
                new Customer(4, "Customer Four", 2000, 3, 10000, "Hungary")
            };
            var result = mockCustomerLogic.GetCustomersByMinBalance(validInput);

            CollectionAssert.AreEqual(expected, result);

        }
        [Test]
        public void AggregateCustomersByCountryTest()
        {

            var expected = new List<CountryInfo>(){
                new CountryInfo() {CountryName = "Austria", CustomerCount = 1, AvgBalance = 1000},
                new CountryInfo() {CountryName = "Hungary", CustomerCount = 2, AvgBalance = 3500},
                new CountryInfo() {CountryName = "Croatia", CustomerCount = 1, AvgBalance = 4050}
               
            };

            var result = mockCustomerLogic.AggregateCustomersByCountry();

            CollectionAssert.AreEqual(expected, result);
        }
        [Test]
        public void GetCustomersByCardCountWithValidArgumentTest()
        {
            var expectedWithArgumentThree = new List<Customer>();
            var resultWithArgumentThree = mockCustomerLogic.GetCustomersByCardCount(3);
            CollectionAssert.AreEqual(expectedWithArgumentThree, resultWithArgumentThree);
           
        }
    }
}
