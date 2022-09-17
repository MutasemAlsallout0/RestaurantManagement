using System;

namespace RestaurantManagement.ModelsViews
{
    public class RestaurantMenuView
    {
        public string MealName { get; set; }
        public double PriceInNis { get; set; }
        public int Quantity { get; set; }
        public byte Archived { get; set; }
        public int RestaurantId { get; set; }
    }
}
