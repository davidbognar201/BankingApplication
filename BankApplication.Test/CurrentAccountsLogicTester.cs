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
    public class CurrentAccountsLogicTester
    {
        CurrentAccountLogic currentAccountLogic;
        Mock<IRepositroy<CurrentAccount>> mockCurrentAccountRepository;

        [SetUp]
        public void Init()
        {
            mockCurrentAccountRepository = new Mock<IRepositroy<CurrentAccount>>();
            mockCurrentAccountRepository.Setup(x => x.ReadAll()).Returns(new List<CurrentAccount>()
            {
                new CurrentAccount(1, 1000, "HUF", "", 1),
                new CurrentAccount(2, 10000, "EUR", "",1),
                new CurrentAccount(3, 30000, "EUR", "", 1),
                new CurrentAccount(4, 40000, "HUF", "", 1)
            }.AsQueryable());

            currentAccountLogic = new CurrentAccountLogic(mockCurrentAccountRepository.Object);
        }

        [Test]
        public void CreateCurrentAccountWithInvalidArgument()
        {
            try
            {
                currentAccountLogic.Create(null);
            }
            catch (Exception)
            {

                
            }
            mockCurrentAccountRepository.Verify(r => r.Create(null), Times.Never);
            Assert.Throws<ArgumentNullException>(() => currentAccountLogic.Create(null));
        }
        [Test]
        public void CreateCurrentAccountWithValidArgument()
        {
            CurrentAccount testAccount = new CurrentAccount() { AccountId = 3};
            try
            {
                currentAccountLogic.Create(testAccount);
            }
            catch (Exception)
            {


            }
            mockCurrentAccountRepository.Verify(r => r.Create(testAccount), Times.Once);
        }
    }
}
