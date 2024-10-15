namespace Fire_Emblem_Models.ConditionsFolder;

public class MostRecentRivalCondition : ICondition
{
    public bool IsMet(Unit unit)
    {
        return unit.GetRivalUnit() == unit.GetMostRecentRival();
    }
}