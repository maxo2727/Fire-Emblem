namespace Fire_Emblem_Models.ConditionsFolder;

public class HpComparisonWithRivalCondition : ICondition
{
    private int _difference;

    public HpComparisonWithRivalCondition(int difference)
    {
        _difference = difference;
    }

    public bool IsMet(Unit unit)
    {
        Unit rival = unit.Rival;
        return unit.Hp.GetCurrentHP() >= rival.Hp.GetCurrentHP() + _difference;
    }
}