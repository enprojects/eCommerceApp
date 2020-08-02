using EntityFrameCoreReharsearsal.Model.PepoleModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameCoreReharsearsal
{
    public class PepoleContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PepoleAppData");
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<Person> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(p => p.Id).ValueGeneratedOnAdd();
           
            modelBuilder.Entity<Person>().HasMany(a => a.Adresses)
                .WithOne(x => x.Person)
                 .HasForeignKey("FK_Adresses_Person").IsRequired();

           modelBuilder.Entity<Email>().HasKey(x => x.Id);
           
            modelBuilder.Entity<Person>().HasMany(a => a.Emails)
                 .WithOne(x => x.Person)
                  .HasForeignKey("FK_EmailAddresses_Person").IsRequired();

            modelBuilder.Entity<Adresses>().HasKey(x => x.Id);
            modelBuilder.Entity<Adresses>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Adresses>().Property(x => x.City).HasMaxLength(40);
            modelBuilder.Entity<Adresses>().Property(p => p.ZipCode)
                .HasColumnType("varchar(10)");
        }
    }
}
