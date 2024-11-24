namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageReductionPercentage;

public class DamageReductionPercentageFirstAttackEffect : Effect
{
    private double _percentage;

    public DamageReductionPercentageFirstAttackEffect(double percentage)
    {
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        unit.DamageEffects.IncreaseFirstAttackPercentageDamageReduction(_percentage);
    }
}