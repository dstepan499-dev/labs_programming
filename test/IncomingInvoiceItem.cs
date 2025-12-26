using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWarehouse.Models
{
    public class IncomingInvoiceItem
    {
        [Key]
        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public int MedicineID { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public IncomingInvoice Invoice { get; set; }
        public Medicine Medicine { get; set; }
    }
}
