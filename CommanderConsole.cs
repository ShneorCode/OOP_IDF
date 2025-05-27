using System;
using System.Collections.Generic;

public class CommanderConsole
{
    private IDF idf;
    private Aman aman;
    private List<Terrorist> terrorists;
    private string officerName;
    private List<StrikeLogEntry> strikeLog = new List<StrikeLogEntry>();

    public CommanderConsole(IDF idf, Aman aman, List<Terrorist> terrorists, string officerName)
    {
        this.idf = idf;
        this.aman = aman;
        this.terrorists = terrorists;
        this.officerName = officerName;
    }

    public void ShowMenuLoop()
    {
        while (true)
        {
            Console.WriteLine("\n--- Commander Menu ---");
            Console.WriteLine("1. Show Available Intel Reports");
            Console.WriteLine("2. Show Available Attack Units");
            Console.WriteLine("3. Execute Strike");
            Console.WriteLine("4. Show Strike Log");
            Console.WriteLine("5. Show Prioritized Targets");
            Console.WriteLine("6. Show Most Reported Terrorist");
            Console.WriteLine("0. Exit");

            string choice = Console.ReadLine();

            if (choice == "0") break;
            else if (choice == "1") AnalyzeIntel();
            else if (choice == "2") ShowAvailableUnits();
            else if (choice == "3") ExecuteStrike();
            else if (choice == "4") ShowStrikeLog();
            else if (choice == "5") ShowPrioritizedTargets();
            else if (choice == "6") ShowMostReportedTerrorist();
            else Console.WriteLine("Invalid option.");
        }
    }

    private void ExecuteStrike()
    {
        Console.WriteLine("\n--- Execute Strike ---");
        Console.Write("Enter terrorist name: ");
        string name = Console.ReadLine();

        Terrorist target = terrorists.Find(t => t.Name == name);
        if (target == null)
        {
            Console.WriteLine("Terrorist not found.");
            return;
        }

        IntelReport latestReport = aman.GetLatestReportForTerrorist(name);



        if (latestReport == null)
        {
            Console.WriteLine("No available intel on this terrorist.");
            return;
        }

        string location = latestReport.LastKnownLocation;

        AttackUnit selectedUnit = null;
        int highestEffectiveness = -1;

        selectedUnit = null;

        foreach (var unit in idf.AttackUnits)
        {
            if (unit.AmmoCapacity > 0 && unit.EffectiveAgainst.Contains(location))
            {
                selectedUnit = unit;
                break;  
            }
        }


        if (selectedUnit == null)
        {
            Console.WriteLine("No available unit with effectiveness in this location.");
            return;
        }

        selectedUnit.Attack(target);

        strikeLog.Add(new StrikeLogEntry
        {
            Time = DateTime.Now,
            TargetName = target.Name,
            UnitName = selectedUnit.Name,
            Location = latestReport.LastKnownLocation
        });

        Console.WriteLine("\n--- Strike Executed ---");
        Console.WriteLine($"Time: {DateTime.Now}");
        Console.WriteLine($"Target: {target.Name}");
        Console.WriteLine($"Unit: {selectedUnit.Name}");
        Console.WriteLine($"Officer: {officerName}");
        Console.WriteLine($"Location: {latestReport.LastKnownLocation}");
        Console.WriteLine($"Remaining Ammo: {selectedUnit.AmmoCapacity}");
    }

    private void ShowStrikeLog()
    {
        Console.WriteLine("\n--- Strike Log ---");
        if (strikeLog.Count == 0)
        {
            Console.WriteLine("No strikes executed yet.");
            return;
        }

        foreach (var entry in strikeLog)
        {
            Console.WriteLine($"{entry.Time}: {entry.UnitName} struck {entry.TargetName} at {entry.Location}");
        }
    }

    private void AnalyzeIntel()
    {
        Console.WriteLine("\n--- Intel Reports ---");
        foreach (IntelReport report in aman.Reports)
        {
            Console.WriteLine($"Name: {report.TerroristName}, Location: {report.LastKnownLocation}, Time: {report.Timestamp}");
        }
    }

    private void ShowMostReportedTerrorist()
    {
        Terrorist t = aman.GetMostReportedTerrorist(terrorists);
        if (t == null)
        {
            Console.WriteLine("No reports found.");
            return;
        }

        Console.WriteLine("\n--- Most Reported Terrorist ---");
        Console.WriteLine($"Name: {t.Name}, Rank: {t.Rank}, Status: {t.Status}");
    }

    private void ShowAvailableUnits()
    {
        Console.WriteLine("\n--- Available Attack Units ---");
        foreach (var unit in idf.AttackUnits)
        {
            Console.WriteLine($"{unit.Name} | Ammo: {unit.AmmoCapacity} | Effective Against: {string.Join(", ", unit.EffectiveAgainst)}");
        }
    }

    private void ShowPrioritizedTargets()
    {
        Console.WriteLine("\n--- Target Prioritization ---");

        foreach (Terrorist t in terrorists)
        {
            int score = t.CalculateThreatScore();
            IntelReport latest = aman.GetLatestReportForTerrorist(t.Name);

            Console.WriteLine($"Name: {t.Name}, Rank: {t.Rank}, Threat Score: {score}");
            Console.WriteLine($"Weapons: {string.Join(", ", t.Weapons)}");
            Console.WriteLine($"Last Known Location: {(latest != null ? latest.LastKnownLocation : "Unknown")}");
            Console.WriteLine("---");
        }
    }
}
