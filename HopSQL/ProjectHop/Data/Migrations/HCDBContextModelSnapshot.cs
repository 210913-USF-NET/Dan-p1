﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(HCDBContext))]
    partial class HCDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Mods.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.Property<int?>("storeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("storeId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("Mods.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<bool>("IsManager")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Mods.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BeerId")
                        .HasColumnType("integer");

                    b.Property<int>("BeersId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Mods.LineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BeerId")
                        .HasColumnType("integer");

                    b.Property<int>("BeersId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("Mods.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerIndex")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LineItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("SelectedBeerId")
                        .HasColumnType("integer");

                    b.Property<int>("StoresId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LineItemId");

                    b.HasIndex("SelectedBeerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Mods.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Mods.Beer", b =>
                {
                    b.HasOne("Mods.Store", "store")
                        .WithMany("Beers")
                        .HasForeignKey("storeId");

                    b.Navigation("store");
                });

            modelBuilder.Entity("Mods.Inventory", b =>
                {
                    b.HasOne("Mods.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId");

                    b.Navigation("Beer");
                });

            modelBuilder.Entity("Mods.LineItem", b =>
                {
                    b.HasOne("Mods.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId");

                    b.Navigation("Beer");
                });

            modelBuilder.Entity("Mods.Order", b =>
                {
                    b.HasOne("Mods.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Mods.LineItem", "LineItem")
                        .WithMany()
                        .HasForeignKey("LineItemId");

                    b.HasOne("Mods.Beer", "SelectedBeer")
                        .WithMany()
                        .HasForeignKey("SelectedBeerId");

                    b.Navigation("Customer");

                    b.Navigation("LineItem");

                    b.Navigation("SelectedBeer");
                });

            modelBuilder.Entity("Mods.Store", b =>
                {
                    b.Navigation("Beers");
                });
#pragma warning restore 612, 618
        }
    }
}
