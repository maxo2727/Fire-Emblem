namespace Fire_Emblem_Models.EffectsFolder;

public class DamageReductionEffect : Effect
{
    private int _reduction;

    public DamageReductionEffect(int reduction)
    {
        _reduction = reduction;
    }

    public override void Apply(Unit unit)
    {
        unit.DamageEffects.BaseDamageReduction += _reduction;
    }
}