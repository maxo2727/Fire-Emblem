using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class PenaltyRivalFirstAttackPercentageEffect : Effect
{
    private string _stat;
    private double _percentage;

    public PenaltyRivalFirstAttackPercentageEffect(string stat, double percentage)
    {
        _stat = stat;
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        int penalty = -(int)Math.Truncate(rival.Stats.GetStat(_stat).BaseStat * _percentage);
        rival.Stats.ModifyFirstAttackPenalties(_stat, penalty);
    }
}