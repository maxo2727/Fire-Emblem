namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageExtra;

public class DamageExtraEffect : Effect
{
    private int _extraDamage;

    public DamageExtraEffect(int extraDamage)
    {
        _extraDamage = extraDamage;
    }
    public override void Apply(Unit unit)
    {
        unit.DamageEffects.BaseDamageBonus += _extraDamage;
    }
}