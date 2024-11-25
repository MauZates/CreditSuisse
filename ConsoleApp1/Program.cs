using application.Domain;
using application.Interfaces;
using static application.Domain.Rules;
using System.Globalization;

Console.WriteLine("Entre com as datas no seguinte formato MM/DD/YYYY");
DateTime referenceDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", new CultureInfo("en-US"));

Console.WriteLine("Entre com o número de trades");
int n = int.Parse(Console.ReadLine());

List<ITrade> trades = new List<ITrade>();

Console.WriteLine("Entre com o Valor > Setor > Data do próximo pagamento e Se a pessoa é exposta ou não!");
Console.WriteLine("Segue o exemplo > 2000000 Private 12/29/2025 false ");

for (int i = 0; i < n; i++)
{
    var input = Console.ReadLine().Split(' ');
    double value = double.Parse(input[0]);
    string sector = input[1];
    DateTime dateNextPayment = DateTime.ParseExact(input[2], "MM/dd/yyyy", new CultureInfo("en-US"));

    bool politicallyExposed = bool.Parse(input[3]);

    trades.Add(new Trade(value, sector, dateNextPayment, politicallyExposed));
}

// Criação do categorizador
CategorizerOfTrade categorizer = new CategorizerOfTrade();
categorizer.AddRule(new ExpiredCategory());
categorizer.AddRule(new HighRiskCategory());
categorizer.AddRule(new MediumRiskCategory());

Console.WriteLine("Trade categories:");
foreach (var trade in trades)
{
    string category = categorizer.Categorize(trade, referenceDate);
    Console.WriteLine(category);
}

Console.WriteLine("Programa Finalizado");