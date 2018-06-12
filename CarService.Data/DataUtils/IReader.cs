

using System.Collections.Generic;

namespace CarService.Data.DataUtils
{
    public interface IReader<T> where T : class 
    {
        IEnumerable<T> Read();
    }
}
