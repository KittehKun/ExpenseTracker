using KittehExpenseTracker.Models;
using System.Collections.ObjectModel;

namespace KittehExpenseTracker.ViewModels
{
    /// <summary>
    /// ViewModel for the main window, handling expense collection and total calculations.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Expense> _expenses;
        private decimal _totalExpensesValue;

        public ObservableCollection<Expense> Expenses
        {
            get => _expenses;
            private set => SetProperty(ref _expenses, value);
        }

        public decimal TotalExpensesValue
        {
            get => _totalExpensesValue;
            private set => SetProperty(ref _totalExpensesValue, value);
        }

        public MainWindowViewModel()
        {
            _expenses = new ObservableCollection<Expense>();
            _expenses.CollectionChanged += (s, e) => UpdateTotalExpenses();

            // Sample data for testing
            //TODO: Remove sample data once JSON storage is implemented
            Expenses.Add(new Expense("Groceries", 50.00m));
            Expenses.Add(new Expense("Entertainment", 100.00m));
            Expenses.Add(new Expense("Rent", 1200.00m));
        }

        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
        }

        public void RemoveExpense(Expense expense)
        {
            Expenses.Remove(expense);
        }

        private void UpdateTotalExpenses()
        {
            TotalExpensesValue = CalculateTotalExpenses();
        }

        private decimal CalculateTotalExpenses()
        {
            return Expenses.Sum(expense => expense.Amount);
        }
    }
}
