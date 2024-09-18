using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Example sales records
        List<SalesRecord> salesRecords = new List<SalesRecord>
        {
            new SalesRecord { Filename = "sale1.txt", Amount = 1500.00m },
            new SalesRecord { Filename = "sale2.txt", Amount = 2500.00m },
            new SalesRecord { Filename = "sale3.txt", Amount = 500.00m }
        };

        // Define output file path
        string reportPath = "SalesSummaryReport.txt";

        // Generate the sales summary report
        GenerateSalesSummaryReport(salesRecords, reportPath);
    }

    public static void GenerateSalesSummaryReport(List<SalesRecord> salesRecords, string outputPath)
    {
        // Calculate total sales
        decimal totalSales = 0;
        foreach (var record in salesRecords)
        {
            totalSales += record.Amount;
        }

        // Use StringBuilder to build the report
        StringBuilder reportBuilder = new StringBuilder();
        reportBuilder.AppendLine("Sales Summary");
        reportBuilder.AppendLine("----------------------------");
        reportBuilder.AppendLine();
        reportBuilder.AppendLine($"Total Sales: {totalSales.ToString("C")}");
        reportBuilder.AppendLine();
        reportBuilder.AppendLine("Details:");

        // Add each sales record detail
        foreach (var record in salesRecords)
        {
            reportBuilder.AppendLine($"Filename: {record.Filename} - Amount: {record.Amount.ToString("C")}");
        }

        // Write the report to a file
        File.WriteAllText(outputPath, reportBuilder.ToString());

        Console.WriteLine("Sales summary report generated successfully.");
    }
}
