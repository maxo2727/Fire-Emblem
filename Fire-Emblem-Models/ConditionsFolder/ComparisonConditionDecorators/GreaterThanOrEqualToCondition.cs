using Fire_Emblem_Models.ConditionsFolder.ComparisonConditions;
using Fire_Emblem_Models.Functions.ComparisonMethods;

namespace Fire_Emblem_Models.ConditionsFolder.ComparisonConditionDecorators;

public class GreaterThanOrEqualToCondition : ComparisonConditionDecorator
{
    public GreaterThanOrEqualToCondition(ComparisonCondition innerCondition) : base(innerCondition, new GreaterThanOrEqualToMethod()) {}
}