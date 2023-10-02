﻿// <auto-generated />
using System;
using HotelManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagement.Migrations
{
    [DbContext(typeof(HotelManagementContext))]
    partial class HotelManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookingHotel", b =>
                {
                    b.Property<Guid>("BookingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingsId", "HotelId");

                    b.HasIndex("HotelId");

                    b.ToTable("BookingHotel");
                });

            modelBuilder.Entity("HotelManagement.Models.HotelManagement.AmenityMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("AmenityMapping");
                });

            modelBuilder.Entity("HotelManagement.Models.HotelManagement.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookingReferences")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookingStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfRoom")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfTraveller")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SumPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("HotelManagement.Models.HotelManagement.Hotel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelManagement.Models.HotelManagement.RoomType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrlsJsonString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfBed")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRoom")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("HotelId");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("BookingHotel", b =>
                {
                    b.HasOne("HotelManagement.Models.HotelManagement.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement.Models.HotelManagement.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelManagement.Models.HotelManagement.AmenityMapping", b =>
                {
                    b.HasOne("HotelManagement.Models.HotelManagement.RoomType", null)
                        .WithMany("Amenities")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelManagement.Models.HotelManagement.RoomType", b =>
                {
                    b.HasOne("HotelManagement.Models.HotelManagement.Booking", null)
                        .WithMany("RomType")
                        .HasForeignKey("BookingId");

                    b.HasOne("HotelManagement.Models.HotelManagement.Hotel", null)
                        .WithMany("RoomTypes")
                        .HasForeignKey("HotelId");
                });

            modelBuilder.Entity("HotelManagement.Models.HotelManagement.Booking", b =>
                {
                    b.Navigation("RomType");
                });

            modelBuilder.Entity("HotelManagement.Models.HotelManagement.Hotel", b =>
                {
                    b.Navigation("RoomTypes");
                });

            modelBuilder.Entity("HotelManagement.Models.HotelManagement.RoomType", b =>
                {
                    b.Navigation("Amenities");
                });
#pragma warning restore 612, 618
        }
    }
}
