using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWarehouse.Models
{
    public class IncomingInvoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int? SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<IncomingInvoiceItem> Items { get; set; }
    }
}
