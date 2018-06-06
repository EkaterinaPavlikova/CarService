using CarService.Data.Constants;
using CarService.Data.Database;
using CarService.Data.Models;
using CarService.UI.Utils;
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
                      switch (SelectedItem)
                      {
                          case DataSourceTypes.Database:
                              reader = new DatabaseReader();
                              Orders = reader.Read();
                              break;
                          case DataSourceTypes.XML:
                              reader = new XMLReader();
                              Orders = reader.Read();
                              break;
                          case DataSourceTypes.Binary:
                              break;
                          default:
                              break;                             
                      }                    
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

