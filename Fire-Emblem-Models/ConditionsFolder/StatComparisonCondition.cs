namespace Fire_Emblem_Models.ConditionsFolder;

public class StatComparisonCondition : ICondition
{
    private string _unitStatName;
    private string _rivalStatName;

    public StatComparisonCondition(string unitStatName, string rivalStatName)
    {
        _unitStatName = unitStatName;
        _rivalStatName = rivalStatName;
    }

    public bool IsMet(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        int unitStatValue = unit.Stats.GetStat(_unitStatName).GetStatWithEffects();
        int rivalStatValue = rival.Stats.GetStat(_rivalStatName).GetStatWithEffects();
        return unitStatValue > rivalStatValue;
    }
}