using CarServiceViewModel;
using System.Windows;

namespace CarServiceView
{
   
    public partial class UserControl1 : Window
    {
        public UserControl1()
        {
            InitializeComponent();
            DataContext = new CarServViewModel();
        }
    }
}
