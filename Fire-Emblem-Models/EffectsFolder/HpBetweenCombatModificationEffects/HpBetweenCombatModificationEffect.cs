namespace Fire_Emblem_Models.EffectsFolder.HpBetweenCombatModificationEffects;

public class HpBetweenCombatModificationEffect : Effect
{
    protected int _value;

    public HpBetweenCombatModificationEffect(int value)
    {
        _value = value;
    }

    public override void Apply(Unit unit)
    {
    }
}