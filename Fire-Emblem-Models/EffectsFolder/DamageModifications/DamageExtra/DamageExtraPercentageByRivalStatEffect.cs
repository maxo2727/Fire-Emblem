using Fire_Emblem_Models.Functions;

namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageExtra;

public class DamageExtraPercentageByRivalStatEffect : Effect
{
    private string _stat;
    private double _percentage;

    public DamageExtraPercentageByRivalStatEffect(string stat, double percentage)
    {
        _stat = stat;
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        Unit rival = unit.Rival;
        int statValue = rival.Stats.GetStat(_stat).GetStatWithBaseEffects();
        double extraDamage = statValue * _percentage;
        int truncatedExtraDamage = TrueTruncator.Truncate(extraDamage);
        unit.DamageEffects.BaseDamageBonus += truncatedExtraDamage;
    }
}