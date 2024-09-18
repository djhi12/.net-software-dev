// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        // Define paths
        string directoryPath = "SalesData";
        string salesFilePath = Path.Combine(directoryPath, "sales.txt");
        string reportFilePath = Path.Combine(directoryPath, "SalesSummaryReport.txt");

        try
        {
            // Create directory if it doesn't exist
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"Directory '{directoryPath}' created.");
            }

            // Create and write to the sales file
            var salesData = new List<decimal> { 123.45m, 678.90m, 234.56m, 789.01m };
            File.WriteAllLines(salesFilePath, salesData.Select(s => s.ToString("C")));
            Console.WriteLine($"Sales file '{salesFilePath}' created.");

            // Generate sales summary report
            GenerateSalesSummaryReport(salesFilePath, reportFilePath);

            // Read and display the report
            var reportContent = File.ReadAllText(reportFilePath);
            Console.WriteLine($"Report content:\n{reportContent}");

            // Cleanup: Delete files and directory
            File.Delete(salesFilePath);
            File.Delete(reportFilePath);
            Directory.Delete(directoryPath);
            Console.WriteLine($"Files and directory deleted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void GenerateSalesSummaryReport(string salesFilePath, string reportFilePath)
    {
        // Read all lines from the sales file
        var salesLines = File.ReadAllLines(salesFilePath);

        // Convert the sales lines to decimal values
        var salesAmounts = salesLines.Select(line => decimal.Parse(line, System.Globalization.NumberStyles.Currency)).ToList();

        // Calculate the total sales
        var totalSales = salesAmounts.Sum();

        // Build the report using StringBuilder
        var reportBuilder = new StringBuilder();
        reportBuilder.AppendLine("Sales Summary");
        reportBuilder.AppendLine(new string('-', 30));
        reportBuilder.AppendLine($"Total Sales: {totalSales.ToString("C")}");
        reportBuilder.AppendLine("Details:");

        foreach (var sale in salesAmounts)
        {
            reportBuilder.AppendLine($"- {sale.ToString("C")}");
        }

        // Write the report to the file
        File.WriteAllText(reportFilePath, reportBuilder.ToString());
    }
}
