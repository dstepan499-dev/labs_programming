using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PharmacyWarehouse.Models
{
    public class IncomingInvoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int? SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<IncomingInvoiceItem> Items { get; set; }

        public IncomingInvoice()
        {
            Items = new HashSet<IncomingInvoiceItem>();
        }
    }
}
