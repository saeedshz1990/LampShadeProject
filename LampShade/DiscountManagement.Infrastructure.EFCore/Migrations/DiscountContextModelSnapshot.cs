﻿// <auto-generated />
using System;
using DiscountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiscountManagement.Infrastructure.EFCore.Migrations
{
    [DbContext(typeof(DiscountContext))]
    partial class DiscountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiscountManagement.DOmain.ColleagueDiscountAgg.ColleagueDiscount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("DiscountRate");

                    b.Property<bool>("IsRemoved");

                    b.Property<long>("ProductId");

                    b.HasKey("Id");

                    b.ToTable("ColleagueDiscounts");
                });

            modelBuilder.Entity("DiscountManagement.DOmain.CustomerDiscountAgg.CustomerDiscount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("DiscountRate");

                    b.Property<DateTime>("EndDate");

                    b.Property<long>("ProductId");

                    b.Property<string>("Reason");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("CustomerDiscounts");
                });
#pragma warning restore 612, 618
        }
    }
}
