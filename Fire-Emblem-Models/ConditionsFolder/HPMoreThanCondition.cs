namespace Fire_Emblem_Models.ConditionsFolder;

public class HPMoreThanCondition : ICondition
{
    private double _value;
    
    public HPMoreThanCondition(double value)
    {
        _value = value;
    }
    
    public bool IsMet(Unit unit)
    {
        Console.WriteLine($"{unit.Name} HP: {Math.Round((double)unit.GetCurrentHP() / (double)unit.Hp.GetMaxHP(),2)}");
        return Math.Round((double)unit.GetCurrentHP() / (double)unit.Hp.GetMaxHP(),2) >= _value;
    }
}