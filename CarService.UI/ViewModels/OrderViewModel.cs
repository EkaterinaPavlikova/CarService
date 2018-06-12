using CarService.Data.Models;
using System;

namespace CarService.UI.ViewModels
{
    public class OrderViewModel: BaseViewModel
    {
        private OrderModel order;
        private ClientModel client;
        private CarModel car;
        public OrderViewModel(OrderModel o)
        {
            order = o;
            car = o.Car;
            client = o.Client;
        }

        public OrderViewModel()
        {
            order = new OrderModel();
            client = new ClientModel();
            car = new CarModel();
        }

        public string Description
        {
            get { return order.Description; }
            set
            {
                order.Description = value;
                OnPropertyChanged("Discription");
            }
        }

        public int OrderId
        {
            get { return order.Id; }
            set
            {
                order.Id = value;
                OnPropertyChanged("OrderId");
            }
        }

        public string CarBrand
        {
            get { return car.Brand; }
            set
            {
                car.Brand = value;
                OnPropertyChanged("CarBrand");
            }
        }

        public string CarModel
        {
            get { return car.Model; }
            set
            {
                car.Model = value;
                OnPropertyChanged("CarModel");
            }
        }

        public int CarYear
        {
            get { return car.Year; }
            set
            {
                car.Year = value;
                OnPropertyChanged("CarYear");
            }
        }

        public string Transmission
        {
            get { return car.Transmission; }
            set
            {
                car.Transmission = value;
                OnPropertyChanged("Transmission");
            }
        }

        public int EnginePower
        {
            get { return car.EnginePower; }
            set
            {
                car.EnginePower = value;
                OnPropertyChanged("EnginePower");
            }
        }

        public decimal Price
        {
            get { return order.Price; }
            set
            {
                order.Price = value;
                OnPropertyChanged("Price");
            }
        }

        public DateTime TimeStart
        {
            get { return order.TimeStart; }
            set
            {
                order.TimeStart = value;
                OnPropertyChanged("TimeStart");
            }
        }

        public DateTime TimeEnd
        {
            get { return order.TimeEnd; }
            set
            {
                order.TimeEnd = value;
                OnPropertyChanged("TimeEnd");
            }
        }


        public string ClientName
        {
            get { return client.Name; }
            set
            {
                client.Name = value;
                OnPropertyChanged("ClientName");
            }
        }

        public string ClientPatronymic
        {
            get { return client.Patronymic; }
            set
            {
                client.Patronymic = value;
                OnPropertyChanged("ClientPatronymic");
            }
        }

        public string ClientSurname
        {
            get { return client.Surname; }
            set
            {
                client.Surname = value;
                OnPropertyChanged("ClientSurname");
            }
        }

        public string TelephoneNumber
        {
            get { return client.TelephoneNumber; }
            set
            {
                client.TelephoneNumber = value;
                OnPropertyChanged("TelephoneNumber");
            }
        }

        public int BirthYear
        {
            get { return client.BirthYear; }
            set
            {
                client.BirthYear = value;
                OnPropertyChanged("BirthYear");
            }
        }


    }
}
