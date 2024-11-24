using Fire_Emblem_Models.Functions;
using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models.EffectsFolder.BonusEffects;

public class BonusEffectPercentageOfStat : Effect
{
    private string _targetStatName;
    private double _percentage;
    private string _statNameWhereBonusIsCalculatedFrom;

    public BonusEffectPercentageOfStat(string targetStatName, double percentage, string statNameWhereBonusIsCalculatedFrom)
    {
        _targetStatName = targetStatName;
        _percentage = percentage;
        _statNameWhereBonusIsCalculatedFrom = statNameWhereBonusIsCalculatedFrom;
    }

    public override void Apply(Unit unit)
    {
        Stat statWhereBonusIsCalculatedFrom = unit.Stats.GetStat(_statNameWhereBonusIsCalculatedFrom);
        int statValueWhereBonusIsCalculatedFrom = statWhereBonusIsCalculatedFrom.BaseStat;
        double bonus = statValueWhereBonusIsCalculatedFrom * _percentage;
        int truncatedBonus = TrueTruncator.Truncate(bonus);
        Stat targetStat = unit.Stats.GetStat(_targetStatName);
        targetStat.Bonus += truncatedBonus;
    }
}