using System;
using System.Collections.Generic;

public class IDF
{
    public string DateEstablished;
    public string CurrentCommander;
    public List<AttackUnit> AttackUnits = new List<AttackUnit>();

    public IDF(string dateEstablished, string currentCommander)
    {
        DateEstablished = dateEstablished;
        CurrentCommander = currentCommander;
    }

    public void ShowAvailableUnits()
    {
        Console.WriteLine("Available Attack Units: ");
        foreach (var unit in AttackUnits) 
        {
            Console.WriteLine($"- {unit.Name} | Ammo: {unit.AmmoCapacity} | Fuel: {unit.FuelLevel}");
        }
    }


}
