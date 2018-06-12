

using CarService.Data.DataUtils;
using CarService.Data.Helpers;
using CarService.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CarService.Data.Binary
{
    public class BinaryReader : IReader<OrderModel>
    {
        BinaryFormatter formatter;
        public IEnumerable<OrderModel> Read()
        {
            formatter = new BinaryFormatter();
            var orders = new List<OrderModel>();

            try
            {
                using (FileStream fs = new FileStream("../../../CarService.Data/Binary/orders.dat", FileMode.OpenOrCreate))

                {
                    List<OrderModel> deserilizePeople = (List<OrderModel>)formatter.Deserialize(fs);
                    orders = deserilizePeople;
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
