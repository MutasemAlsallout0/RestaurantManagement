namespace RestaurantManagement.ModelsViews
{
    public class CsvView
    {
        public string RestaurantName { get; set; }
        public int NumberOfOrderedCustomer { get; set; }
        public double ProfitInNis { get; set; }
        public double ProfitInUsd { get; set; }
        public string TheBestSellingMeal { get; set; }
        public string MostPurchasedCustomer { get; set; }
    }
}
