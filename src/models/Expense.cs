namespace KittehExpenseTracker.src.models
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
		public double Amount { get; private set; }

        public Expense(string title, string? description, double amount)
        {
			Title = title;
			Description = description;
			Amount = amount;
        }

        public Expense(string title, double amount)
        {
			Title = title;
			Amount = amount;
            Description = null;
        }
    }
}
