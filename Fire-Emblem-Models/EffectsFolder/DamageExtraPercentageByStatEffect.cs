using Fire_Emblem_Models.Functions;

namespace Fire_Emblem_Models.EffectsFolder;

public class DamageExtraPercentageByStatEffect : Effect
{
    private string _stat;
    private double _percentage;

    public DamageExtraPercentageByStatEffect(string stat, double percentage)
    {
        _stat = stat;
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        int statValue = unit.Stats.GetStat(_stat).GetStatWithBaseEffects();
        double extraDamage = statValue * _percentage;
        int truncatedExtraDamage = TrueTruncator.Truncate(extraDamage);
        unit.DamageEffects.BaseDamageBonus += truncatedExtraDamage;
    }
}