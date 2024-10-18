namespace Fire_Emblem_Models.EffectsFolder;

public class DamageExtraPercentageRivalEffect : Effect
{
    private string _stat;
    private double _percentage;

    public DamageExtraPercentageRivalEffect(string stat, double percentage)
    {
        _stat = stat;
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        int statValue = rival.Stats.GetStat(_stat).BaseStat;
        double extraDamage = statValue * _percentage;
        double roundedExtraDamage = Math.Round(extraDamage, 9);
        int truncatedExtraDamage = (int)Math.Floor(roundedExtraDamage);
        unit.DamageEffects.DamageBonus += truncatedExtraDamage;
    }
}