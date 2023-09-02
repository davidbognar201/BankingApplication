using BankApplication.Logic;
using BankApplication.Models;
using BankApplication.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApplication.Test
{
    [TestFixture]
    public class BankCardLogicTester
    {
        BankCardLogic bankCardLogic;

        Mock<IRepositroy<BankCard>> mockBankCardRepository;

        [SetUp]
        public void Init()
        {
            BankCard mockCard1 = new BankCard(1, "5323-4234-3234-2122", "Visa", 524, 1);
            BankCard mockCard2 = new BankCard(2, "4343-5425-1123-8533", "MasterCard", 555, 2);
            BankCard mockCard3 = new BankCard(3, "5323-2333-2355-6424", "Visa", 424, 2);
            BankCard mockCard4 = new BankCard(4, "2342-3242-9732-4443", "MasterCard", 424, 3);
            BankCard mockCard5 = new BankCard(5, "2342-3242-9732-4443", "MasterCard", 421, 3);

            CurrentAccount mockAccount1 = new CurrentAccount(1, 2000, "HUF", "", 1);
            CurrentAccount mockAccount2 = new CurrentAccount(2, 1000, "EUR", "", 2);
            CurrentAccount mockAccount3 = new CurrentAccount(3, 5000, "GBP", "", 3);

            Customer mockCustomer1 = new Customer() { CustId = 1, CustName = "Moccker1", Country = "Albania"};
            Customer mockCustomer2= new Customer() { CustId = 2, CustName = "Moccker2", Country = "USA" };
            Customer mockCustomer3 = new Customer() { CustId = 3, CustName = "Moccker3", Country = "USA" };

            mockAccount1.AccountOwner = mockCustomer1;
            mockAccount2.AccountOwner = mockCustomer2;
            mockAccount3.AccountOwner = mockCustomer3;

            mockCard1.AttachedAccount = mockAccount1;
            mockCard2.AttachedAccount = mockAccount2;
            mockCard3.AttachedAccount = mockAccount2;
            mockCard4.AttachedAccount = mockAccount3;
            mockCard5.AttachedAccount = mockAccount3;

            mockBankCardRepository = new Mock<IRepositroy<BankCard>>();
            mockBankCardRepository.Setup(x => x.ReadAll()).Returns(new List<BankCard>() { mockCard1, mockCard2, mockCard3, mockCard4, mockCard5}.AsQueryable());
            bankCardLogic = new BankCardLogic(mockBankCardRepository.Object);

            
        }

        [Test]
        public void CreateBankCardTestWithCardNumberContainsInvalidCharacter()
        {
            var bankCard = new BankCard() { CardId = 5, CardNumber = "asd1-4232-4444-3131", CVCCode = 324, AttachedAccountId = 4, Type = "Visa" };

            try
            {
                bankCardLogic.Create(bankCard);
            }
            catch (Exception)
            {


            }
            mockBankCardRepository.Verify(r => r.Create(bankCard), Times.Never);
        }
        [Test]
        public void CreateBankCardTestWithInvalidLengthCardNumber()
        {
            var bankCard = new BankCard() { CardId = 5, CardNumber = "1111-4232-4444-3131-", CVCCode = 333, AttachedAccountId = 4, Type = "Visa" };

            try
            {
                bankCardLogic.Create(bankCard);
            }
            catch (Exception)
            {

                
            }
            mockBankCardRepository.Verify(r => r.Create(bankCard), Times.Never);
        }
        [Test]
        public void CreateBankCardTestWithValidCardNumber()
        {
            var bankCard = new BankCard() { CardId = 5, CardNumber = "7342-4232-4444-3131", CVCCode = 134, AttachedAccountId = 4, Type = "Visa" };
            try
            {
                bankCardLogic.Create(bankCard);
            }
            catch (Exception)
            {

                
            }
            


            mockBankCardRepository.Verify(r => r.Create(bankCard), Times.Once);
        }
        [Test]
        public void CreateBankCardWithNullArgument()
        {
            try
            {
                bankCardLogic.Create(null);
            }
            catch (Exception)
            {

                
            }

            mockBankCardRepository.Verify(r => r.Create(null), Times.Never);
            Assert.Throws<ArgumentNullException>(() => bankCardLogic.Create(null));
        }
        [Test]
        public void AggregateCardByCurrencyTest()
        {
            List<CardByCurrencyInfo> expected = new List<CardByCurrencyInfo>()
            {
                new CardByCurrencyInfo("HUF", "Visa", 1),
                new CardByCurrencyInfo("EUR", "MasterCard", 1),
                new CardByCurrencyInfo("EUR", "Visa", 1),
                new CardByCurrencyInfo("GBP", "MasterCard", 2)
            };


            var result = bankCardLogic.AggregateCardByCurrency().ToList<CardByCurrencyInfo>();

            

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void AggregateCardsByCountryTestWithCardTypeEqualsAllArguments()
        {
            var resultWithAllCards = bankCardLogic.AggregateCardsByCountry("ALL");

            List<CardInfoByCountry> expectedWithAllCards = new List<CardInfoByCountry>()
            {
                new CardInfoByCountry() {CountryName = "Albania", AllCardAmount = 1},
                new CardInfoByCountry() {CountryName = "USA", AllCardAmount = 4}
              
            };

            CollectionAssert.AreEqual(expectedWithAllCards, resultWithAllCards);
        }

        [Test]
        public void AggregateCardsByCountryTestWithCardTypeEqualsVisaArguments()
        {

            var resultWithVisaCards = bankCardLogic.AggregateCardsByCountry("VISA");

            List<CardInfoByCountry> expectedWithVisaCards = new List<CardInfoByCountry>()
            {
                new CardInfoByCountry() {CountryName = "Albania", AllCardAmount = 1},
                new CardInfoByCountry() {CountryName = "USA", AllCardAmount = 1}
                
            };

            CollectionAssert.AreEqual(expectedWithVisaCards, resultWithVisaCards);

        }

        [Test]
        public void AggregateCardsByCountryTestWithCardTypeEqualsMastercardArguments()
        {

            var resultWithMasterCards = bankCardLogic.AggregateCardsByCountry("MASTERCARD");

            List<CardInfoByCountry> expectedWithMasterCards = new List<CardInfoByCountry>()
            {
                new CardInfoByCountry() {CountryName = "USA", AllCardAmount = 3}
                
            };


            CollectionAssert.AreEqual(expectedWithMasterCards, resultWithMasterCards);

        }

        [Test]
        public void AggregateCardsByCountryTestWithInvalidArgument()
        {

            Assert.Throws<ArgumentException>(() => bankCardLogic.AggregateCardsByCountry("DefinitelyNotValidArgument"));

            
        }
    }
}
