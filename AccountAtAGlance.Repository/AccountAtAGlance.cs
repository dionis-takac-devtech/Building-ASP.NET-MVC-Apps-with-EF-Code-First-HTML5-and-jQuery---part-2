﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository
{
    public class AccountAtAGlance : DbContext
    {
        public DbSet<BrokerageAccount> BrokerageAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<MarketIndex> MarketIndexes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<MutualFund> MutualFunds { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Security>().ToTable("Security");
            modelBuilder.Entity<Stock>().ToTable("Securities_Stock");
            modelBuilder.Entity<MutualFund>().ToTable("Securities_MutualFund");

            modelBuilder.Entity<WatchList>()
                .HasMany(w => w.Securities).WithMany()
                .Map(map => map.ToTable("WatchListSecurity")
                .MapRightKey("SecurityId")
                .MapLeftKey("WatchListid"));
        }

        public int DeleteAccounts()
        {
            //return base.Database.SqlCommand("DeleteAccounts");
            return base.Database.ExecuteSqlCommand("DeleteAccounts");
        }

        public int DeleteSecuritiesAndExchanges()
        {
            return base.Database.ExecuteSqlCommand("DeleteSecuritiesAndExchanges");
        }
    }
}
