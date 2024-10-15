using Fire_Emblem.StatsFolder;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class NeutralizeAllPenaltiesEffect : Effect
{
    public override void Apply(Unit unit)
    {
        foreach (Stat stat in unit.Stats.GetStatValues())
        {
            stat.ArePenaltiesNeutralized = true;
        }
    }
}