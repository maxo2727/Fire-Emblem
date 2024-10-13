using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public class StartsCombatRivalCondition : StartsCombatCondition
{
    public override bool IsMet(Unit unit)
    {
        return base.IsMet(unit.GetRivalUnit());
    }
}