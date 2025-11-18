using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyWarehouse.Models;

namespace PharmacyWarehouse
{
    public class PharmacyDbContext : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<IncomingInvoice> IncomingInvoices { get; set; }
        public DbSet<IncomingInvoiceItem> IncomingInvoiceItems { get; set; }
        public DbSet<OutgoingInvoice> OutgoingInvoices { get; set; }
        public DbSet<OutgoingInvoiceItem> OutgoingInvoiceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KVI0C67\SQLEXPRESS;Database=PharmacyDB;Trusted_Connection=True;TrustServerCertificate=True;"
);
        }
    }
}