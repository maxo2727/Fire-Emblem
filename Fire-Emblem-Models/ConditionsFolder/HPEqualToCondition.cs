namespace Fire_Emblem_Models.ConditionsFolder;

public class HPEqualToCondition : ICondition
{
    private double _value;
    
    public HPEqualToCondition(double value)
    {
        _value = value;
    }
    
    public bool IsMet(Unit unit)
    {
        return (double)unit.GetCurrentHP() / (double)unit.Hp.GetMaxHP() == _value;
    }
}