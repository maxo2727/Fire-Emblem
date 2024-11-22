namespace Fire_Emblem_Models.ConditionsFolder;

public class HpComparisonCondition : ICondition
{
    private int _difference;

    public HpComparisonCondition(int difference)
    {
        _difference = difference;
    }

    public bool IsMet(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        return unit.GetCurrentHP() >= rival.GetCurrentHP() + _difference;
    }
}