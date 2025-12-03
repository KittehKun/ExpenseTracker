namespace KittehExpenseTracker.src.models
{
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
