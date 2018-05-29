using CarServiceModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        private string selectedItem = "База данных";
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
            DataSources.Add("База данных");
            DataSources.Add("XML");
            DataSources.Add("Бинарный файл");

            using (db = new ApplicationContext())
            {
                Orders =  new ObservableCollection<OrderViewModel>((from order in db.Orders
                                         join client in db.Clients
                                         on order.ClientId equals client.Id
                                         join car in db.Cars
                                         on order.CarId equals car.Id
                                            select new OrderViewModel
                                                (
                                                    order,
                                                    client,
                                                    car
                                                 )).ToList());
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

