using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace work_01.Models
{
    public class ExpenseDbContext:DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Categories>().HasIndex(c=>c.CategoryName).IsUnique();
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Expenditures> Expenditures { get; set; }
    }
}
