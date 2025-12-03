namespace KittehExpenseTracker.Models
{
    /// <summary>
    /// Represents a financial expense with a title, amount, and optional description.
    /// </summary>
    /// <remarks>Use the Expense class to model individual expense items, such as purchases or payments, in
    /// budgeting or accounting applications. Each expense includes a descriptive title, a monetary amount, and an
    /// optional description for additional details.</remarks>
    public class Expense
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public decimal Amount { get; private set; }

        public Expense(string title, string? description, decimal amount)
        {
            Title = title;
            Description = description;
            Amount = amount;
        }

        public Expense(string title, decimal amount)
        {
            Title = title;
            Amount = amount;
            Description = null;
        }
    }
}
