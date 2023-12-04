namespace CarvedRock.DataAccess.Models
{
    public abstract class FoodItem : Item
    {
        public DateTime ExpiryDate { get; set; }
    }
}
