using System;
using System.Collections.Generic;

public class SimulationInitializer
{
    private Random random = new Random();

    public List<Terrorist> CreateRandomTerrorists(int count)
    {
        List<Terrorist> terrorists = new List<Terrorist>();
        string[] possibleWeapons = { "Knife", "Pistol", "M16", "AK47" };

        for (int i = 0; i < count; i++)
        {
            Terrorist t = new Terrorist();
            t.Name = "Terrorist_" + (i + 1);
            t.Rank = random.Next(1, 6); 
            t.Status = "Alive";

            int weaponCount = random.Next(1, 4); 
            for (int j = 0; j < weaponCount; j++)
            {
                string weapon = possibleWeapons[random.Next(possibleWeapons.Length)];
                if (!t.Weapons.Contains(weapon))
                {
                    t.Weapons.Add(weapon);
                }
            }

            terrorists.Add(t);
        }

        return terrorists;
    }

    public IDF InitializeIDF()
    {
        IDF idf = new IDF("1948", "General X");

        idf.AttackUnits = new List<AttackUnit>();

        var f16 = new F16FighterJet("F16-Alpha", "F16-001");
        idf.AttackUnits.Add(f16);


        AttackUnit drone = new HermesDrone("Hermes-Zik", "12345");
        idf.AttackUnits.Add(drone);

        idf.AttackUnits.Add(new ArtilleryM109
        {
            Name = "Artillery-Cannon",
            AmmoCapacity = 40,
            FuelLevel = 70,
            EffectiveAgainst = new List<string> { "open area" },
            MaxTargetsPerShot = 3,
            SerialNumber = "ART-109"
        });

        return idf;
    }

    public List<IntelReport> CreateRandomIntelReports(List<Terrorist> terrorists)
    {
        List<IntelReport> reports = new List<IntelReport>();
        string[] locations = { "house", "car", "open area" };

        int reportCount = random.Next(10, 21); 

        for (int i = 0; i < reportCount; i++)
        {
            Terrorist t = terrorists[random.Next(terrorists.Count)];
            string location = locations[random.Next(locations.Length)];
            DateTime timestamp = DateTime.Now.AddMinutes(-random.Next(60)); 

            IntelReport report = new IntelReport(t.Name, location, timestamp);
            reports.Add(report);
        }

        return reports;
    }
}
