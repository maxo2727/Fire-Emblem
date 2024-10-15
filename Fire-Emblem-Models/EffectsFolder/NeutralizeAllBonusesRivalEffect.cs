using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models.EffectsFolder;

public class NeutralizeAllBonusesRivalEffect : Effect
{
    public override void Apply(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        foreach (Stat stat in rival.Stats.GetStatValues())
        {
            stat.AreBonusesNeutralized = true;
        }
    }
}