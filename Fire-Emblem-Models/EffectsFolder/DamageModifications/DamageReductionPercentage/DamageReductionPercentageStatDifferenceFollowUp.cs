namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageReductionPercentage;

public class DamageReductionPercentageStatDifferenceFollowUp : DamageReductionPercentageStatDifference
{
    public DamageReductionPercentageStatDifferenceFollowUp(string stat, int ponderation) : base(stat, ponderation) {}

    protected override void ApplyDamageReduction(Unit unit, double damageReduction)
    {
        unit.DamageEffects.IncreaseFollowUpPercentageDamageReduction(damageReduction);
    }
}