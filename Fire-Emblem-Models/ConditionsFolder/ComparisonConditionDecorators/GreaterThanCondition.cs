using Fire_Emblem_Models.ConditionsFolder.ComparisonConditions;
using Fire_Emblem_Models.Functions.ComparisonMethods;

namespace Fire_Emblem_Models.ConditionsFolder.ComparisonConditionDecorators;

public class GreaterThanCondition : ComparisonConditionDecorator
{
    public GreaterThanCondition(ComparisonCondition innerCondition) : base(innerCondition, new GreaterThanMethod()) {}
}