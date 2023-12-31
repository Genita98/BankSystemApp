﻿// <auto-generated />
using System;
using BankSystemApp.DataAcces.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankSystem.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231216203333_addedModelForWithdrawal")]
    partial class addedModelForWithdrawal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankSystem.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCardClient")
                        .HasColumnType("int");

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

                    b.HasKey("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            Address = "Prishtine",
                            Email = "bankaccount@gmail.com",
                            IdCardClient = 11111111,
                            Name = "Bank",
                            PhoneNumber = "+38344111222",
                            Surname = "Account"
                        });
                });

            modelBuilder.Entity("BankSystem.Models.CurrentAccount", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<double>("AccountBalance")
                        .HasColumnType("float");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("CurrentAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Reservations")
                        .HasColumnType("float");

                    b.Property<string>("Valuta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("ClientId");

                    b.ToTable("CurrentAccount");
                });

            modelBuilder.Entity("BankSystem.Models.Deposit", b =>
                {
                    b.Property<int>("DepositId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepositId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DepositId");

                    b.HasIndex("AccountId");

                    b.ToTable("Deposit");
                });

            modelBuilder.Entity("BankSystem.Models.Withdrawal", b =>
                {
                    b.Property<int>("WithdrawalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WithdrawalId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("WithdrawalId");

                    b.HasIndex("AccountId");

                    b.ToTable("Withdrawal");
                });

            modelBuilder.Entity("BankSystem.Models.CurrentAccount", b =>
                {
                    b.HasOne("BankSystem.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BankSystem.Models.Deposit", b =>
                {
                    b.HasOne("BankSystem.Models.CurrentAccount", "CurrentAccount")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentAccount");
                });

            modelBuilder.Entity("BankSystem.Models.Withdrawal", b =>
                {
                    b.HasOne("BankSystem.Models.CurrentAccount", "CurrentAccount")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
