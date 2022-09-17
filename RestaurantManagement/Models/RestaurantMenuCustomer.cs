using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManagement.Models
{
    public partial class RestaurantMenuCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantMenuId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual RestaurantMenu RestaurantMenu { get; set; }
    }
}
