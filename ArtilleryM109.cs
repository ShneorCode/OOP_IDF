using System;
using System.Collections.Generic;

public class ArtilleryM109 : AttackUnit
{
    public string SerialNumber;
    public List<string> BombTypes = new List<string> { "HE-Shell" };

    public int AmmoCapacity = 40;



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
        if (AmmoCapacity <= 0)
        {
            Console.WriteLine($"{Name} has no ammo left!");
            return;
        }
        UseAmmo();
        Console.WriteLine($"Artillery {SerialNumber} attacked terrorist {target.Name} at {target.Location} with {BombTypes[0]} shell.");
        target.Status = "Dead";
    }


}
