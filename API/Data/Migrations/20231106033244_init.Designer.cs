﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(PokeDBContext))]
    [Migration("20231106033244_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BattleMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BattleId")
                        .HasColumnType("int");

                    b.Property<int?>("PokemonMoveId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BattleId");

                    b.HasIndex("PokemonMoveId");

                    b.HasIndex("UserId");

                    b.ToTable("BattleMoves");
                });

            modelBuilder.Entity("Domain.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActivePokemonTrainer1Id")
                        .HasColumnType("int");

                    b.Property<int?>("ActivePokemonTrainer2Id")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("User2Id")
                        .HasColumnType("int");

                    b.Property<int?>("Users")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivePokemonTrainer1Id");

                    b.HasIndex("ActivePokemonTrainer2Id");

                    b.HasIndex("User2Id");

                    b.HasIndex("Users");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("Domain.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<string>("IMG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaknessTypeId")
                        .HasColumnType("int");

                    b.Property<int>("attack")
                        .HasColumnType("int");

                    b.Property<int>("defense")
                        .HasColumnType("int");

                    b.Property<int>("speed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("WeaknessTypeId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("Domain.PokemonMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PokemonTypes")
                        .HasColumnType("int");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PokemonTypes");

                    b.ToTable("PokemonMoves");
                });

            modelBuilder.Entity("Domain.PokemonType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("IMG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("PokemonTypes");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IMG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ls")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ws")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PokemonPokemonMove", b =>
                {
                    b.Property<int>("PokemonMovesId")
                        .HasColumnType("int");

                    b.Property<int>("PokemonsId")
                        .HasColumnType("int");

                    b.HasKey("PokemonMovesId", "PokemonsId");

                    b.HasIndex("PokemonsId");

                    b.ToTable("PokemonPokemonMove");
                });

            modelBuilder.Entity("PokemonUser", b =>
                {
                    b.Property<int>("PokemonCollectionId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("PokemonCollectionId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("PokemonUser");
                });

            modelBuilder.Entity("BattleMove", b =>
                {
                    b.HasOne("Domain.Battle", "Battle")
                        .WithMany()
                        .HasForeignKey("BattleId");

                    b.HasOne("Domain.PokemonMove", "MoveUsed")
                        .WithMany()
                        .HasForeignKey("PokemonMoveId");

                    b.HasOne("Domain.Pokemon", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Battle");

                    b.Navigation("MoveUsed");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Battle", b =>
                {
                    b.HasOne("Domain.Pokemon", "ActivePokemonTrainer1")
                        .WithMany()
                        .HasForeignKey("ActivePokemonTrainer1Id");

                    b.HasOne("Domain.Pokemon", "ActivePokemonTrainer2")
                        .WithMany()
                        .HasForeignKey("ActivePokemonTrainer2Id");

                    b.HasOne("Domain.User", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id");

                    b.HasOne("Domain.User", "User1")
                        .WithMany()
                        .HasForeignKey("Users");

                    b.Navigation("ActivePokemonTrainer1");

                    b.Navigation("ActivePokemonTrainer2");

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("Domain.Pokemon", b =>
                {
                    b.HasOne("Domain.PokemonType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.HasOne("Domain.PokemonType", "WeaknessType")
                        .WithMany()
                        .HasForeignKey("WeaknessTypeId");

                    b.Navigation("Type");

                    b.Navigation("WeaknessType");
                });

            modelBuilder.Entity("Domain.PokemonMove", b =>
                {
                    b.HasOne("Domain.PokemonType", "Type")
                        .WithMany()
                        .HasForeignKey("PokemonTypes");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("PokemonPokemonMove", b =>
                {
                    b.HasOne("Domain.PokemonMove", null)
                        .WithMany()
                        .HasForeignKey("PokemonMovesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonUser", b =>
                {
                    b.HasOne("Domain.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}