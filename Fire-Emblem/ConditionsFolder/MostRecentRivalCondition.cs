using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public class MostRecentRivalCondition : ICondition
{
    public bool IsMet(Unit unit)
    {
        return unit.GetRivalUnit() == unit.GetMostRecentRival();
    }
}