
using CarService.Data.DataUtils;
using CarService.Data.Helpers;
using CarService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Data.Database
{
    public class DatabaseReader : IReader<OrderModel>
    {
        private ApplicationContext db;

        public IEnumerable<OrderModel> Read()
        {
            var orders = new List<OrderModel>();

            try
            {
                using (db = new ApplicationContext())
                {
                    orders = (from order in db.Orders
                              join client in db.Clients
                              on order.ClientId equals client.Id
                              join car in db.Cars
                              on order.CarId equals car.Id
                              select new OrderModel
                              {
                                  Id = order.Id,
                                  Description = order.Description,
                                  Price = order.Price,
                                  TimeEnd = order.TimeEnd,
                                  TimeStart = order.TimeStart,
                                  CarId = order.CarId,
                                  ClientId = order.ClientId,
                                  Client = client,
                                  Car = car
                              }).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Fix(ex.ToString());
            }


            return orders;
        }

    }
}
