namespace Fire_Emblem_Models.ConditionsFolder.ComparisonConditions;

public class HpFixedComparisonCondition : ComparisonCondition
{
    private int _value;
    
    public HpFixedComparisonCondition(int value)
    {
        _value = value;
    }

    public override bool IsMet(Unit unit)
    {
        return _comparisonMethod.Compare(unit.Hp.GetCurrentHP(), _value);
    }
}