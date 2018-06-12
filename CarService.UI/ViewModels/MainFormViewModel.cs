using CarService.Data.Binary;
using CarService.Data.Constants;
using CarService.Data.Database;
using CarService.Data.DataUtils;
using CarService.Data.Models;
using CarService.Data.XML;
using CarService.UI.Utils;
using Ninject;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CarService.UI.ViewModels
{
    public class MainFormViewModel : BaseViewModel
    {
        private IReader<OrderModel> reader;
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
                      bool noSelect = false;
                      IKernel ninjectKernel = new StandardKernel();
                      switch (SelectedItem)
                      {
                          case DataSourceTypes.Database:
                              ninjectKernel.Bind<IReader<OrderModel>>().To<DatabaseReader>();                             
                              break;
                          case DataSourceTypes.XML:
                              ninjectKernel.Bind<IReader<OrderModel>>().To<XMLReader>();                          
                              break;
                          case DataSourceTypes.Binary:
                              ninjectKernel.Bind<IReader<OrderModel>>().To<BinaryReader>();
                              break;
                          default:
                              MessageBox.Show("Не выбран способ загрузки данных ");
                              noSelect = true;                            
                              break;
                      }
                      if (!noSelect)
                      {
                          reader = ninjectKernel.Get<IReader<OrderModel>>();
                          var orderModelsList = reader.Read();
                          Orders = new ObservableCollection<OrderViewModel>(orderModelsList.Select(o => new OrderViewModel(o)));
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
       
    }

   }

