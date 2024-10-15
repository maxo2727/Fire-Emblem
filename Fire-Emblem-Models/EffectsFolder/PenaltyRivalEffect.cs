namespace Fire_Emblem_Models.EffectsFolder;

public class PenaltyRivalEffect : Effect
{
    private string _stat;
    private int _penalty;

    public PenaltyRivalEffect(string stat, int penalty)
    {
        _stat = stat;
        _penalty = penalty;
    }

    public override void Apply(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        rival.Stats.ModifyPenalties(_stat, _penalty);
    }
}