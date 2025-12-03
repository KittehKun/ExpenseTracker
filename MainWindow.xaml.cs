using KittehExpenseTracker.src.models;
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KittehExpenseTracker
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow, INotifyPropertyChanged
	{
		private ObservableCollection<Expense> expenses = new ObservableCollection<Expense>();
		public ObservableCollection<Expense> Expenses => expenses;

		public double TotalExpensesValue => CalculateTotalExpenses();

		public event PropertyChangedEventHandler? PropertyChanged;

		public MainWindow()
		{
			InitializeComponent();

			// Bind the expenses to the DataGrid
			ExpenseDataGrid.ItemsSource = expenses;

			expenses.CollectionChanged += (s, e) =>
			{
				OnPropertyChanged(nameof(TotalExpensesValue));
			};

            // Sample data for testing
            //TODO: Remove sample data once JSON storage is implemented
            expenses.Add(new Expense("Groceries", 50.00));
			expenses.Add(new Expense("Entertainment", 100.00));
			expenses.Add(new Expense("Rent", 1200.00));
		}

        #region UI Event Handlers

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("[DEBUG] Add Expense Button was clicked. Creating new expense.");

			// Open the AddExpenseWindow dialog
			AddExpenseWindow addExpenseWindow = new();
			addExpenseWindow.ShowDialog();
		}

		private void DeleteExpense_Click(object sender, RoutedEventArgs e)
		{
			if(ExpenseDataGrid.SelectedItem is Expense selectedExpense)
			{
				MessageBoxResult result = MessageBox.Show(
					$"Are you sure you want to delete \"{selectedExpense.Title}\"?",
					"Delete Expense",
					MessageBoxButton.YesNo,
					MessageBoxImage.Warning
				);

				if(result == MessageBoxResult.Yes)
				{
					expenses.Remove(selectedExpense);
				}
			}
		}

		#endregion

		#region Helper Methods

		private double CalculateTotalExpenses()
		{
			return expenses.Sum(expense => expense.Amount);
		}

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
        }

        #endregion

        #region Event Listeners

        private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}