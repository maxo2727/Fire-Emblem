namespace Fire_Emblem_Models.ConditionsFolder;

public class StartsCombatRivalCondition : StartsCombatCondition
{
    public override bool IsMet(Unit unit)
    {
        return base.IsMet(unit.GetRivalUnit());
    }
}