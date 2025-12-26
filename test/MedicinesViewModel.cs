using PharmacyWarehouse.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace PharmacyWarehouse.ViewModels
{
    public class MedicinesViewModel : INotifyPropertyChanged
    {
        private PharmacyDbContext _db;

        public ObservableCollection<Medicine> Medicines { get; set; }

        private Medicine _selectedMedicine;
        public Medicine SelectedMedicine
        {
            get { return _selectedMedicine; }
            set
            {
                _selectedMedicine = value;
                OnPropertyChanged(nameof(SelectedMedicine));
            }
        }

        public RelayCommand AddCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }


        public MedicinesViewModel()
        {
            _db = new PharmacyDbContext();
            Medicines = new ObservableCollection<Medicine>(_db.Medicines.ToList());

            AddCommand = new RelayCommand(AddMedicine);
            EditCommand = new RelayCommand(EditMedicine, CanExecuteEditDelete);
            DeleteCommand = new RelayCommand(DeleteMedicine, CanExecuteEditDelete);
        }


        private void AddMedicine(object parameter)
        {
            var newMedicine = new Medicine { ExpiryDate = System.DateTime.Now.AddYears(1) };
            var editorWindow = new MedicineEditorWindow(newMedicine);

            if (editorWindow.ShowDialog() == true)
            {
                _db.Medicines.Add(newMedicine);
                _db.SaveChanges();
                Medicines.Add(newMedicine);
            }
        }

        private void EditMedicine(object parameter)
        {
            var editorWindow = new MedicineEditorWindow(SelectedMedicine);

            if (editorWindow.ShowDialog() == true)
            {
                _db.SaveChanges();
            }
        }

        private void DeleteMedicine(object parameter)
        {
            if (MessageBox.Show($"Вы уверены, что хотите удалить {SelectedMedicine.Name}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _db.Medicines.Remove(SelectedMedicine);
                _db.SaveChanges();
                Medicines.Remove(SelectedMedicine);
            }
        }

        private bool CanExecuteEditDelete(object parameter)
        {
            return SelectedMedicine != null;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
