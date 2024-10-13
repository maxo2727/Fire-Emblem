using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public class EmptyCondition: ICondition
{
    public bool IsMet(Unit unit)
    {
        return true;
    }
}