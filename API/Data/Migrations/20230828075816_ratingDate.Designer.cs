﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230828075816_ratingDate")]
    partial class ratingDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("API.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Premiere")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut et consectetur velit. Donec ut orci eget massa ullamcorper vestibulum. Etiam non interdum est, vel lobortis justo. Vivamus ligula libero, hendrerit aliquet justo vel, pharetra fermentum felis.",
                            Duration = 90,
                            Genre = "Family",
                            ImgUrl = "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161775/shrek_q7kypt.jpg",
                            Premiere = new DateTime(2004, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Shrek"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Mauris at tristique quam. Vestibulum at augue euismod, consectetur tortor in, ultrices mi. Nulla maximus aliquam orci quis commodo. Nam tristique neque a metus egestas mollis a placerat lectus. Morbi felis urna, fringilla ut ligula sed, sagittis semper leo.",
                            Duration = 175,
                            Genre = "Crime",
                            ImgUrl = "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161764/theGodfather_isikq1.jpg",
                            Premiere = new DateTime(1972, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Godfather"
                        },
                        new
                        {
                            Id = 3,
                            Description = "onec nisl nunc, fringilla eu tincidunt in, lobortis id orci. Proin sem libero, condimentum id erat ut, fringilla hendrerit justo. Proin a imperdiet erat, sed convallis quam. Integer sed tellus purus. Ut tempor mauris eu odio lobortis, in maximus velit mattis. Nam vel mi id risus malesuada porta in id lacus.",
                            Duration = 187,
                            Genre = "Crime",
                            ImgUrl = "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691162620/babrie_xe7yii.jpg",
                            Premiere = new DateTime(1994, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pulp fiction"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Roin sit amet leo sed ante hendrerit fermentum sed et mi. Nulla facilisi. Morbi orci est, tristique non pharetra ac, tincidunt quis ligula. Vestibulum pretium sodales tempus. Sed sollicitudin pharetra ante, sit amet pharetra neque tristique tincidunt. ",
                            Duration = 159,
                            Genre = "Action",
                            ImgUrl = "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161775/shrek_q7kypt.jpg",
                            Premiere = new DateTime(2010, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Inception"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Aliquam consectetur vehicula velit eget interdum. Donec dui libero, malesuada nec efficitur in, convallis vitae lorem. Vivamus ac pulvinar enim, pharetra finibus massa.",
                            Duration = 149,
                            Genre = "Action",
                            ImgUrl = "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161764/theGodfather_isikq1.jpg",
                            Premiere = new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-man: Across the spider verse"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Aenean ornare tortor nec odio rhoncus dignissim. Aliquam orci magna, semper sed pulvinar non, dictum vitae turpis. Suspendisse bibendum magna ac ante vehicula lacinia. Nulla congue libero auctor tempus lobortis. ",
                            Duration = 180,
                            Genre = "History",
                            ImgUrl = "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691162620/babrie_xe7yii.jpg",
                            Premiere = new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Oppenheimer"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Aliquam et ornare libero, sed fermentum turpis. Praesent fermentum felis vitae consectetur maximus. Maecenas eu eleifend neque. Sed lorem lorem, commodo quis scelerisque feugiat, faucibus quis justo.",
                            Duration = 150,
                            Genre = "Action",
                            ImgUrl = "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161775/shrek_q7kypt.jpg",
                            Premiere = new DateTime(2018, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avengers: infinity war"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Curabitur luctus massa ligula, vitae vestibulum leo aliquam eu. Etiam a felis semper, mollis metus eget, sollicitudin ante. Cras ultricies arcu eu arcu scelerisque consectetur.",
                            Duration = 110,
                            Genre = "Animation",
                            ImgUrl = "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161764/theGodfather_isikq1.jpg",
                            Premiere = new DateTime(2016, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Your name"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Sed ligula mauris, congue ac ex in, sagittis ultrices ante. Proin sagittis, ante sed consequat ornare, urna neque porttitor magna, ut posuere ante ligula nec libero. Maecenas lacinia ornare massa, at luctus sapien imperdiet nec.",
                            Duration = 160,
                            Genre = "Action",
                            ImgUrl = "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691162620/babrie_xe7yii.jpg",
                            Premiere = new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Matrix"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Aliquam quis gravida ipsum, ac sollicitudin orci. Ut iaculis mattis tincidunt. Duis quam risus, dignissim et ex in, vestibulum blandit erat. Nam vulputate est et iaculis pretium. Cras vitae purus enim. Integer ac condimentum turpis.",
                            Duration = 150,
                            Genre = "Drama",
                            ImgUrl = "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161775/shrek_q7kypt.jpg",
                            Premiere = new DateTime(1999, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Fight club"
                        });
                });

            modelBuilder.Entity("API.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("API.Entities.UserMovies", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("UserMovies");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("API.Entities.Comment", b =>
                {
                    b.HasOne("API.Entities.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.Rating", b =>
                {
                    b.HasOne("API.Entities.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.UserMovies", b =>
                {
                    b.HasOne("API.Entities.Movie", "Movie")
                        .WithMany("LikedByUsers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.User", "User")
                        .WithMany("LikedMovies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.Movie", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("LikedByUsers");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("LikedMovies");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
