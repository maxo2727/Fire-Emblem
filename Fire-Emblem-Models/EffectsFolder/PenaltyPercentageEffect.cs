using Fire_Emblem_Models.Functions;
using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models.EffectsFolder;

public class PenaltyPercentageEffect : Effect
{
    private string _stat;
    private double _percentage;

    public PenaltyPercentageEffect(string stat, double percentage)
    {
        _stat = stat;
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        Stat stat = unit.Stats.GetStat(_stat);
        double penalty = stat.BaseStat * _percentage;
        int truncatedPenalty = TrueTruncator.Truncate(penalty);
        stat.Penalty -= truncatedPenalty;
    }
}