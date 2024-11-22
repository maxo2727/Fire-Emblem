namespace Fire_Emblem_Models.EffectsFolder;

public class HealingEffect : Effect
{
    private double _percentage;

    public HealingEffect(double percentage)
    {
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        unit.HealPercentage += _percentage;
    }
}