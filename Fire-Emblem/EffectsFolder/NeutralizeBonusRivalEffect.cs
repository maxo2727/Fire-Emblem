using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class NeutralizeBonusRivalEffect : Effect
{
    private string _stat;

    public NeutralizeBonusRivalEffect(string stat)
    {
        _stat = stat;
    }

    public override void Apply(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        rival.Stats[_stat].AreBonusesNeutralized = true;
    }
}