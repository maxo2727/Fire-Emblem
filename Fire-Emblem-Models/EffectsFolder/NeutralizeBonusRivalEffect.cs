namespace Fire_Emblem_Models.EffectsFolder;

public class NeutralizeBonusRivalEffect : Effect
{
    private string _stat;

    public NeutralizeBonusRivalEffect(string stat)
    {
        _stat = stat;
    }

    public override void Apply(Unit unit)
    {
        Unit rival = unit.Rival;
        rival.Stats.GetStat(_stat).AreBonusesNeutralized = true;
    }
}