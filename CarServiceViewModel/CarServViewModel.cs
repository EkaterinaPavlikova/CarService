using CarServiceModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CarServiceViewModel
{
    public class CarServViewModel: INotifyPropertyChanged
    {
        private ApplicationContext db;

        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public OrderViewModel selectedOrder;

        private ObservableCollection<String> dataSources = new ObservableCollection<String>();
        public ObservableCollection<String> DataSources
        {
            get { return dataSources; }
            set { dataSources = value; }
        }
        private string selectedItem = "";
        public String SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value;}
        }

        public OrderViewModel SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public CarServViewModel()
        {
            //DataSources.Add("База данных");
            //DataSources.Add("XML");
            //DataSources.Add("Бинарный файл");

            var clients = new ObservableCollection<Client>
            {
               new Client { Name = "p", Id=1 },
               new Client { Name = "l" , Id=3 },
                 new Client { Name = "j" , Id=11 },
                new Client { Name="j" , Id=2 },
            };

            var cars = new ObservableCollection<Car> { new Car { Id = 3 } };

            var orders = new ObservableCollection<Order>
            {
               new Order { Description = "hhhhhh", ClientId=1, CarId=3 },
               new Order { Description = "uuu" , ClientId=1, CarId=3 },
                 new Order { Description = "ttttt" , ClientId=1, CarId=3},
                new Order { Description="eeeeeee" , ClientId=2, CarId=3 },
            };

            Orders = new ObservableCollection<OrderViewModel>((from order in orders
                                                               join client in clients
                                                               on order.ClientId equals client.Id
                                                               join car in cars on order.CarId equals
                                                               car.Id

                                                               select new OrderViewModel
                                                               (

                                                                   order,
                                                                   client,
                                                                   car
                                                               )

                                      ).ToList());



            using (db = new ApplicationContext())
            {
                /*Orders =  new ObservableCollection<OrderViewModel>((from order in db.Orders
                                         join client in db.Clients
                                         on order.ClientId equals client.Id
                                         join car in db.Cars
                                         on order.CarId equals car.Id
                                            select new OrderViewModel
                                                (
                                                    order,
                                                    client,
                                                    car
                                                 )).ToList());*/
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    
    }

