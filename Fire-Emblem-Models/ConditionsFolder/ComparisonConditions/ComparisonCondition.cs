using Fire_Emblem_Models.Functions.ComparisonMethods;

namespace Fire_Emblem_Models.ConditionsFolder.ComparisonConditions;

public abstract class ComparisonCondition : ICondition
{
    protected ComparisonMethod _comparisonMethod;

    public abstract bool IsMet(Unit unit);

    public void SetConditionMethod(ComparisonMethod comparisonMethod)
    {
        _comparisonMethod = comparisonMethod;
    }
}