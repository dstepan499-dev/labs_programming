using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyWarehouse.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PharmacyWarehouse.ViewModels
{
    public class MedicinesViewModel
    {
        public ObservableCollection<Medicine> Medicines { get; set; }

        public MedicinesViewModel()
        {
            using (var db = new PharmacyDbContext())
            {
                Medicines = new ObservableCollection<Medicine>(db.Medicines.ToList());
            }
        }
    }
}