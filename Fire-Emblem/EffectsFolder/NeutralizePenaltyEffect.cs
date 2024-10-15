using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class NeutralizePenaltyEffect : Effect
{
    private string _stat;

    public NeutralizePenaltyEffect(string stat)
    {
        _stat = stat;
    }

    public override void Apply(Unit unit)
    {
        unit.Stats.GetStat(_stat).ArePenaltiesNeutralized = true;
    }
}