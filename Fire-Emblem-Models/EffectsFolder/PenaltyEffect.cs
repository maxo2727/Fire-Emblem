namespace Fire_Emblem_Models.EffectsFolder;

public class PenaltyEffect : Effect
{
    private string _stat;
    private int _penalty;

    public PenaltyEffect(string stat, int penalty)
    {
        _stat = stat;
        _penalty = penalty;
    }

    public override void Apply(Unit unit)
    {
        unit.Stats.ModifyPenalties(_stat, _penalty);
    }
}