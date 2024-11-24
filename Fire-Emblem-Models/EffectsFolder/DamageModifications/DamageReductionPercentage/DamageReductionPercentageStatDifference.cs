namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageReductionPercentage;

public class DamageReductionPercentageStatDifference : Effect
{
    private string _stat;
    private int _ponderation;
    private int _topLimit;

    public DamageReductionPercentageStatDifference(string stat, int ponderation)
    {
        _stat = stat;
        _ponderation = ponderation;
        _topLimit = _ponderation * 10;
    }

    public override void Apply(Unit unit)
    {
        double damageReduction = CalculateDamageReduction(unit);
        ApplyDamageReduction(unit, damageReduction);
    }

    protected double CalculateDamageReduction(Unit unit)
    {
        Unit rival = unit.Rival;
        int unitStatValue = unit.Stats.GetStat(_stat).GetStatWithBaseEffects();
        int rivalStatValue = rival.Stats.GetStat(_stat).GetStatWithBaseEffects();
        int statDifference = Math.Abs(unitStatValue - rivalStatValue);
        int statDifferencePonderated = statDifference * _ponderation;
        if (statDifferencePonderated > _topLimit)
        {
            statDifferencePonderated = _topLimit;
        }
        return statDifferencePonderated / 100.0;
    }

    protected virtual void ApplyDamageReduction(Unit unit, double damageReduction) {}
}