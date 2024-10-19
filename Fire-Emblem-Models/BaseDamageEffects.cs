namespace Fire_Emblem_Models;

public class BaseDamageEffects
{
    public int DamageBonus = 0;
    public double PercentageDamageReduction = 1;
    public int DamageReduction = 0;
    
    // public int CalculateModifiedBaseDamage(int damage)
    // {
    //     _damage = damage;
    //     AddDamageBonus();
    //     ApplyPercentageDamageReduction();
    //     ApplyDamageReduction();
    //     return _damage;
    // }
    //
    // public void AddDamageBonus(int damage)
    // {
    //     damage += DamageBonus;
    // }
    //
    // public void ApplyPercentageDamageReduction(int damage)
    // {
    //     double damage = damage * PercentageDamageReduction;
    //     double roundedDamage = Math.Round(damage, 9);
    //     int truncatedDamage = (int)Math.Floor(roundedDamage);
    // }
    //
    // public void ApplyDamageReduction(int damage)
    // {
    //     damage -= DamageReduction;
    // }
}