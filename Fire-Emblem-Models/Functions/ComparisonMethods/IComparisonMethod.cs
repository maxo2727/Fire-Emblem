namespace Fire_Emblem_Models.Functions.ComparisonMethods;

public interface IComparisonMethod
{
    bool Compare(int a, int b);

    bool Compare(int a, int b, double value);
}