using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application.Interfaces;
using static application.Domain.Rules;

namespace application.Domain
{
    /// <summary>
    /// Classe que categoriza o trade baseado na lista de regras
    /// </summary>
    public class CategorizerOfTrade
    {

        private readonly List<ICategory> _rules;

        /// <summary>
        /// Construtor
        /// </summary>
        public CategorizerOfTrade()
        {
            _rules = new List<ICategory>();
        }

        /// <summary>
        /// Adicionar a regra na lista de regras
        /// </summary>
        /// <param name="rule"></param>
        public void AddRule(ICategory rule)
        {
            _rules.Add(rule);
        }

        /// <summary>
        /// Método que categoriza ! Esse método recebe uma lista de regras, e a cada item da lista ele vai realizar a classificação
        /// 
        /// Como temos outra regra para pep, eu priorizo ela primeiro.
        /// </summary>
        /// <param name="trade"></param>
        /// <param name="referenceDate"></param>
        /// <returns></returns>
        public string Categorize(ITrade trade, DateTime referenceDate)
        {
            if(trade.IsPoliticallyExposed == true)
            {
                var pepCategory = new PEPCategory().Classification(trade, referenceDate);
                if (!string.IsNullOrEmpty(pepCategory))
                {
                    return pepCategory;
                }
            }
         
            foreach (var rule in _rules)
            {
                string category = rule.Classification(trade, referenceDate);
                if (!string.IsNullOrEmpty(category))
                {
                    return category;
                }
            }
            return string.Empty;
        }
    }

}
