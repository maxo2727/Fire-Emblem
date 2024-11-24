using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models.EffectsFolder.Neutralizations;

public class NeutralizeAllBonusesRivalEffect : Effect
{
    public override void Apply(Unit unit)
    {
        Unit rival = unit.Rival;
        foreach (Stat stat in rival.Stats.GetStatValues())
        {
            stat.AreBonusesNeutralized = true;
        }
    }
}