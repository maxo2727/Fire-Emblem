using Fire_Emblem.StatsFolder;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class NeutralizeAllBonusesRivalEffect : Effect
{
    public override void Apply(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        foreach (Stat stat in rival.Stats.Values)
        {
            stat.AreBonusesNeutralized = true;
        }
    }
}