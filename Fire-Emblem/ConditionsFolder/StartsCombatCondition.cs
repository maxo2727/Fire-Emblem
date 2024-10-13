using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public class StartsCombatCondition : ICondition
{
    public virtual bool IsMet(Unit unit)
    {
        return unit.IsStartingCombat;
    }
}