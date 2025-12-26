using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWarehouse.ViewModels
{
    public class MainViewModel
    {
        public MedicinesViewModel MedicinesVM { get; set; }
        public SuppliersViewModel SuppliersVM { get; set; }
        public CustomersViewModel CustomersVM { get; set; }
        public IncomingInvoicesViewModel IncomingInvoicesVM { get; set; }

        public MainViewModel()
        {
            MedicinesVM = new MedicinesViewModel();
            SuppliersVM = new SuppliersViewModel();
            CustomersVM = new CustomersViewModel();
            IncomingInvoicesVM = new IncomingInvoicesViewModel();
        }
    }
}
