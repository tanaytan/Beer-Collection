﻿// <auto-generated />
using System;
using Beer_Collection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Beer_Collection.Migrations
{
    [DbContext(typeof(BeerContext))]
    [Migration("20190814092742_beerdb")]
    partial class beerdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Beer_Collection.Data.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("Beer_Collection.Data.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BeerId");

                    b.Property<int>("RatingNum");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Beer_Collection.Data.Rating", b =>
                {
                    b.HasOne("Beer_Collection.Data.Beer", "Beer")
                        .WithMany("Ratings")
                        .HasForeignKey("BeerId");
                });
#pragma warning restore 612, 618
        }
    }
}
