﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MfcContext))]
    [Migration("20240511101749_onPublic")]
    partial class onPublic
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("OnPublic")
                        .HasColumnType("boolean");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Domain.Entities.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.Entities.Users.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SNILS")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "98362ef5-8879-4162-b16f-cf7096842a3c",
                            Email = "admin@example.com",
                            EmailConfirmed = false,
                            Gender = "Мужской",
                            INN = "7777065424",
                            LockoutEnabled = false,
                            Name = "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}",
                            NormalizedEmail = "ADMIN@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN",
                            Passport = "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}",
                            PasswordHash = "AQAAAAIAAYagAAAAEDDtiykq2sNXBhv+4gxsFJ6/pEmSJ3lCZoPcl7oC6VXUCLdLL/bK7OByA5Om8kjkVw==",
                            PhoneNumberConfirmed = false,
                            SNILS = "375232753",
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "bd376a8f-9eab-4bb9-9fca-40b01540f446",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "bd376a8f-9eab-4bb9-9fca-40b01540f447",
                            Name = "student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = "bd376a8f-9eab-4bb9-9fca-40b01540f448",
                            Name = "employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                            RoleId = "bd376a8f-9eab-4bb9-9fca-40b01540f446"
                        },
                        new
                        {
                            UserId = "d28be9c0-aa65-4af8-bd17-10bd9344e587",
                            RoleId = "bd376a8f-9eab-4bb9-9fca-40b01540f447"
                        },
                        new
                        {
                            UserId = "d28be9c0-aa65-4af8-1d17-10bd9344e588",
                            RoleId = "bd376a8f-9eab-4bb9-9fca-40b01540f447"
                        },
                        new
                        {
                            UserId = "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                            RoleId = "bd376a8f-9eab-4bb9-9fca-40b01540f448"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Users.EmployeeUser", b =>
                {
                    b.HasBaseType("Domain.Entities.Users.AppUser");

                    b.Property<string>("Institute")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("EmployeeUser");

                    b.HasData(
                        new
                        {
                            Id = "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ad61be68-7efc-4011-90cd-67680a640cf5",
                            Email = "employee@example.com",
                            EmailConfirmed = false,
                            Gender = "Мужской",
                            INN = "7777065424",
                            LockoutEnabled = false,
                            Name = "{\"First\":\"\\u0420\\u0430\\u0431\\u043E\\u0442\\u043D\\u0438\\u043A\",\"Second\":\"\\u041C\\u0418\\u0418\\u0422\\u041E\\u0412\",\"Middle\":\"\\u0418\\u043D\\u0441\\u0442\\u0438\\u0442\\u0443\\u0442\\u043E\\u0432\\u0438\\u0447\"}",
                            NormalizedEmail = "EMPLOYEE@EXAMPLE.COM",
                            NormalizedUserName = "EMPLOYEE",
                            Passport = "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}",
                            PasswordHash = "AQAAAAIAAYagAAAAEDpRyfHqxPhRfDJTwmJjz70LuCkmBzQS1dVUH6SwVmleEqugKr5VCQVVNCgCpF4RUA==",
                            PhoneNumberConfirmed = false,
                            SNILS = "375232753",
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "employee",
                            Institute = "",
                            Post = "Доцент"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Users.StudentUser", b =>
                {
                    b.HasBaseType("Domain.Entities.Users.AppUser");

                    b.Property<DateOnly>("DateOfEnrollment")
                        .HasColumnType("date");

                    b.Property<string>("DirectionOfStudy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FormOfStudy")
                        .HasColumnType("integer");

                    b.Property<int>("GapYearsCount")
                        .HasColumnType("integer");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServiceNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("StudentUser");

                    b.HasData(
                        new
                        {
                            Id = "d28be9c0-aa65-4af8-bd17-10bd9344e587",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "baab30ef-65d3-4187-ac92-61003612999d",
                            Email = "Dmitry@example.com",
                            EmailConfirmed = false,
                            Gender = "Мужской",
                            INN = "7777065424",
                            LockoutEnabled = false,
                            Name = "{\"First\":\"\\u0414\\u043C\\u0438\\u0442\\u0440\\u0438\\u0439\",\"Second\":\"\\u0411\\u043E\\u043B\\u0442\\u0430\\u0447\\u0435\\u0432\",\"Middle\":\"\\u041C\\u0438\\u0445\\u0430\\u0439\\u043B\\u043E\\u0432\\u0438\\u0447\"}",
                            NormalizedEmail = "DMITRY@EXAMPLE.COM",
                            NormalizedUserName = "DMITRY@EXAMPLE.COM",
                            Passport = "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}",
                            PasswordHash = "AQAAAAIAAYagAAAAELsSt92To8PIwy7jmTVi5uuBMl9x6ehKlzv4pVRhAzYCPipONeRU/rTA6pMO+48chw==",
                            PhoneNumberConfirmed = false,
                            SNILS = "375232753",
                            SecurityStamp = "69b2ed9b-f9f8-4d3c-896a-92fcc8ee65b6",
                            TwoFactorEnabled = false,
                            UserName = "Dmitry",
                            DateOfEnrollment = new DateOnly(2020, 8, 12),
                            DirectionOfStudy = "09.03.01",
                            FormOfStudy = 0,
                            GapYearsCount = 0,
                            Group = "УВП-411",
                            ServiceNumber = "12345678"
                        },
                        new
                        {
                            Id = "d28be9c0-aa65-4af8-1d17-10bd9344e588",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ba8311c4-a9b8-470c-a2fe-658e34bb5be6",
                            Email = "Nastya@example.com",
                            EmailConfirmed = false,
                            Gender = "Мужской",
                            INN = "7777065424",
                            LockoutEnabled = false,
                            Name = "{\"First\":\"\\u0410\\u043D\\u0430\\u0441\\u0442\\u0430\\u0441\\u0438\\u044F\",\"Second\":\"\\u041A\\u043E\\u043D\\u0441\\u0442\\u0430\\u043D\\u0442\\u0438\\u043D\\u043E\\u0432\\u0430\",\"Middle\":\"\\u0412\\u0438\\u0442\\u0430\\u043B\\u044C\\u0435\\u0432\\u043D\\u0430\"}",
                            NormalizedEmail = "NASTYA@EXAMPLE.COM",
                            NormalizedUserName = "NASTYA@EXAMPLE.COM",
                            Passport = "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}",
                            PasswordHash = "AQAAAAIAAYagAAAAEIITTFUrPKxS3NufmXRkbzGIBfFjgbyQyxfv62FxEuYowqZ9fDOxryw8jxmm5znPsQ==",
                            PhoneNumberConfirmed = false,
                            SNILS = "375232753",
                            SecurityStamp = "a1eb9086-b499-47ef-ab4f-036a3b25f44a",
                            TwoFactorEnabled = false,
                            UserName = "Nastya",
                            DateOfEnrollment = new DateOnly(2020, 8, 12),
                            DirectionOfStudy = "09.03.01",
                            FormOfStudy = 0,
                            GapYearsCount = 0,
                            Group = "УВП-411",
                            ServiceNumber = "12345678"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
