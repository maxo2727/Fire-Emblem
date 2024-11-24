namespace Fire_Emblem_Models.EffectsFolder;

public class DamageReductionPercentageHPRival : Effect
{
    private double _percentage;

    public DamageReductionPercentageHPRival(double percentage)
    {
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        Unit rival = unit.Rival;
        double HPLeft = (double)unit.Hp.GetCurrentHP() / (double)unit.Hp.GetMaxHP();
        double damageReduction = HPLeft * _percentage;
        double damageReductionRounded = Math.Round(damageReduction, 9);
        int damageReductionTruncated = (int)Math.Truncate(damageReductionRounded * 100);
        unit.DamageEffects.IncreaseBasePercentageDamageReduction(damageReductionTruncated / 100.0);
    }
}