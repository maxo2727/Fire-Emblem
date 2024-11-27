using Fire_Emblem_Models.ConditionsFolder;

namespace Fire_Emblem_Models.Functions.ComparisonMethods;

public class GreaterThanOrEqualToMethod : ComparisonMethod
{
    public override bool Compare(int a, int b)
    {
        return a >= b;
    }
}