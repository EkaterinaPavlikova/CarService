
using CarService.UI.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Linq;

namespace CarService.UI.Utils
{
    public class XMLReader : IReader<OrderViewModel>
    {
        private XDocument xDoc;
        public ObservableCollection<OrderViewModel> Read()
        {
            var orders = new ObservableCollection<OrderViewModel>();

            try
            {
                xDoc = XDocument.Load("../../../orders.xml");

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


                    orders.Add(new OrderViewModel
                    {
                        OrderId = Convert.ToInt32(idAttribute.Value),
                        Description = descriptionElement.Value,
                        CarBrand = carBrandElement.Value,
                        CarYear = Convert.ToInt32(carYearElement.Value),
                        Transmission = transmissionElement.Value,
                        EnginePower = Convert.ToInt32(enginePowerElement.Value),
                       // TimeStart = Convert.ToDateTime(timeStartElement.Value),
                       // TimeEnd = Convert.ToDateTime(timeEndElement.Value),
                        Price = Convert.ToInt32(priceElement.Value),
                        ClientName = clientNameElement.Value,
                        ClientPatronymic = clientPatronymicElement.Value,
                        ClientSurname = clientSurnameElement.Value,
                        TelephoneNumber = telephoneNumberElement.Value,
                        BirthYear = Convert.ToInt32(birthYearElement.Value),
                        CarModel = carModelElement.Value
                    });
                }
              
                 
            }
            catch (Exception e) {}
            return orders;
        }

    }
}
