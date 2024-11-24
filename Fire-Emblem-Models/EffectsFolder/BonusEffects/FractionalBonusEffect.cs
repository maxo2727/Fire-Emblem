namespace Fire_Emblem_Models.EffectsFolder.BonusEffects;

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
        int bonus = unit.Stats.GetStat(_stat).BaseStat / _baseStatFraction;
        unit.Stats.ModifyBonuses(_stat, bonus);
    }
}