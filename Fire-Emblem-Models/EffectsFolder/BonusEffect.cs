namespace Fire_Emblem_Models.EffectsFolder;

public class BonusEffect: Effect
{
    private string _stat;
    private int _bonus;

    public BonusEffect(string stat, int bonus)
    {
        _stat = stat;
        _bonus = bonus;
    }
    
    public override void Apply(Unit unit)
    {
        // unit.Stats.GetStat(_stat)
        // .Bonus += _bonus;
        unit.Stats.ModifyBonuses(_stat, _bonus);
        // unit.ModifyBonuses(_stat, _bonus);
    }
}