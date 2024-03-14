﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderAPI.Data;

#nullable disable

namespace OrderAPI.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Order.Domain.Aggregates.OrderAggregate.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("QuoteId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderAggregate.Entities.OrderItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("QuoteItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderQuoteAggregate.Entities.OrderQuote", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderRequestId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("QuotedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrderQuoutes");
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderQuoteAggregate.Entities.OrderQuoteItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderQuoteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RequestItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderQuoteId");

                    b.ToTable("OrderQuoteItem");
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderRequestAggregate.Entities.OrderRequest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RejectedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrderRequests");
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderRequestAggregate.Entities.OrderRequestItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderRequestId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrderRequestId");

                    b.ToTable("OrderRequestItem");
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderAggregate.Entities.Order", b =>
                {
                    b.OwnsOne("Order.Domain.Aggregates.OrderAggregate.Types.OrderStatus", "Status", b1 =>
                        {
                            b1.Property<string>("OrderId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .HasColumnType("int")
                                .HasColumnName("Status_Value");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status_Name");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderAggregate.Entities.OrderItem", b =>
                {
                    b.HasOne("Order.Domain.Aggregates.OrderAggregate.Entities.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.OwnsOne("Order.Domain.Shared.Money", "ListPrice", b1 =>
                        {
                            b1.Property<string>("OrderItemId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("ListPrice");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Currency");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.OwnsOne("Order.Domain.Shared.Quantity", "Quantity", b1 =>
                        {
                            b1.Property<string>("OrderItemId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Unit")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Unit");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Quantity");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("ListPrice")
                        .IsRequired();

                    b.Navigation("Quantity")
                        .IsRequired();
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderQuoteAggregate.Entities.OrderQuote", b =>
                {
                    b.OwnsOne("Order.Domain.Aggregates.OrderQuoteAggregate.Types.OrderQuoteStatus", "Status", b1 =>
                        {
                            b1.Property<string>("OrderQuoteId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .HasColumnType("int")
                                .HasColumnName("Status_Value");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status_Name");

                            b1.HasKey("OrderQuoteId");

                            b1.ToTable("OrderQuoutes");

                            b1.WithOwner()
                                .HasForeignKey("OrderQuoteId");
                        });

                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderQuoteAggregate.Entities.OrderQuoteItem", b =>
                {
                    b.HasOne("Order.Domain.Aggregates.OrderQuoteAggregate.Entities.OrderQuote", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderQuoteId");

                    b.OwnsOne("Order.Domain.Shared.Money", "ListPrice", b1 =>
                        {
                            b1.Property<string>("OrderQuoteItemId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("ListPrice");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Currency");

                            b1.HasKey("OrderQuoteItemId");

                            b1.ToTable("OrderQuoteItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderQuoteItemId");
                        });

                    b.OwnsOne("Order.Domain.Shared.Quantity", "Quantity", b1 =>
                        {
                            b1.Property<string>("OrderQuoteItemId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Unit")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Unit");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Quantity");

                            b1.HasKey("OrderQuoteItemId");

                            b1.ToTable("OrderQuoteItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderQuoteItemId");
                        });

                    b.Navigation("ListPrice")
                        .IsRequired();

                    b.Navigation("Quantity")
                        .IsRequired();
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderRequestAggregate.Entities.OrderRequest", b =>
                {
                    b.OwnsOne("Order.Domain.Shared.Money", "Budget", b1 =>
                        {
                            b1.Property<string>("OrderRequestId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Budget_Amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Budget_Currecy");

                            b1.HasKey("OrderRequestId");

                            b1.ToTable("OrderRequests");

                            b1.WithOwner()
                                .HasForeignKey("OrderRequestId");
                        });

                    b.OwnsOne("Order.Domain.Aggregates.OrderRequestAggregate.Types.OrderRequestStatus", "Status", b1 =>
                        {
                            b1.Property<string>("OrderRequestId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .HasColumnType("int")
                                .HasColumnName("Status_Value");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status_Name");

                            b1.HasKey("OrderRequestId");

                            b1.ToTable("OrderRequests");

                            b1.WithOwner()
                                .HasForeignKey("OrderRequestId");
                        });

                    b.Navigation("Budget")
                        .IsRequired();

                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderRequestAggregate.Entities.OrderRequestItem", b =>
                {
                    b.HasOne("Order.Domain.Aggregates.OrderRequestAggregate.Entities.OrderRequest", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Order.Domain.Shared.Quantity", "Quantity", b1 =>
                        {
                            b1.Property<string>("OrderRequestItemId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Unit")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Unit");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Quantity");

                            b1.HasKey("OrderRequestItemId");

                            b1.ToTable("OrderRequestItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderRequestItemId");
                        });

                    b.Navigation("Quantity")
                        .IsRequired();
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderAggregate.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderQuoteAggregate.Entities.OrderQuote", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Order.Domain.Aggregates.OrderRequestAggregate.Entities.OrderRequest", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}