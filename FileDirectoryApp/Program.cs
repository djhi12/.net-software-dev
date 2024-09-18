using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Define paths
        string directoryPath = "SampleDirectory";
        string filePath = Path.Combine(directoryPath, "SampleFile.txt");

        try
        {
            // Create a directory
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"Directory '{directoryPath}' created.");
            }

            // Create and write to a file
            File.WriteAllText(filePath, "Hello, this is a sample text.");
            Console.WriteLine($"File '{filePath}' created and text written.");

            // Read from the file
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine($"Content of the file: {fileContent}");

            // Delete the file
            File.Delete(filePath);
            Console.WriteLine($"File '{filePath}' deleted.");

            // Delete the directory
            Directory.Delete(directoryPath);
            Console.WriteLine($"Directory '{directoryPath}' deleted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
