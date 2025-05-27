using System;

public class Terrorist
{

    public string Name;
    public int Rank;
    public string Status;
    public List<string> Weapons = new List<string>();
    public string Location { get; set; }
    public int CalculateThreatScore()
    {
        int weaponPoints = 0;

        foreach (string weapon in Weapons)
        {
            if (weapon == "Knife")
                weaponPoints += 1;
            else if (weapon == "Pistol")
                weaponPoints += 2;
            else if (weapon == "M16" || weapon == "AK47")
                weaponPoints += 3;
        }

        return Rank * weaponPoints;
    }







}


