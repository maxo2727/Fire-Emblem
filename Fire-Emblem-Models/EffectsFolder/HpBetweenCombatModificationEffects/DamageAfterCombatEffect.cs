namespace Fire_Emblem_Models.EffectsFolder.HpBetweenCombatModificationEffects;

public class DamageAfterCombatEffect : HpBetweenCombatModificationEffect
{
    public DamageAfterCombatEffect(int value) : base(value)
    {
        
    }

    public override void Apply(Unit unit)
    {
        unit.DamageAfterCombat += _value;
    }
}