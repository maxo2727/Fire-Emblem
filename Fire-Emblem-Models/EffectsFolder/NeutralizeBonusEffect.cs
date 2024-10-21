namespace Fire_Emblem_Models.EffectsFolder;

public class NeutralizeBonusEffect : Effect
{
    private string _stat;

    public NeutralizeBonusEffect(string stat)
    {
        _stat = stat;
    }

    public override void Apply(Unit unit)
    {
        unit.Stats.GetStat(_stat).AreBonusesNeutralized = true;
    }
}