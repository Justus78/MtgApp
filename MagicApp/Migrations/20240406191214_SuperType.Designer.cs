﻿// <auto-generated />
using System;
using MagicApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicApp.Migrations
{
    [DbContext(typeof(CardContext))]
    [Migration("20240406191214_SuperType")]
    partial class SuperType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicApp.Models.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardId"));

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManaCost")
                        .HasColumnType("int");

                    b.Property<int?>("Power")
                        .HasColumnType("int");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Toughness")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            CardId = 1,
                            CardName = "Lightning Bolt",
                            ManaCost = 1,
                            Rarity = "Rare"
                        },
                        new
                        {
                            CardId = 2,
                            CardName = "Time Walk",
                            ManaCost = 2,
                            Rarity = "Rare"
                        },
                        new
                        {
                            CardId = 3,
                            CardName = "Ancestral Recall",
                            ManaCost = 1,
                            Rarity = "Rare"
                        },
                        new
                        {
                            CardId = 4,
                            CardName = "Golos, Tireless Pilgram",
                            ManaCost = 5,
                            Power = 3,
                            Rarity = "Mythic",
                            Toughness = 5
                        });
                });

            modelBuilder.Entity("MagicApp.Models.CardColor", b =>
                {
                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.HasKey("CardId", "ColorId");

                    b.HasIndex("ColorId");

                    b.ToTable("CardColors");

                    b.HasData(
                        new
                        {
                            CardId = 1,
                            ColorId = 1
                        },
                        new
                        {
                            CardId = 2,
                            ColorId = 2
                        },
                        new
                        {
                            CardId = 3,
                            ColorId = 2
                        },
                        new
                        {
                            CardId = 4,
                            ColorId = 1
                        },
                        new
                        {
                            CardId = 4,
                            ColorId = 2
                        },
                        new
                        {
                            CardId = 4,
                            ColorId = 3
                        },
                        new
                        {
                            CardId = 4,
                            ColorId = 4
                        },
                        new
                        {
                            CardId = 4,
                            ColorId = 5
                        });
                });

            modelBuilder.Entity("MagicApp.Models.CardSuperType", b =>
                {
                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("SuperTypeId")
                        .HasColumnType("int");

                    b.HasKey("CardId", "SuperTypeId");

                    b.HasIndex("SuperTypeId");

                    b.ToTable("CardSuperTypes");

                    b.HasData(
                        new
                        {
                            CardId = 4,
                            SuperTypeId = 2
                        });
                });

            modelBuilder.Entity("MagicApp.Models.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"));

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColorId");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            ColorId = 1,
                            ColorName = "red"
                        },
                        new
                        {
                            ColorId = 2,
                            ColorName = "blue"
                        },
                        new
                        {
                            ColorId = 3,
                            ColorName = "green"
                        },
                        new
                        {
                            ColorId = 4,
                            ColorName = "white"
                        },
                        new
                        {
                            ColorId = 5,
                            ColorName = "black"
                        },
                        new
                        {
                            ColorId = 6,
                            ColorName = "colorless"
                        });
                });

            modelBuilder.Entity("MagicApp.Models.SuperType", b =>
                {
                    b.Property<int>("SuperTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuperTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuperTypeId");

                    b.ToTable("SuperTypes");

                    b.HasData(
                        new
                        {
                            SuperTypeId = 1,
                            Name = "Basic"
                        },
                        new
                        {
                            SuperTypeId = 2,
                            Name = "Legendary"
                        },
                        new
                        {
                            SuperTypeId = 3,
                            Name = "Snow"
                        },
                        new
                        {
                            SuperTypeId = 4,
                            Name = "World"
                        });
                });

            modelBuilder.Entity("MagicApp.Models.CardColor", b =>
                {
                    b.HasOne("MagicApp.Models.Card", null)
                        .WithMany("CardColors")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagicApp.Models.Color", null)
                        .WithMany("CardCOlors")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MagicApp.Models.CardSuperType", b =>
                {
                    b.HasOne("MagicApp.Models.Card", null)
                        .WithMany("CardSuperTypes")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagicApp.Models.SuperType", null)
                        .WithMany("SuperTypes")
                        .HasForeignKey("SuperTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MagicApp.Models.Card", b =>
                {
                    b.Navigation("CardColors");

                    b.Navigation("CardSuperTypes");
                });

            modelBuilder.Entity("MagicApp.Models.Color", b =>
                {
                    b.Navigation("CardCOlors");
                });

            modelBuilder.Entity("MagicApp.Models.SuperType", b =>
                {
                    b.Navigation("SuperTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
