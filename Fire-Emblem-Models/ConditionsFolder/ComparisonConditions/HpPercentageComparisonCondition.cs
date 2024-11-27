namespace Fire_Emblem_Models.ConditionsFolder.ComparisonConditions;

public class HpPercentageComparisonCondition : ComparisonCondition
{
    private double _percentage;
    private Func<int, int, double, bool> _fractionalComparison;
    
    public HpPercentageComparisonCondition(double percentage)
    {
        _percentage = percentage;
    }
    
    // public HpPercentageComparisonCondition(double percentage, Func<int, int, double, bool> fractionalComparison)
    // {
    //     _percentage = percentage;
    //     _fractionalComparison = fractionalComparison;
    // }

    public override bool IsMet(Unit unit)
    {
        int currentHP = unit.Hp.GetCurrentHP();
        int maxHP = unit.Hp.GetMaxHP();
        return _comparisonMethod.Compare(currentHP, maxHP, _percentage);
    }
}