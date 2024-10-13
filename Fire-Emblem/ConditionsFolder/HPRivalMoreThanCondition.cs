using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public class HPRivalMoreThanCondition : ICondition
{
    private double _value;
    
    public HPRivalMoreThanCondition(double value)
    {
        _value = value;
    }
    
    public bool IsMet(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        return (double)rival.GetCurrentHP() / (double)rival.Hp.GetMaxHP() >= _value;
    }
}