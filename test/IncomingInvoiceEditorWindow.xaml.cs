using PharmacyWarehouse.Models;
using PharmacyWarehouse.ViewModels;
using System.Windows;

namespace PharmacyWarehouse
{
    public partial class IncomingInvoiceEditorWindow : Window
    {
        private readonly IncomingInvoiceEditorViewModel _viewModel;

        public IncomingInvoiceEditorWindow(IncomingInvoice invoice)
        {
            InitializeComponent();
            _viewModel = new IncomingInvoiceEditorViewModel(invoice);
            this.DataContext = _viewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.Save())
            {
                this.DialogResult = true;
            }
        }
    }
}
