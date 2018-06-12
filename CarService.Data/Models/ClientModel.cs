using System;
using System.Collections.ObjectModel;
namespace CarService.Data.Models
{
    [Serializable]
    public class ClientModel
    {
        public ClientModel()
        {
            this.Cars = new ObservableCollection<CarModel>();
        }
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }   
        public int BirthYear { get; set; }
        public string TelephoneNumber { get; set; }

        public int CarId { get; set; }
        public virtual ObservableCollection<CarModel> Cars { get; set; }
    }
}
