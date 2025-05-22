public abstract class AttackUnit  
{
    public string Name;  
    public int AmmoCapacity; 
    public int FuelLevel;
    public List<string> EffectiveAgainst = new List<string>(); 


    public Dictionary<string, int> EffectivenessPerLocation = new Dictionary<string, int>();

    public bool CanAttack(string targetType)
    {
        foreach (string type in EffectiveAgainst)
        {
            if (type == targetType)
            {
                return true;
            }
        }
        return false;
    }


    public void UseAmmo()
    {
        if (AmmoCapacity > 0)
        {
            AmmoCapacity--;
        }
        else
        {
            Console.WriteLine("No ammo left!");
        }
    }

    public abstract void Attack(Terrorist target);

    public int GetEffectiveness(string location)
    {
        if (EffectivenessPerLocation.TryGetValue(location, out int effectiveness))
        {
            return effectiveness;
        }
        return 0;
    }
}
