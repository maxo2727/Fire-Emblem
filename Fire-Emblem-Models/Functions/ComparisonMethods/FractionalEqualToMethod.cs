namespace Fire_Emblem_Models.Functions.ComparisonMethods;

public class FractionalEqualToMethod : FractionalComparisonMethod
{
    public override bool Compare(int a, int b, double value)
    {
        return ProportionCalculator.CalculateProportion(a, b) == value;
    }
}