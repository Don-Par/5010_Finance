namespace PersonalFinanceTracker.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal Limit { get; set; }
        public decimal CurrentSpending { get; set; }
    }
}
