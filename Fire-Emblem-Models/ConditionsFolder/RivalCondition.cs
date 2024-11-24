namespace Fire_Emblem_Models.ConditionsFolder;

public class RivalCondition : ICondition
{
    private ICondition _baseCondition;
    
    public RivalCondition(ICondition baseCondition)
    {
        _baseCondition = baseCondition;
    }

    public virtual bool IsMet(Unit unit)
    {
        Unit rival = unit.Rival;
        return _baseCondition.IsMet(rival);
    }
}