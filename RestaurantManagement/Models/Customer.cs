using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManagement.Models
{
    public partial class Customer
    {
        public Customer()
        {
            RestaurantMenuCustomers = new HashSet<RestaurantMenuCustomer>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte Archived { get; set; }

        public virtual ICollection<RestaurantMenuCustomer> RestaurantMenuCustomers { get; set; }
    }
}
