﻿// <auto-generated />
using CollectionAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CollectionAPI.Migrations
{
    [DbContext(typeof(CollectionContext))]
    [Migration("20170929092653_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("CollectionAPI.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Formed");

                    b.Property<string>("Name");

                    b.Property<string>("OringCity");

                    b.Property<string>("OringCountry");

                    b.HasKey("Id");

                    b.ToTable("Artist");
                });
#pragma warning restore 612, 618
        }
    }
}
