using ConsoleTools;
using BankApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankApplication.Client
{
    public class NonCrudService
    {
        private RestService restService;

        public NonCrudService(RestService restService)
        {
            this.restService = restService;
        }

        public void AggregateCustomersByCountry()
        {
            var list = restService.Get<CountryInfo>("NonCrud/AggregateCustomersByCountry");
            Console.WriteLine("Customers aggregated by their country");
            ;
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        public void AggregateCardByCurrency()
        {
            var list = restService.Get<CardByCurrencyInfo>("NonCrud/AggregateCardByCurrency");
            Console.WriteLine("Bank cards aggregated by account currencies");
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        public void GetCustomersByMinBalance()
        {
            Console.Write("Minimum account balance:");
            Console.WriteLine();
            try
            {
                int min = int.Parse(Console.ReadLine());

                var list = restService.Get<Customer>($"NonCrud/GetCustomersByMinBalance?min={min}");
                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                else Console.WriteLine("There are no customers who match the given minimum balance");
                

            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
        public void AggregateCardsByCountry(string cardType)
        {
            var list = restService.Get<CardInfoByCountry>($"NonCrud/AggregateCardsByCountry?cardType={cardType}");

            Console.WriteLine("CountryName: All cards in the country -- From which blocked");
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

        }

        public void GetCustomersByCardCount()            
        {
            Console.WriteLine("Enter a number ( >=0 ): ");
            int cardCnt = -5;
            bool validInput = false;
            do
            {
                try
                {
                    cardCnt = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                if (cardCnt >= 0)
                {
                    validInput = true;
                }
                else Console.WriteLine("Not valid input. Number must be >= 0");
            } while (!validInput);
            
            
            var list = restService.Get<Customer>($"NonCrud/GetCustomersByCardCount?cardCnt={cardCnt}");

            Console.WriteLine($"Customers who has more than {cardCnt} cards");
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
    }
}
