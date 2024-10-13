using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public class HPLessThanCondition : ICondition
{
    private double _value;
    
    public HPLessThanCondition(double value)
    {
        _value = value;
    }
    
    public bool IsMet(Unit unit)
    {
        return (double)unit.GetCurrentHP() / (double)unit.Hp.GetMaxHP() <= _value;
    }
}