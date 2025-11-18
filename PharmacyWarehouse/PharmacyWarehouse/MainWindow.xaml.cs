using System.Windows;
using PharmacyWarehouse.ViewModels;


namespace PharmacyWarehouse
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new MedicinesViewModel();

            this.DataContext = viewModel;
        }
    }
}