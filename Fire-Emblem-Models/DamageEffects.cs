namespace Fire_Emblem_Models;

public class DamageEffects
{
    public int DamageBonus = 0;
    public int PercentageDamageReduction = 1;
    public int DamageReduction = 0;

    // Separar...?
    public int CalculateModifiedDamage(int damage)
    {
        return (damage + DamageBonus) * PercentageDamageReduction - DamageReduction;
    }

    public void ResetDamageEffects()
    {
        DamageBonus = 0;
        PercentageDamageReduction = 1;
        DamageReduction = 0;
    }
}