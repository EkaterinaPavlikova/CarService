using CarService.Data.Constants;
using CarService.Data.Database;
using CarService.Data.Models;
using CarService.UI.Utils;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CarService.UI.ViewModels
{
    public class MainFormViewModel : INotifyPropertyChanged
    {
        private IReader<OrderViewModel> reader;
        private ObservableCollection<String> dataSources = new ObservableCollection<String>();
        private string selectedItem = "";
        private OrderViewModel selectedOrder;
        private ChangeSourceCommand addCommand;

        private ObservableCollection<OrderViewModel> orders { get; set ; }
     
        public ObservableCollection<OrderViewModel> Orders
        {
            get { return orders; }
            set
            {
                if (orders != value)
                {
                    orders = value;
                    OnPropertyChanged("Orders");
                }
            }
        }
        public ChangeSourceCommand ChangeCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new ChangeSourceCommand(obj =>
                  {
                      IKernel ninjectKernel = new StandardKernel();
                      switch (SelectedItem)
                      {
                          case DataSourceTypes.Database:
                              ninjectKernel.Bind<IReader<OrderViewModel>>().To<DatabaseReader>();                             
                              break;
                          case DataSourceTypes.XML:
                              ninjectKernel.Bind<IReader<OrderViewModel>>().To<XMLReader>();                          
                              break;
                          case DataSourceTypes.Binary:
                              ninjectKernel.Bind<IReader<OrderViewModel>>().To<XMLReader>();
                              break;
                          default:
                              ninjectKernel.Bind<IReader<OrderViewModel>>().To<XMLReader>();
                              break;
                      }
                      reader = ninjectKernel.Get<IReader<OrderViewModel>>();
                      Orders = reader.Read();
                  }));
            }
        }


        public ObservableCollection<String> DataSources
        {
            get { return dataSources; }
            set { dataSources = value; }
        }

        public String SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
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

        public MainFormViewModel()
        {
            DataSources.Add(DataSourceTypes.Database);
            DataSources.Add(DataSourceTypes.XML);
            DataSources.Add(DataSourceTypes.Binary);         
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

   }

