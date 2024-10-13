using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class SandstormEffect : Effect
{
    private Unit _unit;
    public override void Apply(Unit unit)
    {
        _unit = unit;
        int defBaseStat = unit.Stats["Def"].BaseStat;
        int atkBaseStat = unit.Stats["Atk"].BaseStat;
        int atkModification = (int)Math.Truncate(1.5 * defBaseStat) - atkBaseStat;
        AddSandstormModification("Atk", atkModification);
    }
    
    public void AddSandstormModification(string stat, int modification)
    {
        if (modification > 0)
        {
            _unit.ModifyFollowUpBonuses(stat, modification);
        }
        else
        {
            _unit.ModifyFollowUpPenalties(stat, modification);
        }
    }
}