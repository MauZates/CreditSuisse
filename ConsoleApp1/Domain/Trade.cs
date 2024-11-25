using application.Interfaces;

namespace application.Domain
{
    /// <summary>
    /// CLasse de Trade que herda a interface de Itrade
    /// Contem, Valor da transação, o setor do cliente,e a data do próximo pagamento
    /// 
    /// Campo IsPoliticallyExposed é do segundo exercicio !
    /// </summary>
    public class Trade : ITrade
    {
        public double Value { get; private set; }
        public string ClientSector { get; private set; }
        public DateTime DateNextPayment { get; private set; }
        public bool IsPoliticallyExposed { get; set; }



        /// <summary>
        /// Construtor de Trade
        /// </summary>
        /// <param name="value">Valor da Transação</param>
        /// <param name="clientSector"> o setor do cliente</param>
        /// <param name="nextPaymentDate">Data do próximo pagamento</param>
        /// <param name="isPoliticallyExposed">Politicamente exposto ! Do segundo exercício</param>
        public Trade(double value, string clientSector, DateTime dateNextPayment, bool isPoliticallyExposed)
        {
            Value = value;
            ClientSector = clientSector;
            DateNextPayment = dateNextPayment;
            IsPoliticallyExposed = isPoliticallyExposed;
        }
    }
}