using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWarehouse.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineID { get; set; }

        public string Name { get; set; }

        public string? Category { get; set; }

        public DateTime? ProductionDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string? RegistrationNumber { get; set; }

        public string? ManufacturerInfo { get; set; }

        public string? PackageType { get; set; }

        public int CurrentStock { get; set; }

        public ICollection<IncomingInvoiceItem> IncomingInvoiceItems { get; set; }
        public ICollection<OutgoingInvoiceItem> OutgoingInvoiceItems { get; set; }
    }
}
