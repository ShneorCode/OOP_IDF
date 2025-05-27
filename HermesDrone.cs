using System;
using System.Collections.Generic;

public class HermesDrone : AttackUnit
{
    public List<string> BombTypes;
    public string SerialNumber;

    public HermesDrone(string name, string serialNumber)
    {
        Name = name;
        SerialNumber = serialNumber;
        AmmoCapacity = 3;
        FuelLevel = 100;
        BombTypes = new List<string> { "Hellfire", "Spike" };
        EffectiveAgainst = new List<string> { "car", "open area" };
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
        Console.WriteLine($"Drone {SerialNumber} attacked terrorist {target.Name} with {BombTypes[0]} missile.");
        target.Status = "Dead";
    }
}
