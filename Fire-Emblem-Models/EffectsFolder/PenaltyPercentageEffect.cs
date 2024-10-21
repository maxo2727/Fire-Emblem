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
        double roundedPenalty = Math.Round(penalty, 9);
        int truncatedPenalty = (int)Math.Floor(roundedPenalty);
        stat.Penalty -= truncatedPenalty;
    }
}