using FlujoAsincrono;
using System.Diagnostics;

Stopwatch sw = new Stopwatch();
sw.Start();
Console.WriteLine("\n************************************************");
Console.WriteLine("\nBienvenido a la calculadora de hipoteca sincrona");
Console.WriteLine("\n************************************************");

var yearsJob = CalculadoraHipoteticaSync.GetYearsJob();
Console.WriteLine($"\nAños de vida laboral obtenidos: {yearsJob}");

var contracUndefined = CalculadoraHipoteticaSync.GetContractJobUndefined();
Console.WriteLine($"\nTipo de contrato indefinido: {contracUndefined}");

var salary = CalculadoraHipoteticaSync.GetSalaryJob();
Console.WriteLine($"\nSueldo neto obtenido: {salary}");

var costMonthly = CalculadoraHipoteticaSync.GetCostsMonthly();
Console.WriteLine($"\nGastos mensuales obtenidos: {costMonthly}");

var hipotecaconcedida = CalculadoraHipoteticaSync.AnalizarInfoParaHipoteca(yearsJob,
            contracUndefined,
            salary,
            costMonthly,
            solicitated: 50000,
            yearOfPay: 30);
var resultado = hipotecaconcedida ? "Aprobada" : "Denegada";
Console.WriteLine($"\nAnalisis finalizado. su solicitud a sido: {resultado}");

sw.Stop();
Console.WriteLine($"\nLa operacio a durado: {sw.Elapsed}");

sw.Restart();

Console.WriteLine("\n*************************************************");
Console.WriteLine("\nBienvenido a la calculadora de hipoteca Asincrona");
Console.WriteLine("\n*************************************************");

Task<int> yearsJobTaks = CalculadoraHipotecaAsync.GetYearsJob();
Task<bool> contracUndefinedTaks = CalculadoraHipotecaAsync.GetContractJobUndefined();
Task<int> salaryTaks = CalculadoraHipotecaAsync.GetSalaryJob();
Task<int> costMonthlyTaks = CalculadoraHipotecaAsync.GetCostsMonthly();

var analisisHipotecaTask = new List<Task>
{
    yearsJobTaks, contracUndefinedTaks, salaryTaks, costMonthlyTaks
};

while (analisisHipotecaTask.Any())
{
    Task tareaFinalizada = await Task.WhenAny(analisisHipotecaTask);

    if(tareaFinalizada == yearsJobTaks)
    {
        Console.WriteLine($"\nAños de vida laboral obtenidos: {yearsJobTaks.Result}");
    }
    else if (tareaFinalizada == contracUndefinedTaks)
    {
        Console.WriteLine($"\nTipo de contrato indefinido: {contracUndefinedTaks.Result}");
    }
    else if (tareaFinalizada == salaryTaks)
    {
        Console.WriteLine($"\nSueldo neto obtenido: {salaryTaks.Result}");
    }
    else if (tareaFinalizada == costMonthlyTaks)
    {
        Console.WriteLine($"\nGastos mensuales obtenidos: {costMonthlyTaks.Result}");
    }
    analisisHipotecaTask.Remove(tareaFinalizada);
}

var hipotecaconcedidaAsync = CalculadoraHipotecaAsync.AnalizarInfoParaHipoteca(yearsJobTaks.Result,
            contracUndefinedTaks.Result,
            salaryTaks.Result,
            costMonthlyTaks.Result,
            solicitated: 50000,
            yearOfPay: 30);

var resultadoAsync = hipotecaconcedidaAsync ? "Aprobada" : "Denegada";
Console.WriteLine($"\nAnalisis finalizado. su solicitud a sido: {resultadoAsync}");

sw.Stop();
Console.WriteLine($"\nLa operacio ASYNC a durado: {sw.Elapsed}");