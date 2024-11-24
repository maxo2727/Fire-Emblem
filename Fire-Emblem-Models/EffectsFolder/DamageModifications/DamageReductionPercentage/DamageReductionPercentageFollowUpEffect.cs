namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageReductionPercentage;

public class DamageReductionPercentageFollowUpEffect : Effect
{
    private double _percentage;

    public DamageReductionPercentageFollowUpEffect(double percentage)
    {
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        unit.DamageEffects.IncreaseFollowUpPercentageDamageReduction(_percentage);
    }
}