using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWarehouse.Models
{
    public class OutgoingInvoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int? CustomerID { get; set; }
        public string? SalespersonName { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OutgoingInvoiceItem> Items { get; set; }
    }
}
