using System;
using System.Collections.Generic;

public class F16FighterJet : AttackUnit
{
    public List<string> BombTypes;
    public string SerialNumber;

    public F16FighterJet(string name, string serialNumber)
    {
        Name = name;
        SerialNumber = serialNumber;
        AmmoCapacity = 8;
        FuelLevel = 100;
        BombTypes = new List<string> { "0.5", "1" };
        EffectiveAgainst = new List<string> { "house" };

        
    }


    public override void Attack(Terrorist target)
    {


        if (target.Status == "Dead")
        {
            Console.WriteLine($"Target {target.Name} is already dead. No action taken.");
            return;
        }

        if (!CanAttack(target.Location))
        {
            Console.WriteLine($"{Name} is not effective against targets at {target.Location}.");
            return;
        }


        if (AmmoCapacity <= 0)
        {
        Console.WriteLine($"{Name} has no ammo left!");
        return;
        }

        UseAmmo();
        Console.WriteLine($"F-16 Jet {SerialNumber} attacked terrorist {target.Name} at {target.Location} with {BombTypes[0]} bomb.");
        target.Status = "Dead";
    }


}
