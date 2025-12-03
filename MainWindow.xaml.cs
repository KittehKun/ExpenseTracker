using KittehExpenseTracker.Models;
using KittehExpenseTracker.ViewModels;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace KittehExpenseTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }

        #region UI Event Handlers

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            AddExpenseWindow addExpenseWindow = new();
            if (addExpenseWindow.ShowDialog() == true && addExpenseWindow.CreatedExpense is not null)
            {
                _viewModel.AddExpense(addExpenseWindow.CreatedExpense);
            }
        }

        private void DeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            if (ExpenseDataGrid.SelectedItem is Expense selectedExpense)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete \"{selectedExpense.Title}\"?",
                    "Delete Expense",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.RemoveExpense(selectedExpense);
                }
            }
        }

        #endregion
    }
}