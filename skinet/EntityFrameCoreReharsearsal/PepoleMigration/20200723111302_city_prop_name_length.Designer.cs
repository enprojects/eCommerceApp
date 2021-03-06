﻿// <auto-generated />
using System;
using EntityFrameCoreReharsearsal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameCoreReharsearsal.PepoleMigration
{
    [DbContext(typeof(PepoleContext))]
    [Migration("20200723111302_city_prop_name_length")]
    partial class city_prop_name_length
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameCoreReharsearsal.Model.PepoleModel.Adresses", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("EntityFrameCoreReharsearsal.Model.PepoleModel.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("EntityFrameCoreReharsearsal.Model.PepoleModel.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("EntityFrameCoreReharsearsal.Model.PepoleModel.Adresses", b =>
                {
                    b.HasOne("EntityFrameCoreReharsearsal.Model.PepoleModel.Person", null)
                        .WithMany("Adresses")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("EntityFrameCoreReharsearsal.Model.PepoleModel.Email", b =>
                {
                    b.HasOne("EntityFrameCoreReharsearsal.Model.PepoleModel.Person", null)
                        .WithMany("Emails")
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
