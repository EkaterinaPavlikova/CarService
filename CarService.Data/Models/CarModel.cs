using System;

namespace CarService.Data.Models
{
    [Serializable]
    public class CarModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public int EnginePower { get; set; }
     
    }
}
