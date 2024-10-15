namespace Fire_Emblem_Models.EffectsFolder;

public class SandstormEffect : Effect
{
    private Unit _unit;
    public override void Apply(Unit unit)
    {
        _unit = unit;
        int defBaseStat = unit.Stats.GetStat("Def").BaseStat;
        int atkBaseStat = unit.Stats.GetStat("Atk").BaseStat;
        int atkModification = (int)Math.Truncate(1.5 * defBaseStat) - atkBaseStat;
        AddSandstormModification("Atk", atkModification);
    }
    
    public void AddSandstormModification(string stat, int modification)
    {
        if (modification > 0)
        {
            _unit.Stats.ModifyFollowUpBonuses(stat, modification);
        }
        else
        {
            _unit.Stats.ModifyFollowUpPenalties(stat, modification);
        }
    }
}