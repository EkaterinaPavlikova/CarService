using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.UI.Utils
{
    public interface IReader<T> where T: class
    {
        ObservableCollection<T> Read();
    }
}
