namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageReductionPercentage;

public class DamageReductionPercentageStatDifferenceBase : DamageReductionPercentageStatDifference
{   
    public DamageReductionPercentageStatDifferenceBase(string stat, int ponderation) : base(stat, ponderation) {}
    
    protected override void ApplyDamageReduction(Unit unit, double damageReduction)
    {
        unit.DamageEffects.IncreaseBasePercentageDamageReduction(damageReduction);
    }
}