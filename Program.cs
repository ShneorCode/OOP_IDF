using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to IDF Operation – First Strike");
        Console.WriteLine($"Startup Time: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");

        // Initialize
        SimulationInitializer initializer = new SimulationInitializer();

        List<Terrorist> terrorists = initializer.CreateRandomTerrorists(5);
        IDF idf = initializer.InitializeIDF();

        Aman aman = new Aman();
        aman.GenerateRandomReports(terrorists);

        List<IntelReport> reports = aman.Reports;

        // Commander name
        Console.Write("Enter Officer Name: ");
        string officerName = Console.ReadLine();

        // Start console
        CommanderConsole console = new CommanderConsole(idf, aman, terrorists, officerName);
        console.ShowMenuLoop();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
