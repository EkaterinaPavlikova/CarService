using System;
namespace CarService.Data.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public int ClientId { get; set; }
        public virtual ClientModel Client { get; set; }

        public int CarId { get; set; }
        public virtual CarModel Car { get; set; }

    }
}
