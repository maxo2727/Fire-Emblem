using Fire_Emblem_Models.ConditionsFolder.ComparisonConditions;

namespace Fire_Emblem_Models.ConditionsFolder;

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