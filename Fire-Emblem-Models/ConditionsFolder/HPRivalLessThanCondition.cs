namespace Fire_Emblem_Models.ConditionsFolder;

public class HPRivalLessThanCondition : ICondition
{
    private double _value;
    
    public HPRivalLessThanCondition(double value)
    {
        _value = value;
    }
    
    public bool IsMet(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        return (double)rival.GetCurrentHP() / (double)rival.Hp.GetMaxHP() <= _value;
    }
}