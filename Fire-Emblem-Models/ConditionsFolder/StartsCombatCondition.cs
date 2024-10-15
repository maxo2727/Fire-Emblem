namespace Fire_Emblem_Models.ConditionsFolder;

public class StartsCombatCondition : ICondition
{
    public virtual bool IsMet(Unit unit)
    {
        return unit.IsStartingCombat;
    }
}