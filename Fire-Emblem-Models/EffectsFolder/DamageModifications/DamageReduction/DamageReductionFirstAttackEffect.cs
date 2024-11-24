namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageReduction;

public class DamageReductionFirstAttackEffect : Effect
{
    private int _reduction;

    public DamageReductionFirstAttackEffect(int reduction)
    {
        _reduction = reduction;
    }

    public override void Apply(Unit unit)
    {
        unit.DamageEffects.FirstAttackDamageReduction += _reduction;
    }
}