using KittehExpenseTracker.Models;
using MahApps.Metro.Controls;
using System.Globalization;
using System.Windows;

namespace KittehExpenseTracker
{
    /// <summary>
    /// Interaction logic for AddExpenseWindow.xaml
    /// </summary>
    public partial class AddExpenseWindow : MetroWindow
    {
        public Expense? CreatedExpense { get; private set; }

        public AddExpenseWindow()
        {
            InitializeComponent();
        }

        #region UI Event Handlers

        private void AddExpenseToMain_Click(object sender, RoutedEventArgs e)
        {
            if (TryCreateExpense(out Expense newExpense))
            {
                CreatedExpense = newExpense;
                DialogResult = true;
                Close();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        #endregion

        #region Helper Methods

        private bool TryCreateExpense(out Expense expense)
        {
            expense = null!;

            if (string.IsNullOrWhiteSpace(ExpenseName.Text) || string.IsNullOrWhiteSpace(ExpenseAmount.Text))
            {
                return false;
            }

            if (!decimal.TryParse(ExpenseAmount.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal parsedAmount))
            {
                MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (parsedAmount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            string expenseTitle = ExpenseName.Text.Trim();
            string? expenseDescription = string.IsNullOrWhiteSpace(ExpenseDescription.Text) ? null : ExpenseDescription.Text.Trim();

            expense = new Expense(expenseTitle, expenseDescription, parsedAmount);
            return true;
        }

        #endregion
    }
}
