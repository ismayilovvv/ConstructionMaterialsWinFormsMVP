using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.EntityFramework
{
    public class QaxMmcDbContext : DbContext
    {
        public QaxMmcDbContext() : base("name=LibraryDb") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sale = modelBuilder.Entity<Sale>();
            sale.HasKey(s => s.Id);
            sale.Property(s => s.saleDate).IsRequired();
            sale.Property(s => s.sum).IsRequired();
            sale.Property(s => s.Ad).IsRequired();
            sale.Property(s => s.En);
            sale.Property(s => s.Hundurluk);
            sale.Property(s => s.Uzunluq);
            sale.Property(s => s.Miqdar);
            sale.Property(s => s.Kub);
            sale.Property(s => s.Kvadrat);
            sale.Property(s => s.Nomre);
            sale.Property(s => s.Nov);
            sale.ToTable("Sale_Table");
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<ConstructionMaterial> ConstructionMaterials { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Credit> Credits { get; set; }
    }
}

