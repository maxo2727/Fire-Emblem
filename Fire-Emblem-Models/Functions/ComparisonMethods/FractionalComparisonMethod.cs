namespace Fire_Emblem_Models.Functions.ComparisonMethods;

public class FractionalComparisonMethod : IComparisonMethod
{
    public bool Compare(int a, int b)
    {
        throw new NotImplementedException();
    }
    
    public virtual bool Compare(int a, int b, double value)
    {
        return true;
    }
}