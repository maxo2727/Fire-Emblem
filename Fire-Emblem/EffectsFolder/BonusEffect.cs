using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

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
        unit.ModifyBonuses(_stat, _bonus);
    }
}