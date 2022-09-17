using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManagement.Models
{
    public partial class RestaurantMenu
    {
        public RestaurantMenu()
        {
            RestaurantMenuCustomers = new HashSet<RestaurantMenuCustomer>();
        }

        public int Id { get; set; }
        public string MealName { get; set; }
        public double PriceInNis { get; set; }
        public double PriceInUsd { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte Archived { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurantt Restaurant { get; set; }
        public virtual ICollection<RestaurantMenuCustomer> RestaurantMenuCustomers { get; set; }
    }
}
