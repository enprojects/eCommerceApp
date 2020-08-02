﻿// <auto-generated />
using System;
using EntityFrameCoreReharsearsal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameCoreReharsearsal.PepoleMigration
{
    [DbContext(typeof(PepoleContext))]
    partial class PepoleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid?>("FK_Adresses_Person")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("FK_Adresses_Person");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("EntityFrameCoreReharsearsal.Model.PepoleModel.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FK_EmailAddresses_Person")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FK_EmailAddresses_Person");

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
                    b.HasOne("EntityFrameCoreReharsearsal.Model.PepoleModel.Person", "Person")
                        .WithMany("Adresses")
                        .HasForeignKey("FK_Adresses_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameCoreReharsearsal.Model.PepoleModel.Email", b =>
                {
                    b.HasOne("EntityFrameCoreReharsearsal.Model.PepoleModel.Person", "Person")
                        .WithMany("Emails")
                        .HasForeignKey("FK_EmailAddresses_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}