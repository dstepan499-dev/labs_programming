using Microsoft.EntityFrameworkCore;
using PharmacyWarehouse.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace PharmacyWarehouse.ViewModels
{
    public class IncomingInvoicesViewModel : INotifyPropertyChanged
    {
        private PharmacyDbContext _db;
        public ObservableCollection<IncomingInvoice> Invoices { get; set; }
        private IncomingInvoice _selectedInvoice;
        public IncomingInvoice SelectedInvoice
        {
            get { return _selectedInvoice; }
            set
            {
                _selectedInvoice = value;
                OnPropertyChanged(nameof(SelectedInvoice));
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
        public IncomingInvoicesViewModel()
        {
            _db = new PharmacyDbContext();
            ReloadInvoicesCollection();
            AddCommand = new RelayCommand(AddInvoice);
            EditCommand = new RelayCommand(EditInvoice, CanExecuteEditDelete);
            DeleteCommand = new RelayCommand(DeleteInvoice, CanExecuteEditDelete);
        }
        private void AddInvoice(object parameter)
        {
            var newInvoice = new IncomingInvoice();
            var editorWindow = new IncomingInvoiceEditorWindow(newInvoice);
            editorWindow.ShowDialog();
            ReloadInvoicesCollection();
        }
        private void EditInvoice(object parameter)
        {
            if (SelectedInvoice == null) return;
            var editorWindow = new IncomingInvoiceEditorWindow(SelectedInvoice);
            editorWindow.ShowDialog();
            ReloadInvoicesCollection();
        }
        private void DeleteInvoice(object parameter)
        {
            if (SelectedInvoice == null) return;
            if (MessageBox.Show($"Вы уверены, что хотите удалить накладную №{SelectedInvoice.InvoiceNumber}?\n\nВНИМАНИЕ: Это действие также уменьшит остатки товаров на складе, связанных с этой накладной.",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (var transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        var itemsToDelete = _db.IncomingInvoiceItems
                                               .Where(i => i.InvoiceID == SelectedInvoice.InvoiceID)
                                               .ToList();
                        foreach (var item in itemsToDelete)
                        {
                            var medicine = _db.Medicines.Find(item.MedicineID);
                            if (medicine != null)
                            {
                                if (medicine.CurrentStock >= item.Quantity)
                                {
                                    medicine.CurrentStock -= item.Quantity;
                                }
                                else
                                {
                                    MessageBox.Show($"Невозможно удалить накладную. Остаток товара '{medicine.Name}' ({medicine.CurrentStock}) меньше, чем количество в накладной ({item.Quantity}). Возможно, товар уже продан.",
                                        "Ошибка операции", MessageBoxButton.OK, MessageBoxImage.Error);
                                    transaction.Rollback();
                                    return;
                                }
                            }
                        }
                        _db.IncomingInvoiceItems.RemoveRange(itemsToDelete);
                        var invoiceToDelete = _db.IncomingInvoices.Find(SelectedInvoice.InvoiceID);
                        if (invoiceToDelete != null)
                        {
                            _db.IncomingInvoices.Remove(invoiceToDelete);
                        }
                        _db.SaveChanges();
                        transaction.Commit();
                        Invoices.Remove(SelectedInvoice);
                        MessageBox.Show("Накладная успешно удалена, остатки на складе обновлены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Произошла ошибка при удалении накладной: {ex.Message}", "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void ReloadInvoicesCollection()
        {
            if (Invoices == null)
            {
                Invoices = new ObservableCollection<IncomingInvoice>();
            }
            Invoices.Clear();
            var loadedInvoices = _db.IncomingInvoices.Include(i => i.Supplier).ToList();
            foreach (var invoice in loadedInvoices)
            {
                Invoices.Add(invoice);
            }
        }
        private bool CanExecuteEditDelete(object parameter)
        {
            return SelectedInvoice != null;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
