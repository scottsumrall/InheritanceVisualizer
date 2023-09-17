﻿// <auto-generated />
using System;
using AbstractionOrganizer.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AbstractionOrganizer.Api.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230917202648_variableTypeMigration")]
    partial class variableTypeMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AbstractionOrganizer.Models.ClassModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessModifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassModifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentClassModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentClassModelId");

                    b.ToTable("ClassHeaders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessModifier = "Public",
                            ClassModifier = "Concrete",
                            Name = "class1"
                        },
                        new
                        {
                            Id = 2,
                            AccessModifier = "Protected",
                            ClassModifier = "Concrete",
                            Name = "class2"
                        },
                        new
                        {
                            Id = 3,
                            AccessModifier = "Protected",
                            ClassModifier = "Abstract",
                            Name = "class3"
                        },
                        new
                        {
                            Id = 4,
                            AccessModifier = "Private",
                            ClassModifier = "Static",
                            Name = "class4"
                        });
                });

            modelBuilder.Entity("AbstractionOrganizer.Models.MethodModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessModifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassModelId")
                        .HasColumnType("int");

                    b.Property<bool>("GetsInherited")
                        .HasColumnType("bit");

                    b.Property<string>("MethodModifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassModelId");

                    b.ToTable("MethodModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessModifier = "Public",
                            ClassModelId = 1,
                            GetsInherited = true,
                            MethodModifier = "Static",
                            Name = "testMethod1"
                        });
                });

            modelBuilder.Entity("AbstractionOrganizer.Models.VariableModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessModifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassModelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsStatic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassModelId");

                    b.ToTable("VariableModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessModifier = "Public",
                            ClassModelId = 1,
                            IsStatic = false,
                            Name = "testVar1",
                            Type = "Int"
                        },
                        new
                        {
                            Id = 2,
                            AccessModifier = "Private",
                            ClassModelId = 1,
                            IsStatic = false,
                            Name = "testVar2",
                            Type = "String"
                        });
                });

            modelBuilder.Entity("AbstractionOrganizer.Models.ClassModel", b =>
                {
                    b.HasOne("AbstractionOrganizer.Models.ClassModel", "ParentClassModel")
                        .WithMany("ChildClassModels")
                        .HasForeignKey("ParentClassModelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentClassModel");
                });

            modelBuilder.Entity("AbstractionOrganizer.Models.MethodModel", b =>
                {
                    b.HasOne("AbstractionOrganizer.Models.ClassModel", "ClassModel")
                        .WithMany("MethodModels")
                        .HasForeignKey("ClassModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassModel");
                });

            modelBuilder.Entity("AbstractionOrganizer.Models.VariableModel", b =>
                {
                    b.HasOne("AbstractionOrganizer.Models.ClassModel", "ClassModel")
                        .WithMany("VariableModels")
                        .HasForeignKey("ClassModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassModel");
                });

            modelBuilder.Entity("AbstractionOrganizer.Models.ClassModel", b =>
                {
                    b.Navigation("ChildClassModels");

                    b.Navigation("MethodModels");

                    b.Navigation("VariableModels");
                });
#pragma warning restore 612, 618
        }
    }
}
