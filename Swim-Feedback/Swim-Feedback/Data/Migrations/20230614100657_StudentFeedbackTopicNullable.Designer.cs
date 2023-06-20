﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Swim_Feedback.Data;

#nullable disable

namespace Swim_Feedback.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230614100657_StudentFeedbackTopicNullable")]
    partial class StudentFeedbackTopicNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Swim_Feedback.Data.Accessory", b =>
                {
                    b.Property<long>("AccessoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AccessoryId"), 1L, 1);

                    b.Property<int>("AccessoryType")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccessoryId");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("Swim_Feedback.Data.Account", b =>
                {
                    b.Property<long>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AccountId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Swim_Feedback.Data.Avatar", b =>
                {
                    b.Property<long>("AvatarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AvatarId"), 1L, 1);

                    b.Property<long>("BackgroundAccessoryId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EyesAccessoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("EyesId")
                        .HasColumnType("bigint");

                    b.Property<long>("FaceFormId")
                        .HasColumnType("bigint");

                    b.Property<long?>("HairAccessoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("HairId")
                        .HasColumnType("bigint");

                    b.Property<long?>("MouthAccessoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("MouthId")
                        .HasColumnType("bigint");

                    b.Property<long?>("NeckAccessoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("SkinId")
                        .HasColumnType("bigint");

                    b.HasKey("AvatarId");

                    b.HasIndex("BackgroundAccessoryId");

                    b.HasIndex("EyesAccessoryId");

                    b.HasIndex("EyesId");

                    b.HasIndex("FaceFormId");

                    b.HasIndex("HairAccessoryId");

                    b.HasIndex("HairId");

                    b.HasIndex("MouthAccessoryId");

                    b.HasIndex("MouthId");

                    b.HasIndex("NeckAccessoryId");

                    b.HasIndex("SkinId");

                    b.ToTable("Avatars");
                });

            modelBuilder.Entity("Swim_Feedback.Data.AvatarAccessory", b =>
                {
                    b.Property<long>("AvatarId")
                        .HasColumnType("bigint");

                    b.Property<long>("AccessoryId")
                        .HasColumnType("bigint");

                    b.HasKey("AvatarId", "AccessoryId");

                    b.HasIndex("AccessoryId");

                    b.ToTable("AvatarAccessories");
                });

            modelBuilder.Entity("Swim_Feedback.Data.BodyPart", b =>
                {
                    b.Property<long>("BodyPartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BodyPartId"), 1L, 1);

                    b.Property<int>("BodyPartType")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BodyPartId");

                    b.ToTable("BodyParts");
                });

            modelBuilder.Entity("Swim_Feedback.Data.Example", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Examples");
                });

            modelBuilder.Entity("Swim_Feedback.Data.Student", b =>
                {
                    b.Property<long>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("StudentId"), 1L, 1);

                    b.Property<long?>("AvatarId")
                        .HasColumnType("bigint");

                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<long?>("StudentImageId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SwimClassId")
                        .HasColumnType("bigint");

                    b.HasKey("StudentId");

                    b.HasIndex("AvatarId");

                    b.HasIndex("StudentImageId");

                    b.HasIndex("SwimClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Swim_Feedback.Data.StudentFeedback", b =>
                {
                    b.Property<long>("StudentFeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("StudentFeedbackId"), 1L, 1);

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentFeedbackId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentFeedbacks");
                });

            modelBuilder.Entity("Swim_Feedback.Data.StudentImage", b =>
                {
                    b.Property<long>("StudentImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("StudentImageId"), 1L, 1);

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("StudentImageId");

                    b.ToTable("StudentImages");
                });

            modelBuilder.Entity("Swim_Feedback.Data.SwimClass", b =>
                {
                    b.Property<long>("SwimClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SwimClassId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SwimClassId");

                    b.ToTable("SwimClasses");
                });

            modelBuilder.Entity("Swim_Feedback.Data.TeacherFeedback", b =>
                {
                    b.Property<long>("TeacherFeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TeacherFeedbackId"), 1L, 1);

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SwimClassId")
                        .HasColumnType("bigint");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherFeedbackId");

                    b.HasIndex("AccountId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SwimClassId");

                    b.ToTable("TeacherFeedbacks");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Swim_Feedback.Data.Avatar", b =>
                {
                    b.HasOne("Swim_Feedback.Data.Accessory", "BackgroundAccessory")
                        .WithMany()
                        .HasForeignKey("BackgroundAccessoryId")
                        .IsRequired();

                    b.HasOne("Swim_Feedback.Data.Accessory", "EyesAccessory")
                        .WithMany()
                        .HasForeignKey("EyesAccessoryId");

                    b.HasOne("Swim_Feedback.Data.BodyPart", "Eyes")
                        .WithMany()
                        .HasForeignKey("EyesId")
                        .IsRequired();

                    b.HasOne("Swim_Feedback.Data.BodyPart", "FaceForm")
                        .WithMany()
                        .HasForeignKey("FaceFormId")
                        .IsRequired();

                    b.HasOne("Swim_Feedback.Data.Accessory", "HairAccessory")
                        .WithMany()
                        .HasForeignKey("HairAccessoryId");

                    b.HasOne("Swim_Feedback.Data.BodyPart", "Hair")
                        .WithMany()
                        .HasForeignKey("HairId")
                        .IsRequired();

                    b.HasOne("Swim_Feedback.Data.Accessory", "MouthAccessory")
                        .WithMany()
                        .HasForeignKey("MouthAccessoryId");

                    b.HasOne("Swim_Feedback.Data.BodyPart", "Mouth")
                        .WithMany()
                        .HasForeignKey("MouthId")
                        .IsRequired();

                    b.HasOne("Swim_Feedback.Data.Accessory", "NeckAccessory")
                        .WithMany()
                        .HasForeignKey("NeckAccessoryId");

                    b.HasOne("Swim_Feedback.Data.BodyPart", "Skin")
                        .WithMany()
                        .HasForeignKey("SkinId")
                        .IsRequired();

                    b.Navigation("BackgroundAccessory");

                    b.Navigation("Eyes");

                    b.Navigation("EyesAccessory");

                    b.Navigation("FaceForm");

                    b.Navigation("Hair");

                    b.Navigation("HairAccessory");

                    b.Navigation("Mouth");

                    b.Navigation("MouthAccessory");

                    b.Navigation("NeckAccessory");

                    b.Navigation("Skin");
                });

            modelBuilder.Entity("Swim_Feedback.Data.AvatarAccessory", b =>
                {
                    b.HasOne("Swim_Feedback.Data.Accessory", "Accessory")
                        .WithMany("AvatarAccessories")
                        .HasForeignKey("AccessoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Swim_Feedback.Data.Avatar", "Avatar")
                        .WithMany("AvatarAccessories")
                        .HasForeignKey("AvatarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accessory");

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("Swim_Feedback.Data.Student", b =>
                {
                    b.HasOne("Swim_Feedback.Data.Avatar", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");

                    b.HasOne("Swim_Feedback.Data.StudentImage", "StudentImage")
                        .WithMany()
                        .HasForeignKey("StudentImageId");

                    b.HasOne("Swim_Feedback.Data.SwimClass", "SwimClass")
                        .WithMany()
                        .HasForeignKey("SwimClassId");

                    b.Navigation("Avatar");

                    b.Navigation("StudentImage");

                    b.Navigation("SwimClass");
                });

            modelBuilder.Entity("Swim_Feedback.Data.StudentFeedback", b =>
                {
                    b.HasOne("Swim_Feedback.Data.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Swim_Feedback.Data.TeacherFeedback", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("Swim_Feedback.Data.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("Swim_Feedback.Data.SwimClass", "SwimClass")
                        .WithMany()
                        .HasForeignKey("SwimClassId");

                    b.Navigation("Account");

                    b.Navigation("Student");

                    b.Navigation("SwimClass");
                });

            modelBuilder.Entity("Swim_Feedback.Data.Accessory", b =>
                {
                    b.Navigation("AvatarAccessories");
                });

            modelBuilder.Entity("Swim_Feedback.Data.Avatar", b =>
                {
                    b.Navigation("AvatarAccessories");
                });
#pragma warning restore 612, 618
        }
    }
}
