namespace Fire_Emblem_Models.EffectsFolder.HpBetweenCombatModificationEffects;

public class HealingAfterCombatEffect : HpBetweenCombatModificationEffect
{
    public HealingAfterCombatEffect(int value) : base(value)
    {
        
    }

    public override void Apply(Unit unit)
    {
        unit.HealingAfterCombat += _value;
    }
}