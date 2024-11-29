namespace Fire_Emblem_Models.EffectsFolder.HpBetweenCombatModificationEffects;

public class DamageAfterCombatIfHasAttacked : HpBetweenCombatModificationEffect
{
    public DamageAfterCombatIfHasAttacked(int value) : base(value)
    {
        
    }

    public override void Apply(Unit unit)
    {
        unit.DamageAfterCombatIfHasAttacked += _value;
    }
}