namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageExtra;

public class DamageExtraHPPercentageEffect : Effect
{
    private double _percentage;

    public DamageExtraHPPercentageEffect(double percentage)
    {
        _percentage = percentage;
    }

    // Use TrueTruncator?
    public override void Apply(Unit unit)
    {
        double extraDamage = unit.Hp.GetLostHP() * _percentage;
        double roundedExtraDamage = Math.Round(extraDamage, 9);
        int truncatedExtraDamage = (int)Math.Floor(roundedExtraDamage);
        unit.DamageEffects.BaseDamageBonus += truncatedExtraDamage;
    }
}