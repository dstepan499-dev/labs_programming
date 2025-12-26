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

namespace PharmacyWarehouse
{
    public partial class MedicineEditorWindow : Window
    {
        public Medicine Medicine { get; private set; }

        public MedicineEditorWindow(Medicine medicine)
        {
            InitializeComponent();
            Medicine = medicine;
            this.DataContext = Medicine;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

