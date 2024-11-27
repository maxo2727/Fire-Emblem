namespace Fire_Emblem_Models.Functions;

public static class ProportionCalculator
{
    private static readonly int RoundNumber = 2;
    
    public static double CalculateProportion(int a, int b)
    {
        return Math.Round((double)a / (double)b, RoundNumber);
    }
}