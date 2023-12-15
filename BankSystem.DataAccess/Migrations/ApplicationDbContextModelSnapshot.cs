﻿// <auto-generated />
using System;
using BankSystemApp.DataAcces.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankSystem.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankSystem.Models.Client", b =>
                {
                    b.Property<int>("IdCardClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCardClient"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCardClient");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            IdCardClient = 11111111,
                            Address = "Prishtine",
                            Email = "bankaccount@gmail.com",
                            Name = "Bank",
                            PhoneNumber = "+38344111222",
                            Surname = "Account"
                        });
                });

            modelBuilder.Entity("BankSystem.Models.CurrentAccount", b =>
                {
                    b.Property<string>("CurrentAccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("AccountBalance")
                        .HasColumnType("float");

                    b.Property<int>("IdCardClient")
                        .HasColumnType("int");

                    b.Property<double>("Reservations")
                        .HasColumnType("float");

                    b.Property<string>("Valuta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrentAccountNumber");

                    b.HasIndex("IdCardClient");

                    b.ToTable("CurrentAccount");
                });

            modelBuilder.Entity("BankSystem.Models.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("CurrentAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CurrentAccountNumber");

                    b.ToTable("Deposit");
                });

            modelBuilder.Entity("BankSystem.Models.CurrentAccount", b =>
                {
                    b.HasOne("BankSystem.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("IdCardClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BankSystem.Models.Deposit", b =>
                {
                    b.HasOne("BankSystem.Models.CurrentAccount", "CurrentAccount")
                        .WithMany()
                        .HasForeignKey("CurrentAccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
