namespace Fire_Emblem_Models.ConditionsFolder;

public class StatComparisonCondition : ICondition
{
    private string _unitStat;
    private string _rivalStat;

    public StatComparisonCondition(string stat)
    {
        _unitStat = stat;
        _rivalStat = stat;
    }
    public StatComparisonCondition(string unitStat, string rivalStat)
    {
        _unitStat = unitStat;
        _rivalStat = rivalStat;
    }

    public bool IsMet(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        int unitStatValue = unit.Stats.GetStat(_unitStat).GetStatWithBaseEffects();
        int rivalStatValue = rival.Stats.GetStat(_rivalStat).GetStatWithBaseEffects();
        return unitStatValue > rivalStatValue;
    }
}