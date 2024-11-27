using Fire_Emblem_Models.ConditionsFolder.ComparisonConditions;
using Fire_Emblem_Models.Functions.ComparisonMethods;

namespace Fire_Emblem_Models.ConditionsFolder.ComparisonConditionDecorators;

public class FractionalLessThanOrEqualToCondition : ComparisonConditionDecorator
{
    public FractionalLessThanOrEqualToCondition(ComparisonCondition innerCondition) : base(innerCondition, new FractionalLessThanOrEqualToMethod())
    {
        
    }
}