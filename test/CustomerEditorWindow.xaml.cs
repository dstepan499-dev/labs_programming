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
    public partial class CustomerEditorWindow : Window
    {
        public Customer Customer { get; private set; }

        public CustomerEditorWindow(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            this.DataContext = Customer;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Customer.Name) || string.IsNullOrWhiteSpace(Customer.INN))
            {
                MessageBox.Show("Пожалуйста, заполните поля 'Название' и 'ИНН'.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.DialogResult = true;
        }
    }
}

