namespace BudgetPlanner.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Type{ get; set; } // "Income" or "Expense"

        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
