
using CarService.Data.DataUtils;
using CarService.Data.Helpers;
using CarService.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace CarService.Data.XML
{
    public class XMLReader : IReader<OrderModel>
    {
        private XDocument xDoc;
        public IEnumerable<OrderModel> Read()
        {
            var orders = new List<OrderModel>();

            try
            {
                xDoc = XDocument.Load("../../../CarService.Data/XML/orders.xml");

                foreach (XElement orderElement in xDoc.Element("orders").Elements("order"))
                {
                    XAttribute idAttribute = orderElement.Attribute("id");
                    XElement descriptionElement = orderElement.Element("description");
                    XElement carBrandElement = orderElement.Element("carBrand");
                    XElement carModelElement = orderElement.Element("carModel");
                    XElement carYearElement = orderElement.Element("carYear");
                    XElement transmissionElement = orderElement.Element("transmission");
                    XElement enginePowerElement = orderElement.Element("enginePower");
                    XElement timeStartElement = orderElement.Element("timeStart");
                    XElement timeEndElement = orderElement.Element("timeEnd");
                    XElement priceElement = orderElement.Element("price");
                    XElement clientNameElement = orderElement.Element("clientName");
                    XElement clientPatronymicElement = orderElement.Element("clientPatronymic");
                    XElement clientSurnameElement = orderElement.Element("clientSurname");
                    XElement telephoneNumberElement = orderElement.Element("telephoneNumber");
                    XElement birthYearElement = orderElement.Element("birthYear");


                    orders.Add(new OrderModel
                    {
                        Id = Convert.ToInt32(idAttribute.Value),
                        Price = Convert.ToInt32(priceElement.Value),
                        Description = descriptionElement.Value,

                        Car = new CarModel
                        {
                            Brand = carBrandElement.Value,
                            Model = carModelElement.Value,
                            Year = Convert.ToInt32(carYearElement.Value),
                            Transmission = transmissionElement.Value,
                            EnginePower = Convert.ToInt32(enginePowerElement.Value),
                        },
                        Client= new ClientModel
                        {
                            Name = clientNameElement.Value,
                            Patronymic = clientPatronymicElement.Value,
                            Surname = clientSurnameElement.Value,
                            TelephoneNumber = telephoneNumberElement.Value,
                            BirthYear = Convert.ToInt32(birthYearElement.Value),
                        }

                    });
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
