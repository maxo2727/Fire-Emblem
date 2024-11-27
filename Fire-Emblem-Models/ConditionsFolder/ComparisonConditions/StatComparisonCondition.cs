using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models.ConditionsFolder.ComparisonConditions;

public class StatComparisonCondition : ComparisonCondition
{
    private string _unitStat;
    private string _rivalStat;
    private int _offset = 0;
    
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
    
    public StatComparisonCondition(string stat, int offset)
    {
        _unitStat = stat;
        _rivalStat = stat;
        _offset = offset;
    }

    public override bool IsMet(Unit unit)
    {
        Unit rival = unit.Rival;
        Stat unitStat = unit.Stats.GetStat(_unitStat);
        Stat rivalStat = rival.Stats.GetStat(_rivalStat);
        int unitStatValue = unitStat.GetStatWithBaseEffects();
        int rivalStatValue = rivalStat.GetStatWithBaseEffects();
        return _comparisonMethod.Compare(unitStatValue, rivalStatValue + _offset);
    }
}