namespace Fire_Emblem_Models.EffectsFolder;

public class DamageReductionPercentageEffect : Effect
{
    private double _percentage;

    public DamageReductionPercentageEffect(double percentage)
    {
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        unit.DamageEffects.IncreaseBasePercentageDamageReduction(_percentage);
    }
}