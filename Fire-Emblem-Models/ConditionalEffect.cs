using Fire_Emblem_Models.ConditionsFolder;
using Fire_Emblem_Models.EffectsFolder;

namespace Fire_Emblem_Models;

public class ConditionalEffect
{
    private int _priority;
    private List<ICondition> _conditions;
    private List<Effect> _effects;
    private Unit _targetUnit;

    public ConditionalEffect(List<ICondition> conditions, List<Effect> effects, int priority)
    {
        _conditions = conditions;
        _effects = effects;
        _priority = priority;
    }

    public void SetTargetUnit(Unit unit)
    {
        _targetUnit = unit;
    }

    public int GetPriority()
    {
        return _priority;
    }
    
    public void UseConditionalEffect()
    {
        if (ConditionsAreMet())
        {
            ApplyEffects();
        };
    }
    
    public bool ConditionsAreMet()
    {
        foreach (ICondition condition in _conditions)
        {
            if (!condition.IsMet(_targetUnit))
            {
                return false;
            }
        }
        return true;
    }
    
    public void ApplyEffects()
    {
        foreach (Effect effect in _effects)
        {
            effect.Apply(_targetUnit);
        }
    }
}