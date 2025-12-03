using KittehExpenseTracker.src.models;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KittehExpenseTracker
{
    /// <summary>
    /// Interaction logic for AddExpenseWindow.xaml
    /// </summary>
    public partial class AddExpenseWindow : MetroWindow
    {
        public AddExpenseWindow()
        {
            InitializeComponent();
        }

        #region UI Event Handlers

        private void AddExpenseToMain_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("[AddExpenseToMain] Add Expense Button was clicked. Adding new expense.");

            if (ValidateForm())
            {
                // Add expense to the main form
                string expenseTitle = ExpenseName.Text;
                string? expenseDescription = ExpenseDescription.Text;
                double expenseAmount = Convert.ToDouble(ExpenseAmount.Text);

                Expense newExpense = new(expenseTitle, expenseDescription, expenseAmount);
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.AddExpense(newExpense);

                Close();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion

        #region Helper Methods

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(ExpenseName.Text) || string.IsNullOrEmpty(ExpenseAmount.Text))
            {
                return false;
            }

            // Check if the amount is a valid number
            double expenseAmount = Double.TryParse(ExpenseAmount.Text, out expenseAmount) ? expenseAmount : 0;
            if (expenseAmount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        #endregion
    }
}
