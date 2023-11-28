﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Organizarty.Infra.Data.Contexts;

#nullable disable

namespace Organizarty.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Organizarty.Application.App.DecorationInfos.Entities.DecorationInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<Guid>("DecorationTypeId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsAvaible")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("TextureURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DecorationTypeId");

                    b.ToTable("DecorationInfos");
                });

            modelBuilder.Entity("Organizarty.Application.App.DecorationTypes.Entities.DecorationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("ObjectURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("TagsJSON")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DecorationTypes");
                });

            modelBuilder.Entity("Organizarty.Application.App.Foods.Entities.FoodInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Flavour")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("varchar(35)");

                    b.Property<Guid>("FoodTypeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ImagesJson")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("FoodInfos");
                });

            modelBuilder.Entity("Organizarty.Application.App.Foods.Entities.FoodType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("varchar(35)");

                    b.Property<string>("TagsJSON")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ThirdPartyId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ThirdPartyId");

                    b.ToTable("FoodTypes");
                });

            modelBuilder.Entity("Organizarty.Application.App.Locations.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<double?>("AreaSize")
                        .HasColumnType("double");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Cords")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("ImagesJson")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("RentPerDay")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Organizarty.Application.App.Managers.Entities.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Organizarty.Application.App.Party.Entities.DecorationGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DecorationInfoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("PartyTemplateId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DecorationInfoId");

                    b.HasIndex("PartyTemplateId");

                    b.ToTable("DecorationGroups");
                });

            modelBuilder.Entity("Organizarty.Application.App.Party.Entities.FoodGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FoodInfoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<Guid>("PartyTemplateId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodInfoId");

                    b.HasIndex("PartyTemplateId");

                    b.ToTable("FoodGroups");
                });

            modelBuilder.Entity("Organizarty.Application.App.Party.Entities.PartyTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("ExpectedGuests")
                        .HasColumnType("int");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("OriginalPartyTemplateId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("OriginalPartyTemplateId");

                    b.HasIndex("UserId");

                    b.ToTable("PartyTemplates");
                });

            modelBuilder.Entity("Organizarty.Application.App.Party.Entities.ServiceGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<Guid>("PartyTemplateId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ServiceInfoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PartyTemplateId");

                    b.HasIndex("ServiceInfoId");

                    b.ToTable("ServiceGroups");
                });

            modelBuilder.Entity("Organizarty.Application.App.Schedules.Entities.DecorationOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DecorationId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DecorationId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("DecorationOrders");
                });

            modelBuilder.Entity("Organizarty.Application.App.Schedules.Entities.FoodOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("FoodInfoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Note")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<Guid>("PartyTemplateId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("ThirdPartyId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("FoodInfoId");

                    b.HasIndex("PartyTemplateId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("ThirdPartyId");

                    b.ToTable("FoodOrders");
                });

            modelBuilder.Entity("Organizarty.Application.App.Schedules.Entities.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ExpectedGuests")
                        .HasColumnType("int");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("PartyId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("PartyId");

                    b.HasIndex("UserId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Organizarty.Application.App.Schedules.Entities.ServiceOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ServiceInfoId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("ThirdPartyId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("ServiceInfoId");

                    b.HasIndex("ThirdPartyId");

                    b.ToTable("ServiceOrders");
                });

            modelBuilder.Entity("Organizarty.Application.App.Services.Entities.ServiceInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ImagesJson")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAvaible")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Plan")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<Guid>("ServiceTypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("ServiceInfos");
                });

            modelBuilder.Entity("Organizarty.Application.App.Services.Entities.ServiceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TagsJSON")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ThirdPartyId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ThirdPartyId");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("Organizarty.Application.App.ThirdParties.Entities.ThirdParty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int>("AuthorizationStatus")
                        .HasColumnType("int");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("LoginEmail")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfissionalPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TagJSON")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("LoginEmail")
                        .IsUnique();

                    b.ToTable("ThirdParties");
                });

            modelBuilder.Entity("Organizarty.Application.App.Users.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("longtext");

                    b.Property<string>("RolesJson")
                        .HasColumnType("longtext");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Organizarty.Application.App.Users.Entities.UserConfirmation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ValidFor")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserConfirmations");
                });

            modelBuilder.Entity("Organizarty.Application.App.DecorationInfos.Entities.DecorationInfo", b =>
                {
                    b.HasOne("Organizarty.Application.App.DecorationTypes.Entities.DecorationType", "DecorationType")
                        .WithMany("Decorations")
                        .HasForeignKey("DecorationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DecorationType");
                });

            modelBuilder.Entity("Organizarty.Application.App.Foods.Entities.FoodInfo", b =>
                {
                    b.HasOne("Organizarty.Application.App.Foods.Entities.FoodType", "FoodType")
                        .WithMany("Foods")
                        .HasForeignKey("FoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodType");
                });

            modelBuilder.Entity("Organizarty.Application.App.Foods.Entities.FoodType", b =>
                {
                    b.HasOne("Organizarty.Application.App.ThirdParties.Entities.ThirdParty", "ThirdParty")
                        .WithMany()
                        .HasForeignKey("ThirdPartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThirdParty");
                });

            modelBuilder.Entity("Organizarty.Application.App.Party.Entities.DecorationGroup", b =>
                {
                    b.HasOne("Organizarty.Application.App.DecorationInfos.Entities.DecorationInfo", "DecorationInfo")
                        .WithMany()
                        .HasForeignKey("DecorationInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.Party.Entities.PartyTemplate", "PartyTemplate")
                        .WithMany()
                        .HasForeignKey("PartyTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DecorationInfo");

                    b.Navigation("PartyTemplate");
                });

            modelBuilder.Entity("Organizarty.Application.App.Party.Entities.FoodGroup", b =>
                {
                    b.HasOne("Organizarty.Application.App.Foods.Entities.FoodInfo", "FoodInfo")
                        .WithMany()
                        .HasForeignKey("FoodInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.Party.Entities.PartyTemplate", "PartyTemplate")
                        .WithMany()
                        .HasForeignKey("PartyTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodInfo");

                    b.Navigation("PartyTemplate");
                });

            modelBuilder.Entity("Organizarty.Application.App.Party.Entities.PartyTemplate", b =>
                {
                    b.HasOne("Organizarty.Application.App.Locations.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.Party.Entities.PartyTemplate", "OriginalPartyTemplate")
                        .WithMany()
                        .HasForeignKey("OriginalPartyTemplateId");

                    b.HasOne("Organizarty.Application.App.Users.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("OriginalPartyTemplate");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Organizarty.Application.App.Party.Entities.ServiceGroup", b =>
                {
                    b.HasOne("Organizarty.Application.App.Party.Entities.PartyTemplate", "PartyTemplate")
                        .WithMany()
                        .HasForeignKey("PartyTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.Services.Entities.ServiceInfo", "ServiceInfo")
                        .WithMany()
                        .HasForeignKey("ServiceInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartyTemplate");

                    b.Navigation("ServiceInfo");
                });

            modelBuilder.Entity("Organizarty.Application.App.Schedules.Entities.DecorationOrder", b =>
                {
                    b.HasOne("Organizarty.Application.App.DecorationInfos.Entities.DecorationInfo", "Decoration")
                        .WithMany()
                        .HasForeignKey("DecorationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.Schedules.Entities.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Decoration");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Organizarty.Application.App.Schedules.Entities.FoodOrder", b =>
                {
                    b.HasOne("Organizarty.Application.App.Foods.Entities.FoodInfo", "FoodInfo")
                        .WithMany()
                        .HasForeignKey("FoodInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.Party.Entities.PartyTemplate", "PartyTemplate")
                        .WithMany()
                        .HasForeignKey("PartyTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.Schedules.Entities.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.ThirdParties.Entities.ThirdParty", "ThirdParty")
                        .WithMany()
                        .HasForeignKey("ThirdPartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodInfo");

                    b.Navigation("PartyTemplate");

                    b.Navigation("Schedule");

                    b.Navigation("ThirdParty");
                });

            modelBuilder.Entity("Organizarty.Application.App.Schedules.Entities.Schedule", b =>
                {
                    b.HasOne("Organizarty.Application.App.Locations.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.Party.Entities.PartyTemplate", "Party")
                        .WithMany()
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.Users.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Party");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Organizarty.Application.App.Schedules.Entities.ServiceOrder", b =>
                {
                    b.HasOne("Organizarty.Application.App.Schedules.Entities.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.Services.Entities.ServiceInfo", "ServiceInfo")
                        .WithMany()
                        .HasForeignKey("ServiceInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organizarty.Application.App.ThirdParties.Entities.ThirdParty", "ThirdParty")
                        .WithMany()
                        .HasForeignKey("ThirdPartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("ServiceInfo");

                    b.Navigation("ThirdParty");
                });

            modelBuilder.Entity("Organizarty.Application.App.Services.Entities.ServiceInfo", b =>
                {
                    b.HasOne("Organizarty.Application.App.Services.Entities.ServiceType", "ServiceType")
                        .WithMany("SubServices")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("Organizarty.Application.App.Services.Entities.ServiceType", b =>
                {
                    b.HasOne("Organizarty.Application.App.ThirdParties.Entities.ThirdParty", "ThirdParty")
                        .WithMany()
                        .HasForeignKey("ThirdPartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThirdParty");
                });

            modelBuilder.Entity("Organizarty.Application.App.Users.Entities.UserConfirmation", b =>
                {
                    b.HasOne("Organizarty.Application.App.Users.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Organizarty.Application.App.DecorationTypes.Entities.DecorationType", b =>
                {
                    b.Navigation("Decorations");
                });

            modelBuilder.Entity("Organizarty.Application.App.Foods.Entities.FoodType", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("Organizarty.Application.App.Services.Entities.ServiceType", b =>
                {
                    b.Navigation("SubServices");
                });
#pragma warning restore 612, 618
        }
    }
}
