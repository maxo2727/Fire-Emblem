using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class PenaltyEffect : Effect
{
    private string _stat;
    private int _penalty;

    public PenaltyEffect(string stat, int penalty)
    {
        _stat = stat;
        _penalty = penalty;
    }

    public override void Apply(Unit unit)
    {
        unit.ModifyPenalties(_stat, _penalty);
    }
}