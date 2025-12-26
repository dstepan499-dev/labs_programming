using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyWarehouse.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace PharmacyWarehouse.ViewModels
{
    public class IncomingInvoiceEditorViewModel : INotifyPropertyChanged
    {
        private PharmacyDbContext _db;
        public IncomingInvoice CurrentInvoice { get; set; }
        public ObservableCollection<IncomingInvoiceItem> InvoiceItems { get; set; }
        public ObservableCollection<Supplier> AllSuppliers { get; set; }
        public ObservableCollection<Medicine> AllMedicines { get; set; }
        private Supplier _selectedSupplier;
        public Supplier SelectedSupplier
        {
            get { return _selectedSupplier; }
            set
            {
                _selectedSupplier = value;
                if (value != null)
                {
                    CurrentInvoice.SupplierID = value.SupplierID;
                }
                OnPropertyChanged(nameof(SelectedSupplier));
            }
        }
        private IncomingInvoiceItem _selectedInvoiceItem;
        public IncomingInvoiceItem SelectedInvoiceItem
        {
            get { return _selectedInvoiceItem; }
            set
            {
                _selectedInvoiceItem = value;
                OnPropertyChanged(nameof(SelectedInvoiceItem));
                RemoveItemCommand.RaiseCanExecuteChanged();
            }
        }
        public RelayCommand AddItemCommand { get; private set; }
        public RelayCommand RemoveItemCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public IncomingInvoiceEditorViewModel(IncomingInvoice invoice)
        {
            _db = new PharmacyDbContext();
            CurrentInvoice = _db.IncomingInvoices
                                .Include(i => i.Items)
                                .ThenInclude(item => item.Medicine)
                                .FirstOrDefault(i => i.InvoiceID == invoice.InvoiceID) ?? invoice;
            if (CurrentInvoice.InvoiceID == 0)
            {
                CurrentInvoice.InvoiceDate = System.DateTime.Now;
                CurrentInvoice.InvoiceNumber = $"ПН-{System.DateTime.Now.ToString("yyMMddHHmmss")}";
            }
            AllSuppliers = new ObservableCollection<Supplier>(_db.Suppliers.ToList());
            AllMedicines = new ObservableCollection<Medicine>(_db.Medicines.ToList());
            InvoiceItems = new ObservableCollection<IncomingInvoiceItem>(CurrentInvoice.Items);
            if (CurrentInvoice.SupplierID.HasValue)
            {
                SelectedSupplier = AllSuppliers.FirstOrDefault(s => s.SupplierID == CurrentInvoice.SupplierID);
            }
            AddItemCommand = new RelayCommand(AddItem);
            RemoveItemCommand = new RelayCommand(RemoveItem, CanExecuteRemoveItem);
        }
        private void AddItem(object parameter)
        {
            var newItem = new IncomingInvoiceItem();
            var itemEditor = new IncomingInvoiceItemEditorWindow(_db, AllMedicines.ToList(), newItem);
            if (itemEditor.ShowDialog() == true)
            {
                newItem.Medicine = AllMedicines.FirstOrDefault(m => m.MedicineID == newItem.MedicineID);
                InvoiceItems.Add(newItem);
            }
        }
        private void RemoveItem(object parameter)
        {
            InvoiceItems.Remove(SelectedInvoiceItem);
        }
        private bool CanExecuteRemoveItem(object parameter)
        {
            return SelectedInvoiceItem != null;
        }
        public bool Save()
        {
            if (SelectedSupplier == null || string.IsNullOrWhiteSpace(CurrentInvoice.InvoiceNumber))
            {
                MessageBox.Show("Пожалуйста, укажите номер накладной и выберите поставщика.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            CurrentInvoice.SupplierID = SelectedSupplier.SupplierID;
            CurrentInvoice.Supplier = SelectedSupplier;
            if (CurrentInvoice.InvoiceID != 0)
            {
                var oldItems = _db.IncomingInvoiceItems.AsNoTracking().Where(i => i.InvoiceID == CurrentInvoice.InvoiceID).ToList();
                foreach (var oldItem in oldItems)
                {
                    var med = _db.Medicines.Find(oldItem.MedicineID);
                    if (med != null) med.CurrentStock -= oldItem.Quantity;
                }
            }
            CurrentInvoice.Items = InvoiceItems.ToList();
            foreach (var item in CurrentInvoice.Items)
            {
                var med = _db.Medicines.Find(item.MedicineID);
                if (med != null) med.CurrentStock += item.Quantity;
            }
            if (CurrentInvoice.InvoiceID == 0)
            {
                _db.IncomingInvoices.Add(CurrentInvoice);
            }
            _db.SaveChanges();
            MessageBox.Show("Накладная успешно сохранена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
