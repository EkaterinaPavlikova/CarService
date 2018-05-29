
using System;

namespace CarServiceModel
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

    }
}
