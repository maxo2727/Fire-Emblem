namespace Fire_Emblem_Models.EffectsFolder.HpBetweenCombatModificationEffects;

public class DamageBeforeCombatEffect : HpBetweenCombatModificationEffect
{
    public DamageBeforeCombatEffect(int value) : base(value)
    {
        
    }

    public override void Apply(Unit unit)
    {
        unit.DamageBeforeCombat += _value;
    }
}