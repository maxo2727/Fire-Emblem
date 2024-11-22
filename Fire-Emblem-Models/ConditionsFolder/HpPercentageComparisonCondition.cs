namespace Fire_Emblem_Models.ConditionsFolder;

public class HpPercentageComparisonCondition : ICondition
{
    private double _percentage;
    private Func<int, int, double, bool> _fractionalComparison;
    
    public HpPercentageComparisonCondition(double percentage, Func<int, int, double, bool> fractionalComparison)
    {
        _percentage = percentage;
        _fractionalComparison = fractionalComparison;
    }

    public bool IsMet(Unit unit)
    {
        int currentHP = unit.GetCurrentHP();
        int maxHP = unit.Hp.GetMaxHP();
        return _fractionalComparison(currentHP, maxHP, _percentage);
    }
}