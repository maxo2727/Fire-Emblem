namespace Fire_Emblem_Models;

public static class ComparisonFunctions
{
    public static bool GreaterThan(int a, int b)
    {
        return a > b;
    }
    
    public static bool GreaterThanOrEqualTo(int a, int b)
    {
        return a >= b;
    }
    
    public static bool LessThan(int a, int b)
    {
        return a < b;
    }
    
    public static bool LessThanOrEqualTo(int a, int b)
    {
        return a <= b;
    }
    
    public static bool EqualTo(int a, int b)
    {
        return a == b;
    }
    
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