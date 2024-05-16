﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneToManyDemo.Data;

#nullable disable

namespace OneToManyDemo.Migrations
{
    [DbContext(typeof(BoekenDbContext))]
    partial class BoekenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OneToManyDemo.Models.Auteur", b =>
                {
                    b.Property<int>("AuteurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuteurId"));

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AuteurId");

                    b.ToTable("Auteurs");

                    b.HasData(
                        new
                        {
                            AuteurId = 1,
                            Naam = "J.K. Rowling"
                        },
                        new
                        {
                            AuteurId = 2,
                            Naam = "Stephen King"
                        },
                        new
                        {
                            AuteurId = 3,
                            Naam = "J.R.R. Tolkien"
                        },
                        new
                        {
                            AuteurId = 4,
                            Naam = "Dan Brown"
                        });
                });

            modelBuilder.Entity("OneToManyDemo.Models.Boek", b =>
                {
                    b.Property<int>("BoekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BoekId"));

                    b.Property<int>("AuteurId")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BoekId");

                    b.HasIndex("AuteurId");

                    b.ToTable("Boeks");

                    b.HasData(
                        new
                        {
                            BoekId = 1,
                            AuteurId = 1,
                            Titel = "De avonturen van Code 1"
                        },
                        new
                        {
                            BoekId = 2,
                            AuteurId = 2,
                            Titel = "De avonturen van Code 2"
                        },
                        new
                        {
                            BoekId = 3,
                            AuteurId = 1,
                            Titel = "De avonturen van Code 3"
                        },
                        new
                        {
                            BoekId = 4,
                            AuteurId = 3,
                            Titel = "De avonturen van Code 4"
                        },
                        new
                        {
                            BoekId = 5,
                            AuteurId = 4,
                            Titel = "De avonturen van Code 5"
                        },
                        new
                        {
                            BoekId = 6,
                            AuteurId = 2,
                            Titel = "De avonturen van Code 6"
                        },
                        new
                        {
                            BoekId = 7,
                            AuteurId = 4,
                            Titel = "De avonturen van Code 7"
                        },
                        new
                        {
                            BoekId = 8,
                            AuteurId = 3,
                            Titel = "De avonturen van Code 8"
                        });
                });

            modelBuilder.Entity("OneToManyDemo.Models.Boek", b =>
                {
                    b.HasOne("OneToManyDemo.Models.Auteur", "Auteur")
                        .WithMany("Boeken")
                        .HasForeignKey("AuteurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Auteur");
                });

            modelBuilder.Entity("OneToManyDemo.Models.Auteur", b =>
                {
                    b.Navigation("Boeken");
                });
#pragma warning restore 612, 618
        }
    }
}
