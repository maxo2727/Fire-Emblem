namespace Fire_Emblem_Models.Functions.ComparisonMethods;

public class FractionalLessThanOrEqualToMethod : FractionalComparisonMethod
{
    public override bool Compare(int a, int b, double value)
    {
        return ProportionCalculator.CalculateProportion(a, b) <= value;
    }
}