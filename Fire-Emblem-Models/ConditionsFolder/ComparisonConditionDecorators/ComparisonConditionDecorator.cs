using Fire_Emblem_Models.ConditionsFolder.ComparisonConditions;
using Fire_Emblem_Models.Functions.ComparisonMethods;

namespace Fire_Emblem_Models.ConditionsFolder.ComparisonConditionDecorators;

public class ComparisonConditionDecorator : ICondition
{
    protected ComparisonCondition _innerCondition;
    protected IComparisonMethod _comparisonMethod; 

    public ComparisonConditionDecorator(ComparisonCondition innerCondition, IComparisonMethod comparisonMethod)
    {
        _innerCondition = innerCondition;
        _comparisonMethod = comparisonMethod;
    }

    public bool IsMet(Unit unit)
    {
        _innerCondition.SetConditionMethod(_comparisonMethod);
        return _innerCondition.IsMet(unit);
    }
}