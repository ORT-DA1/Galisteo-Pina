﻿using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class ParkingContext: DbContext
    {
        public ParkingContext(string ConnectionName, IDatabaseInitializer<ParkingContext> initializer = null) : base($"name={ConnectionName}")
        {
            Database.SetInitializer<ParkingContext>(initializer);

        }
        public virtual DbSet<Account> Accounts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sms> Sms { get; set; }
        public DbSet<Country> Countries { get; set; }
    } 
}
