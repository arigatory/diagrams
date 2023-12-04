namespace CarvedRock.DataAccess.Models
{
    public class CannedFoodItem : FoodItem
    {
        public CanningMaterial CanningMaterial { get; set; }
        
        public DateTime ProductionDate { get; set; }
    }
}
