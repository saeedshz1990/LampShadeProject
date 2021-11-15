﻿using DiscountManagement.DOmain.ColleagueDiscountAgg;
using DiscountManagement.DOmain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.EFCore
{
    public class DiscountContext :DbContext
    {
        public DbSet<CustomerDiscount> CustomerDisounts { get; set; }
        public DbSet<ColleagueDiscount> ColleagueDiscounts { get; set; }

        public DiscountContext(DbContextOptions<DiscountContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
