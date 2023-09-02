using ConsoleTools;
using BankApplication.Models;
using System;

namespace BankApplication.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestService restService = new RestService("http://localhost:10928/", typeof(Customer).Name);
            CrudService crudService = new CrudService(restService);
            NonCrudService nonCrudService = new NonCrudService(restService);

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => crudService.List<Customer>())
                    .Add("Create", () => crudService.Create<Customer>())
                    .Add("Delete", () => crudService.Delete<Customer>())
                    .Add("Update", () => crudService.Update<Customer>())
                    .Add("Exit", ConsoleMenu.Close);

            var currentAccountSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crudService.List<CurrentAccount>())
                .Add("Create", () => crudService.Create<CurrentAccount>())
                .Add("Delete", () => crudService.Delete<CurrentAccount>())
                .Add("Update", () => crudService.Update<CurrentAccount>())
                .Add("Exit", ConsoleMenu.Close);

            var bankCardSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crudService.List<BankCard>())
                .Add("Create", () => crudService.Create<BankCard>())
                .Add("Delete", () => crudService.Delete<BankCard>())
                .Add("Update", () => crudService.Update<BankCard>())
                .Add("Exit", ConsoleMenu.Close);


            var cardTypeSubMenu = new ConsoleMenu(args, level: 2)
                .Add("Visa/Mastercard", () => nonCrudService.AggregateCardsByCountry("ALL"))
                .Add("Only Visa", () => nonCrudService.AggregateCardsByCountry("VISA"))
                .Add("Only Mastercard", () => nonCrudService.AggregateCardsByCountry("MASTERCARD"))
                .Add("Exit", ConsoleMenu.Close);


            var nonCrudMenu = new ConsoleMenu(args, level: 1)
                .Add("Aggregate Cards by Currency", () => nonCrudService.AggregateCardByCurrency())
                .Add("Aggregate Customers by Country", () => nonCrudService.AggregateCustomersByCountry())
                .Add("Get Customers By Minimum Balance", () => nonCrudService.GetCustomersByMinBalance())
                .Add("Get customers who has more than a given amount of cards", () => nonCrudService.GetCustomersByCardCount())
                .Add("Count cards by countries", () => cardTypeSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Customers", () => customerSubMenu.Show())
                .Add("Current Accounts", () => currentAccountSubMenu.Show())
                .Add("Bank Cards", () => bankCardSubMenu.Show())
                .Add("Non Crud methods", () => nonCrudMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
