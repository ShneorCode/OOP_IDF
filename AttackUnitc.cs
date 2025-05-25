public abstract class AttackUnit  
{
    public string Name;  
    public int AmmoCapacity; 
    public int FuelLevel;
    public List<string> EffectiveAgainst = new List<string>();




    public bool CanAttack(string location)
    {
        return EffectiveAgainst.Contains(location);
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


}
