using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class FractionalBonusEffect : Effect
{
    private string _stat;
    private int _baseStatFraction;

    public FractionalBonusEffect(string stat, int baseStatFraction)
    {
        _stat = stat;
        _baseStatFraction = baseStatFraction;
    }

    public override void Apply(Unit unit)
    {
        int bonus = unit.Stats[_stat].BaseStat / _baseStatFraction;
        unit.ModifyBonuses(_stat, bonus);
    }
}