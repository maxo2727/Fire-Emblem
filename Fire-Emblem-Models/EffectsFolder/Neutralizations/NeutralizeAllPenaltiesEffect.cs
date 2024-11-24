using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models.EffectsFolder.Neutralizations;

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