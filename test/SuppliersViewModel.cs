using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyWarehouse.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace PharmacyWarehouse.ViewModels
{
    public class SuppliersViewModel : INotifyPropertyChanged
    {
        private PharmacyDbContext _db;

        public ObservableCollection<Supplier> Suppliers { get; set; }

        private Supplier _selectedSupplier;
        public Supplier SelectedSupplier
        {
            get { return _selectedSupplier; }
            set
            {
                _selectedSupplier = value;
                OnPropertyChanged(nameof(SelectedSupplier));
            }
        }

        public RelayCommand AddCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }

        public SuppliersViewModel()
        {
            _db = new PharmacyDbContext();
            Suppliers = new ObservableCollection<Supplier>(_db.Suppliers.ToList());

            AddCommand = new RelayCommand(AddSupplier);
            EditCommand = new RelayCommand(EditSupplier, CanExecuteEditDelete);
            DeleteCommand = new RelayCommand(DeleteSupplier, CanExecuteEditDelete);
        }

        private void AddSupplier(object parameter)
        {
            var newSupplier = new Supplier();
            var editorWindow = new SupplierEditorWindow(newSupplier);
            if (editorWindow.ShowDialog() == true)
            {
                _db.Suppliers.Add(newSupplier);
                _db.SaveChanges();
                Suppliers.Add(newSupplier);
            }
        }

        private void EditSupplier(object parameter)
        {
            var editorWindow = new SupplierEditorWindow(SelectedSupplier);

            if (editorWindow.ShowDialog() == true)
            {
                _db.SaveChanges();
            }
        }

        private void DeleteSupplier(object parameter)
        {
            if (MessageBox.Show($"Вы уверены, что хотите удалить {SelectedSupplier.Name}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _db.Suppliers.Remove(SelectedSupplier);
                _db.SaveChanges();
                Suppliers.Remove(SelectedSupplier);
            }
        }

        private bool CanExecuteEditDelete(object parameter)
        {
            return SelectedSupplier != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
