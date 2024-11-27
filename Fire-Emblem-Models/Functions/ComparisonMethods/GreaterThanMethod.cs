using Fire_Emblem_Models.ConditionsFolder;

namespace Fire_Emblem_Models.Functions.ComparisonMethods;

public class GreaterThanMethod : FixedComparisonMethod
{
    public override bool Compare(int a, int b)
    {
        return a > b;
    }
}