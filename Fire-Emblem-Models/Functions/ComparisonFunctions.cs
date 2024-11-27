namespace Fire_Emblem_Models.Functions;

public static class ComparisonFunctions
{
    public static bool FractionalGreaterThan(int a, int b, double value)
    {
        return CalculateProportion(a, b) > value;
    }
    
    public static bool FractionalGreaterThanOrEqualTo(int a, int b, double value)
    {
        return CalculateProportion(a, b) >= value;
    }
    
    public static bool FractionalLessThan(int a, int b, double value)
    {
        return CalculateProportion(a, b) < value;
    }
    
    public static bool FractionalLessThanOrEqualTo(int a, int b, double value)
    {
        return CalculateProportion(a, b) <= value;
    }
    
    public static bool FractionalEqualTo(int a, int b, double value)
    {
        return CalculateProportion(a, b) == value;
    }

    // dejarla en otro lado, en functions utils quizas
    public static double CalculateProportion(int a, int b)
    {
        return Math.Round((double)a / (double)b, 2);
    }
}