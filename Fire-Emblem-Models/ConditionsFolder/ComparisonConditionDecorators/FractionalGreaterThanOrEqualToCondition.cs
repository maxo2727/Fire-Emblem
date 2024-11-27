using Fire_Emblem_Models.ConditionsFolder.ComparisonConditions;
using Fire_Emblem_Models.Functions.ComparisonMethods;

namespace Fire_Emblem_Models.ConditionsFolder.ComparisonConditionDecorators;

public class FractionalGreaterThanOrEqualToCondition : ComparisonConditionDecorator
{
    public FractionalGreaterThanOrEqualToCondition(ComparisonCondition innerCondition) : base(innerCondition, new FractionalGreaterThanOrEqualToMethod()) {}
}