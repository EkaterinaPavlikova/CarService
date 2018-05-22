using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class Client
    {
        public Client()
        {
            this.Cars = new ObservableCollection<Car>();
        }
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }   
        public int BirthYear { get; set; }
        public int TelephoneNumber { get; set; }

        public int CarId { get; set; }
        public virtual ObservableCollection<Car> Cars { get; set; }
    }
}
