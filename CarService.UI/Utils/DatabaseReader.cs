using CarService.Data.Database;
using CarService.UI.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CarService.UI.Utils
{
    public class DatabaseReader: IReader<OrderViewModel>
    {
        private ApplicationContext db;

        public ObservableCollection<OrderViewModel> Read()
        {
            var orders = new ObservableCollection<OrderViewModel>();
            using (db = new ApplicationContext())
            {
                try
                {
                    orders = new ObservableCollection<OrderViewModel>((from order in db.Orders
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
                catch(Exception e)
                {

                }
            }

            return orders;
        }

    }
}
