namespace Fire_Emblem_Models.Functions.ComparisonMethods;

public class FixedComparisonMethod : IComparisonMethod
{
    public virtual bool Compare(int a, int b)
    {
        return true;
    }
    
    public bool Compare(int a, int b, double value)
    {
        throw new NotImplementedException();
    }
}