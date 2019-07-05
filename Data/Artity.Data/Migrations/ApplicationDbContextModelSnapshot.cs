﻿// <auto-generated />
using System;
using Artity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Artity.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Artity.Data.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Artity.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ArtistId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("FirstLogin");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PofilePictureId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PofilePictureId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Artity.Data.Models.Artist", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutMe");

                    b.Property<string>("CategoryId");

                    b.Property<string>("Nikname");

                    b.Property<string>("ProfilePictureId");

                    b.Property<string>("WorkNumber");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProfilePictureId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Artity.Data.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryType");

                    b.Property<string>("Name");

                    b.Property<string>("PictureId");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Artity.Data.Models.Offert", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistId");

                    b.Property<string>("Features");

                    b.Property<string>("Message");

                    b.Property<decimal>("Price");

                    b.Property<int>("Type");

                    b.Property<DateTime>("Еngagement");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Offerts");
                });

            modelBuilder.Entity("Artity.Data.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistId");

                    b.Property<DateTime>("IssuedOn");

                    b.Property<string>("Message");

                    b.Property<int>("Type");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Artity.Data.Models.Performence", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistId");

                    b.Property<string>("Description");

                    b.Property<decimal>("Price");

                    b.Property<double>("Rating");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Performences");
                });

            modelBuilder.Entity("Artity.Data.Models.Picture", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Link");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UploadDate");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Artity.Data.Models.Rating", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistId");

                    b.Property<string>("PerformenceId");

                    b.Property<int>("RatingValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("PerformenceId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Artity.Data.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Artity.Data.Models.Song", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistId");

                    b.Property<string>("Description");

                    b.Property<string>("Link");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UploadDate");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Artity.Data.Models.ApplicationUser", b =>
                {
                    b.HasOne("Artity.Data.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("Artity.Data.Models.Picture", "PofilePicture")
                        .WithMany()
                        .HasForeignKey("PofilePictureId");
                });

            modelBuilder.Entity("Artity.Data.Models.Artist", b =>
                {
                    b.HasOne("Artity.Data.Models.Category", "Category")
                        .WithMany("Artists")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Artity.Data.Models.Picture", "ProfilePicture")
                        .WithMany()
                        .HasForeignKey("ProfilePictureId");
                });

            modelBuilder.Entity("Artity.Data.Models.Category", b =>
                {
                    b.HasOne("Artity.Data.Models.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId");
                });

            modelBuilder.Entity("Artity.Data.Models.Offert", b =>
                {
                    b.HasOne("Artity.Data.Models.Artist", "Artist")
                        .WithMany("Offerts")
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("Artity.Data.Models.Order", b =>
                {
                    b.HasOne("Artity.Data.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("Artity.Data.Models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Artity.Data.Models.Performence", b =>
                {
                    b.HasOne("Artity.Data.Models.Artist", "Artist")
                        .WithMany("Performences")
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("Artity.Data.Models.Rating", b =>
                {
                    b.HasOne("Artity.Data.Models.Artist", "Artist")
                        .WithMany("Ratings")
                        .HasForeignKey("ArtistId");

                    b.HasOne("Artity.Data.Models.Performence")
                        .WithMany("Ratings")
                        .HasForeignKey("PerformenceId");

                    b.HasOne("Artity.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Artity.Data.Models.Song", b =>
                {
                    b.HasOne("Artity.Data.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Artity.Data.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Artity.Data.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Artity.Data.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Artity.Data.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Artity.Data.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Artity.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
