using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using application.Interfaces;

namespace application.Domain
{
    /// <summary>
    /// Classe com as regras
    /// </summary>
    public class Rules
    {
        /// <summary>
        /// EXPIRADO: Negociações cuja próxima data de pagamento esteja atrasada em mais de 30 dias com base em uma data de referência que
        /// ser dado.
        /// </summary>
        public class ExpiredCategory : ICategory
        {
            public string Classification(ITrade trade, DateTime referenceDate)
            {
                if ((referenceDate - trade.DateNextPayment).TotalDays > 30)
                {
                    return "EXPIRED";
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 2. ALTO RISCO: Negociações com valor superior a 1.000.000 e cliente do Setor Privado.
        /// </summary>
        public class HighRiskCategory : ICategory
        {
            public string Classification(ITrade trade, DateTime referenceDate)
            {
                if (trade.Value > 1000000 && trade.ClientSector == "Private")
                {
                    return "HIGHRISK";
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 3. MÉDIO RISCO: Negociações com valor superior a 1.000.000 e cliente do Setor Público.
        /// </summary>
        public class MediumRiskCategory : ICategory
        {
            public string Classification(ITrade trade, DateTime referenceDate)
            {
                if (trade.Value > 1000000 && trade.ClientSector == "Public")
                {
                    return "MEDIUMRISK";
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Segundo exercicio !
        /// Está politicamente exposto ? 
        /// </summary>
        public class PEPCategory : ICategory
        {
            public string Classification(ITrade trade, DateTime referenceDate)
            {
                if (trade.IsPoliticallyExposed)
                {
                    return "PEP";
                }
                return string.Empty;
            }
        }
    }
}
