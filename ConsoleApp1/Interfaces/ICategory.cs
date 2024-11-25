using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces
{
    /// <summary>
    /// Interface das categorias, podemos ter uma ou várias
    /// </summary>
    public interface ICategory
    {
        string Classification(ITrade trade, DateTime referenceDate);
    }
}
