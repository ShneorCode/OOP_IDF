using System;
using System.Collections.Generic;

public class Aman
{
    public List<IntelReport> Reports = new List<IntelReport>();
    private static Random rnd = new Random();
    private static string[] Locations = { "house", "car", "open area" };

    public void GenerateRandomReports(List<Terrorist> targets)
    {
        foreach (var terrorist in targets)
        {
            int numberOfReports = rnd.Next(1, 4);
            for (int i = 0; i < numberOfReports; i++)
            {
                string location = Locations[rnd.Next(Locations.Length)];
                DateTime timestamp = DateTime.Now.AddMinutes(-rnd.Next(60));

                IntelReport report = new IntelReport(terrorist.Name, location, timestamp);
                Reports.Add(report);
            }
        }
    }

    public Terrorist GetMostReportedTerrorist(List<Terrorist> terrorists)
    {
        Dictionary<string, int> counts = new Dictionary<string, int>();

        foreach (var report in Reports)
        {
            if (!counts.ContainsKey(report.TerroristName))
                counts[report.TerroristName] = 0;

            counts[report.TerroristName]++;
        }

        string mostReportedName = null;
        int maxCount = -1;

        foreach (var pair in counts)
        {
            if (pair.Value > maxCount)
            {
                maxCount = pair.Value;
                mostReportedName = pair.Key;
            }
        }

        foreach (var terrorist in terrorists)
        {
            if (terrorist.Name == mostReportedName)
                return terrorist;
        }

        return null;
    }

    public IntelReport GetLatestReportForTerrorist(string name)
    {
        IntelReport latest = null;

        foreach (var report in Reports)
        {
            if (report.TerroristName == name)
            {
                if (latest == null || report.Timestamp > latest.Timestamp)
                    latest = report;
            }
        }

        return latest;
    }
}
