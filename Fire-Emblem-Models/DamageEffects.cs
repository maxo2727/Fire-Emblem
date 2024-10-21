namespace Fire_Emblem_Models;

public class DamageEffects
{
    private int _modifiedDamage;
    
    public int BaseDamageBonus = 0;
    public double BasePercentageDamageReduction = 0;
    public int BaseDamageReduction = 0;

    public int FirstAttackDamageBonus = 0;
    public double FirstAttackPercentageDamageReduction = 0;
    public int FirstAttackDamageReduction = 0;
    
    public int FollowUpDamageBonus = 0;
    public double FollowUpPercentageDamageReduction = 0;
    public int FollowUpDamageReduction = 0;

    // encapsular estar 3 funciones en una, recibiendo el unit.DamageEffect y decorando la condicion
    public void IncreaseBasePercentageDamageReduction(double newReduction)
    {
        BasePercentageDamageReduction = 1 - (1 - BasePercentageDamageReduction) * (1 - newReduction);
    }
    
    public void IncreaseFirstAttackPercentageDamageReduction(double newReduction)
    {
        FirstAttackPercentageDamageReduction = 1 - (1 - FirstAttackPercentageDamageReduction) * (1 - newReduction);
    }

    public void IncreaseFollowUpPercentageDamageReduction(double newReduction)
    {
        FollowUpPercentageDamageReduction = 1 - (1 - FollowUpPercentageDamageReduction) * (1 - newReduction);
    }
    
    public int CalculateModifiedBaseDamage(int damage)
    {
        _modifiedDamage = damage;
        AddDamageBonus(BaseDamageBonus);
        ApplyPercentageDamageReduction(BasePercentageDamageReduction);
        ApplyDamageReduction(BaseDamageReduction);
        return _modifiedDamage;
    }

    public int CalculateModifiedFirstAttackDamage(int damage)
    {
        _modifiedDamage = damage;
        AddDamageBonus(BaseDamageBonus);
        AddDamageBonus(FirstAttackDamageBonus);
        ApplyPercentageDamageReduction(BasePercentageDamageReduction);
        ApplyPercentageDamageReduction(FirstAttackPercentageDamageReduction);
        ApplyDamageReduction(BaseDamageReduction);
        ApplyDamageReduction(FirstAttackDamageReduction);
        return _modifiedDamage;
    }

    public int CalculateModifiedFollowUpDamage(int damage)
    {
        _modifiedDamage = damage;
        AddDamageBonus(BaseDamageBonus);
        AddDamageBonus(FollowUpDamageBonus);
        ApplyPercentageDamageReduction(BasePercentageDamageReduction);
        ApplyPercentageDamageReduction(FollowUpPercentageDamageReduction);
        ApplyDamageReduction(BaseDamageReduction);
        ApplyDamageReduction(FollowUpDamageReduction);
        return _modifiedDamage;
    }

    private void AddDamageBonus(int bonus)
    {
        _modifiedDamage += bonus;
    }
    
    private void ApplyPercentageDamageReduction(double percentageReduction)
    {
        double damage = _modifiedDamage * (1 - percentageReduction);
        double roundedDamage = Math.Round(damage, 9);
        int truncatedDamage = (int)Math.Floor(roundedDamage);
        _modifiedDamage = truncatedDamage;
    }
    
    private void ApplyDamageReduction(int reduction)
    {
        _modifiedDamage -= reduction;
    }

    public void ResetDamageEffects()
    {
        BaseDamageBonus = 0;
        FirstAttackDamageBonus = 0;
        FollowUpDamageBonus = 0;
        BasePercentageDamageReduction = 0;
        FirstAttackPercentageDamageReduction = 0;
        FollowUpPercentageDamageReduction = 0;
        BaseDamageReduction = 0;
        FirstAttackDamageBonus = 0;
        FollowUpDamageReduction = 0;

    }
}