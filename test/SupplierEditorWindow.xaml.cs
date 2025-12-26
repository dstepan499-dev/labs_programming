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
    public partial class SupplierEditorWindow : Window
    {
        public Supplier Supplier { get; private set; }

        public SupplierEditorWindow(Supplier supplier)
        {
            InitializeComponent();
            Supplier = supplier;
            this.DataContext = Supplier;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Supplier.Name) || string.IsNullOrWhiteSpace(Supplier.INN))
            {
                MessageBox.Show("Пожалуйста, заполните поля 'Название' и 'ИНН'.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.DialogResult = true;
        }
    }
}
