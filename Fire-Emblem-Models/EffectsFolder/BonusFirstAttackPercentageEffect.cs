namespace Fire_Emblem_Models.EffectsFolder;

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
        int bonus = (int)Math.Truncate(unit.Stats.GetStat(_stat).BaseStat * _percentage);
        unit.Stats.ModifyFirstAttackBonuses(_stat, bonus);
    }
}   