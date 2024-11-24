namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageReductionPercentage;

public class DamageReductionPercentageStatDifferenceFirstAttack : DamageReductionPercentageStatDifference
{
    public DamageReductionPercentageStatDifferenceFirstAttack(string stat, int ponderation) : base(stat, ponderation) {}

    protected override void ApplyDamageReduction(Unit unit, double damageReduction)
    {
        unit.DamageEffects.IncreaseFirstAttackPercentageDamageReduction(damageReduction);
    }
}