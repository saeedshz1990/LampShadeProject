﻿using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;

namespace AccountManagement.Infrastructure.EFCore
{
    public class AccountContext :DbContext
    {
        public DbSet<Account> Account { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
           

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(AccountContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
