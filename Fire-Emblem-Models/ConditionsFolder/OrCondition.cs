namespace Fire_Emblem_Models.ConditionsFolder;

public class OrCondition : ICondition
{
    private List<ICondition> _conditions;

    public OrCondition(List<ICondition> conditions)
    {
        _conditions = conditions;
    }

    public bool IsMet(Unit unit)
    {
        foreach (ICondition condition in _conditions)
        {
            if (condition.IsMet(unit))
            {
                return true;
            }
        }
        return false;
    }
}