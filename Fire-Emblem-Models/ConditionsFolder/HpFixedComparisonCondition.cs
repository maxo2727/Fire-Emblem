namespace Fire_Emblem_Models.ConditionsFolder;

public class HpFixedComparisonCondition : ICondition
{
    private int _value;
    private Func<int, int, bool> _comparison;

    public HpFixedComparisonCondition(int value, Func<int, int, bool> comparison)
    {
        _value = value;
        _comparison = comparison;
    }

    public bool IsMet(Unit unit)
    {
        return _comparison(unit.Hp.GetCurrentHP(), _value);
    }
}