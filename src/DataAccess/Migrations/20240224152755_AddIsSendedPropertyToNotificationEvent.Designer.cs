﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(NotifyDbContext))]
    [Migration("20240224152755_AddIsSendedPropertyToNotificationEvent")]
    partial class AddIsSendedPropertyToNotificationEvent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("DataAccess.DbNotificationEvent", b =>
                {
                    b.Property<string>("SessionId")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("session_id");

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("card");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("event_date");

                    b.Property<bool>("IsSended")
                        .HasColumnType("BOOLEAN")
                        .HasColumnName("is_sended");

                    b.Property<string>("OrderType")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("order_type");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("website_url");

                    b.HasKey("SessionId");

                    b.ToTable("notify_event", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}