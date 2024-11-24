namespace Fire_Emblem_Models.EffectsFolder;

public class HpBetweenCombatModificationEffect : Effect
{
    private int _value;
    private Action<Unit, int> _hpModificationAction;

    public HpBetweenCombatModificationEffect(int value, Action<Unit, int> hpModificationAction)
    {
        _value = value;
        _hpModificationAction = hpModificationAction;
    }

    public override void Apply(Unit unit)
    {
        _hpModificationAction(unit, _value);
    }
}