using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restore.Core.Data.Configuration;
using Restore.Core.Models;

namespace Restore.Core.Data
{
    public class RestoreContext: DbContext
    {
        public RestoreContext()
        {
            
        }
        public RestoreContext(DbContextOptions<RestoreContext> options) : base(options)
        {  
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions) =>
            dbContextOptions.UseSqlServer("Data Source=localhost,1433;Database=Restore;User Id=sa;Password=P@ssw0rd!;");

        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// override default model creation logic
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            new Seed(modelBuilder).Initialize();
        }
        
    }
}