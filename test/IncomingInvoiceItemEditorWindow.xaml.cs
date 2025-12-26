using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PharmacyWarehouse.Models;
using System.Collections.Generic;
using System.Linq;
using PharmacyWarehouse.ViewModels;

namespace PharmacyWarehouse
{
    public partial class IncomingInvoiceItemEditorWindow : Window
    {
        private PharmacyDbContext _db;
        public IncomingInvoiceItem InvoiceItem { get; private set; }
        public List<Medicine> AllMedicines { get; private set; }

        private Medicine _selectedMedicine;
        public Medicine SelectedMedicine
        {
            get { return _selectedMedicine; }
            set
            {
                _selectedMedicine = value;
                if (value != null)
                {
                    InvoiceItem.MedicineID = value.MedicineID;
                }
            }
        }

        public IncomingInvoiceItemEditorWindow(PharmacyDbContext dbContext, List<Medicine> allMedicines, IncomingInvoiceItem item)
        {
            InitializeComponent();
            _db = dbContext;
            AllMedicines = allMedicines;
            InvoiceItem = item;

            if (InvoiceItem.MedicineID != 0)
            {
                SelectedMedicine = AllMedicines.FirstOrDefault(m => m.MedicineID == InvoiceItem.MedicineID);
            }
            this.DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMedicine == null || InvoiceItem.Quantity <= 0 || InvoiceItem.PurchasePrice <= 0)
            {
                MessageBox.Show("Пожалуйста, выберите лекарство, укажите количество и цену (больше нуля).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.DialogResult = true;
        }
    }
}
