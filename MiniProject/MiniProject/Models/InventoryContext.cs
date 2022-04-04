using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject.Models
{
    class InventoryContext : DbContext
    {
        public InventoryContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =ADITYAJO-VD\\SQL2017; Database = InventoryManagement; User id = sa; password = cybage@123456;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
