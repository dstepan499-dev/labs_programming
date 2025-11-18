using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWarehouse.Models
{
    public class OutgoingInvoiceItem
    {
        [Key]
        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public int MedicineID { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public OutgoingInvoice Invoice { get; set; }
        public Medicine Medicine { get; set; }
    }
}
