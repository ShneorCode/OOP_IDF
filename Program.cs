using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("IDF Operation – First Strike");
        Console.WriteLine($"Startup Time: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");

        // Initialize
        SimulationInitializer initializer = new SimulationInitializer();

        List<Terrorist> terrorists = initializer.CreateRandomTerrorists(5);
        IDF idf = initializer.InitializeIDF();
        List<IntelReport> reports = initializer.CreateRandomIntelReports(terrorists);

        Aman aman = new Aman();
        aman.Reports = reports;

        // Commander name
        Console.Write("Enter Officer Name: ");
        string officerName = Console.ReadLine();

        // Start console
        CommanderConsole console = new CommanderConsole(idf, aman, terrorists, officerName);
        console.ShowMenuLoop();
    }
}
