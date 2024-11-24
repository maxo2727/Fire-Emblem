namespace Fire_Emblem_Models.EffectsFolder;

public class HealAfterAttackEffect : Effect
{
    private double _percentage;

    public HealAfterAttackEffect(double percentage)
    {
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        unit.HealingPercentageAfterAttack += _percentage;
    }
}