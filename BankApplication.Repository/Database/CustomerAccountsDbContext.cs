using BankApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository
{
    public class CustomerAccountsDbContext : DbContext
    {
        public DbSet<BankCard> BankCardDb { get; set; }
        public DbSet<Customer> CustomerDb { get; set; }
        public DbSet<CurrentAccount> CurrentAccountDb { get; set; }

        public CustomerAccountsDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("CurrentAccountDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BankCard>(x => x
                        .HasOne(x => x.AttachedAccount)
                        .WithMany(x => x.AttachedCards)
                        .HasForeignKey(x => x.AttachedAccountId)
                        .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<CurrentAccount>(x => x
                           .HasOne(x => x.AccountOwner)
                           .WithMany(x => x.CustomerAccounts)
                           .HasForeignKey(x => x.OwnerId)
                           .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer(1, "Kovács Attila", 1995, 4, 321000, "Romania"),
                new Customer(2, "Dr. Kiss Béla", 1998, 2, 635212, "Hungary"),
                new Customer(3, "Kiss Géza", 2001, 8, 133000, "Croatia"),
                new Customer(4, "Bognár Dávid", 1965, 3, 10000, "Hungary"),
                new Customer(5, "Nagy Árpád", 2002, 6, 321000, "France")
            });
            modelBuilder.Entity<CurrentAccount>().HasData(new CurrentAccount[]
            {
                new CurrentAccount(1, 2000, "HUF", "498237427483274873493333", 3),
                new CurrentAccount(2, 1000, "EUR", "940101387483443234323234", 4),
                new CurrentAccount(3, 5000, "GBP", "865863555656535323243444", 5),
                new CurrentAccount(4, 3000, "RUB", "131231255345657568994400", 1),
                new CurrentAccount(5, 3200, "EUR", "453432456787978745332232", 1),
                new CurrentAccount(6, 0, "HUF", "125465312321345678023300", 2)
            });
            modelBuilder.Entity<BankCard>().HasData(new BankCard[]
            {
                new BankCard(1, "6438-4235-2353-2234", "Visa", 652, 2),
                new BankCard(2, "2443-7543-2334-3233", "Mastercard", 525, 1),
                new BankCard(3, "7655-3434-2424-4242", "Mastercard", 314, 4),
                new BankCard(4, "2276-4545-3532-4243", "Visa", 972, 3),
                new BankCard(5, "5355-1545-3418-5422", "Visa", 255, 5),
                new BankCard(6, "4343-1653-4324-9743", "Visa", 123, 2),
                new BankCard(7, "4324-5427-4314-9888", "Mastercard", 115, 2)
            });

        }
    }
}
