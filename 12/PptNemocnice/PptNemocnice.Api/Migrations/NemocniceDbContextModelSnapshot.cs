﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PptNemocnice.Api.Data;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    [DbContext(typeof(NemocniceDbContext))]
    partial class NemocniceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("PptNemocnice.Api.Data.Revize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("VybaveniId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VybaveniId");

                    b.ToTable("Revizes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbbca371-e28b-4107-845c-ac9823893da4"),
                            DateTime = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Přísná revize",
                            VybaveniId = new Guid("aaaca371-e28b-4107-845c-ac9823893da4")
                        },
                        new
                        {
                            Id = new Guid("dddca371-e28b-4107-845c-ac9823893da4"),
                            DateTime = new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nicmoc revize",
                            VybaveniId = new Guid("aaaca371-e28b-4107-845c-ac9823893da4")
                        });
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Vybaveni", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BoughtDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PriceCzk")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Vybavenis");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aaaca371-e28b-4107-845c-ac9823893da4"),
                            BoughtDateTime = new DateTime(2017, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "CT",
                            PriceCzk = 100000
                        },
                        new
                        {
                            Id = new Guid("111ca371-e28b-4107-845c-ac9823893da4"),
                            BoughtDateTime = new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MRI",
                            PriceCzk = 10000
                        });
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Revize", b =>
                {
                    b.HasOne("PptNemocnice.Api.Data.Vybaveni", "Vybaveni")
                        .WithMany("Revizes")
                        .HasForeignKey("VybaveniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vybaveni");
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Vybaveni", b =>
                {
                    b.Navigation("Revizes");
                });
#pragma warning restore 612, 618
        }
    }
}