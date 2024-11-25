using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces
{
    /// <summary>
    /// Interface Publica de ITrade 
    /// Contem, Valor da transação, o setor do cliente,e a data do próximo pagamento
    /// 
    /// Campo IsPoliticallyExposed é do segundo exercicio !
    /// </summary>
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime DateNextPayment { get; }
        bool IsPoliticallyExposed { get; } 

    }
}
