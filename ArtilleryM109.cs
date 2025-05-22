using System;
using System.Collections.Generic;

public class ArtilleryM109 : AttackUnit
{
    public int MaxTargetsPerShot;
    public string SerialNumber;

    public override void Attack(Terrorist target)
    {
        throw new NotImplementedException();
    }

    public void Attack(List<Terrorist> targets)
    {
        if (AmmoCapacity <= 0 || targets == null || targets.Count == 0)
            return;

        int actualTargets = Math.Min(MaxTargetsPerShot, targets.Count);
        actualTargets = Math.Min(actualTargets, AmmoCapacity); 
        for (int i = 0; i < actualTargets; i++)
        {
            targets[i].Status = "Dead";
            UseAmmo();
        }
    }
}
