using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class BonusFirstAttackPercentageEffect : Effect
{
    private string _stat;
    private double _percentage;

    public BonusFirstAttackPercentageEffect(string stat, double percentage)
    {
        _stat = stat;
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        int bonus = (int)Math.Truncate(unit.Stats[_stat].BaseStat * _percentage);
        unit.ModifyFirstAttackBonuses(_stat, bonus);
    }
}