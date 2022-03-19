using SoftwareInstallationDatabaseImplement.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace SoftwareInstallationDatabaseImplement
{
    public class SoftwareInstallationDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-0K83PAS6\SQLEXPRESS;Initial Catalog=SoftwareInstallationDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageComponent> PackageComponents { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
