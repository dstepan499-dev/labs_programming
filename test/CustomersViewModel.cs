using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PharmacyWarehouse.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace PharmacyWarehouse.ViewModels
{
    public class CustomersViewModel : INotifyPropertyChanged
    {
        private PharmacyDbContext _db;

        public ObservableCollection<Customer> Customers { get; set; }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        public RelayCommand AddCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }

        public CustomersViewModel()
        {
            _db = new PharmacyDbContext();
            Customers = new ObservableCollection<Customer>(_db.Customers.ToList());

            AddCommand = new RelayCommand(AddCustomer);
            EditCommand = new RelayCommand(EditCustomer, CanExecuteEditDelete);
            DeleteCommand = new RelayCommand(DeleteCustomer, CanExecuteEditDelete);
        }

        private void AddCustomer(object parameter)
        {
            var newCustomer = new Customer();
            var editorWindow = new CustomerEditorWindow(newCustomer);

            if (editorWindow.ShowDialog() == true)
            {
                _db.Customers.Add(newCustomer);
                _db.SaveChanges();
                Customers.Add(newCustomer);
            }
        }

        private void EditCustomer(object parameter)
        {
            var editorWindow = new CustomerEditorWindow(SelectedCustomer);

            if (editorWindow.ShowDialog() == true)
            {
                _db.SaveChanges();
            }
        }

        private void DeleteCustomer(object parameter)
        {
            if (MessageBox.Show($"Вы уверены, что хотите удалить {SelectedCustomer.Name}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _db.Customers.Remove(SelectedCustomer);
                _db.SaveChanges();
                Customers.Remove(SelectedCustomer);
            }
        }

        private bool CanExecuteEditDelete(object parameter)
        {
            return SelectedCustomer != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

