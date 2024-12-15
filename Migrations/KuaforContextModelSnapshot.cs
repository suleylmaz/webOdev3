﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webOdev3.Models;

#nullable disable

namespace webOdev3.Migrations
{
    [DbContext(typeof(KuaforContext))]
    partial class KuaforContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("webOdev3.Models.Calisanlar", b =>
                {
                    b.Property<int>("CalisanlarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalisanlarID"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalonID")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CalisanlarID");

                    b.HasIndex("SalonID");

                    b.ToTable("Calisanlars");
                });

            modelBuilder.Entity("webOdev3.Models.CalisanUzmanlik", b =>
                {
                    b.Property<int>("CalisanUzmanlikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalisanUzmanlikID"), 1L, 1);

                    b.Property<int>("CalisanlarID")
                        .HasColumnType("int");

                    b.Property<int>("HizmetlerID")
                        .HasColumnType("int");

                    b.HasKey("CalisanUzmanlikID");

                    b.HasIndex("CalisanlarID");

                    b.HasIndex("HizmetlerID");

                    b.ToTable("CalisanUzmanliks");
                });

            modelBuilder.Entity("webOdev3.Models.CalismaSaatleri", b =>
                {
                    b.Property<int>("CalismaSaatleriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalismaSaatleriID"), 1L, 1);

                    b.Property<TimeSpan>("BaslangicSaati")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("BitisSaati")
                        .HasColumnType("time");

                    b.Property<int>("CalisanlarID")
                        .HasColumnType("int");

                    b.Property<string>("Gun")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CalismaSaatleriID");

                    b.HasIndex("CalisanlarID");

                    b.ToTable("CalismaSaatleris");
                });

            modelBuilder.Entity("webOdev3.Models.Hizmetler", b =>
                {
                    b.Property<int>("HizmetlerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HizmetlerID"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalonID")
                        .HasColumnType("int");

                    b.Property<int>("Sure")
                        .HasColumnType("int");

                    b.Property<float>("Ucret")
                        .HasColumnType("real");

                    b.HasKey("HizmetlerID");

                    b.HasIndex("SalonID");

                    b.ToTable("Hizmetlers");
                });

            modelBuilder.Entity("webOdev3.Models.Kullanicilar", b =>
                {
                    b.Property<int>("KullanicilarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullanicilarID"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KullanicilarID");

                    b.ToTable("Kullanicilars");
                });

            modelBuilder.Entity("webOdev3.Models.Randevular", b =>
                {
                    b.Property<int>("RandevularID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevularID"), 1L, 1);

                    b.Property<int>("CalisanlarID")
                        .HasColumnType("int");

                    b.Property<int>("HizmetlerID")
                        .HasColumnType("int");

                    b.Property<int>("KullanicilarID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Saat")
                        .HasColumnType("time");

                    b.Property<int>("SalonID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<float>("ToplamUcret")
                        .HasColumnType("real");

                    b.HasKey("RandevularID");

                    b.HasIndex("CalisanlarID");

                    b.HasIndex("HizmetlerID");

                    b.HasIndex("KullanicilarID");

                    b.HasIndex("SalonID");

                    b.ToTable("Randevulars");
                });

            modelBuilder.Entity("webOdev3.Models.Salon", b =>
                {
                    b.Property<int>("SalonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalonID"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("CalismaBaslangic")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("CalismaBitis")
                        .HasColumnType("time");

                    b.Property<string>("Tur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalonID");

                    b.ToTable("Salonlars");
                });

            modelBuilder.Entity("webOdev3.Models.Calisanlar", b =>
                {
                    b.HasOne("webOdev3.Models.Salon", "Salon")
                        .WithMany("Calisanlars")
                        .HasForeignKey("SalonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("webOdev3.Models.CalisanUzmanlik", b =>
                {
                    b.HasOne("webOdev3.Models.Calisanlar", "Calisanlar")
                        .WithMany()
                        .HasForeignKey("CalisanlarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webOdev3.Models.Hizmetler", "Hizmetler")
                        .WithMany("calisanUzmanliks")
                        .HasForeignKey("HizmetlerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisanlar");

                    b.Navigation("Hizmetler");
                });

            modelBuilder.Entity("webOdev3.Models.CalismaSaatleri", b =>
                {
                    b.HasOne("webOdev3.Models.Calisanlar", "Calisanlar")
                        .WithMany("calismaSaatleris")
                        .HasForeignKey("CalisanlarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisanlar");
                });

            modelBuilder.Entity("webOdev3.Models.Hizmetler", b =>
                {
                    b.HasOne("webOdev3.Models.Salon", "Salon")
                        .WithMany("Hizmetlers")
                        .HasForeignKey("SalonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("webOdev3.Models.Randevular", b =>
                {
                    b.HasOne("webOdev3.Models.Calisanlar", "Calisanlar")
                        .WithMany()
                        .HasForeignKey("CalisanlarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webOdev3.Models.Hizmetler", "Hizmetler")
                        .WithMany()
                        .HasForeignKey("HizmetlerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webOdev3.Models.Kullanicilar", "Kullanicilar")
                        .WithMany("Randevulars")
                        .HasForeignKey("KullanicilarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webOdev3.Models.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisanlar");

                    b.Navigation("Hizmetler");

                    b.Navigation("Kullanicilar");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("webOdev3.Models.Calisanlar", b =>
                {
                    b.Navigation("calismaSaatleris");
                });

            modelBuilder.Entity("webOdev3.Models.Hizmetler", b =>
                {
                    b.Navigation("calisanUzmanliks");
                });

            modelBuilder.Entity("webOdev3.Models.Kullanicilar", b =>
                {
                    b.Navigation("Randevulars");
                });

            modelBuilder.Entity("webOdev3.Models.Salon", b =>
                {
                    b.Navigation("Calisanlars");

                    b.Navigation("Hizmetlers");
                });
#pragma warning restore 612, 618
        }
    }
}
