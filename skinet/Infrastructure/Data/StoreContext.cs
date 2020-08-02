using Core.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Reflection;
using Infrastructure.Data;
using System;

namespace API.Data
{
    public class TraceLoggerProvider : ILoggerProvider

    {
    
        public ILogger CreateLogger(string categoryName) => new TraceLogger("DbContextLogger");
        public void Dispose() { }
    }

    public class StoreContext : DbContext
    {
        public  readonly ILoggerFactory _loggerFactory = new LoggerFactory();
        public readonly string _connection;
        public StoreContext(Func<DbContextOptions> action) 
            :base(action())
        {
            loggerRegistrer();
        }

        public StoreContext(DbContextOptions options) 
            : base(options)
        {
            loggerRegistrer();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly); 
       
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        
        {
            //   base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
           
            if (!string.IsNullOrWhiteSpace(_connection))
                optionsBuilder.UseSqlServer(_connection);


        }

        private void loggerRegistrer()
        {
            _loggerFactory.AddProvider(new TraceLoggerProvider());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }       
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
