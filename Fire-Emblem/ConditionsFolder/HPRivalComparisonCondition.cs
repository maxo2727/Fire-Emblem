using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public class HPRivalComparisonCondition : ICondition
{
    private int _difference;

    public HPRivalComparisonCondition(int difference)
    {
        _difference = difference;
    }

    public bool IsMet(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        return unit.GetCurrentHP() >= rival.GetCurrentHP() + _difference;
    }
}