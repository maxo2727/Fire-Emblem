namespace Fire_Emblem_Models.ConditionsFolder;

public class StatComparisonCondition : ICondition
{
    private string _unitStat;
    private string _rivalStat;
    private int _offset = 0;
    private Func<int, int, bool> _comparison;

    public StatComparisonCondition(string stat, Func<int, int, bool> comparison)
    {
        _unitStat = stat;
        _rivalStat = stat;
        _comparison = comparison;
    }
    public StatComparisonCondition(string unitStat, string rivalStat, Func<int, int, bool> comparison)
    {
        _unitStat = unitStat;
        _rivalStat = rivalStat;
        _comparison = comparison;
    }

    public StatComparisonCondition(string stat, int offset, Func<int, int, bool> comparison)
    {
        _unitStat = stat;
        _rivalStat = stat;
        _offset = offset;
        _comparison = comparison;
    }

    public bool IsMet(Unit unit)
    {
        Unit rival = unit.Rival;
        int unitStatValue = unit.Stats.GetStat(_unitStat).GetStatWithBaseEffects();
        int rivalStatValue = rival.Stats.GetStat(_rivalStat).GetStatWithBaseEffects();
        return _comparison(unitStatValue, rivalStatValue + _offset);
    }
}