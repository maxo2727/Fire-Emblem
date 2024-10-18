using Fire_Emblem_Models.ConditionsFolder;

namespace Fire_Emblem_Models.EffectsFolder;

public class ConditionalEffect
{
    private string priority;
    private List<ICondition> _conditions;
    private List<Effect> _effects;

    public ConditionalEffect(List<ICondition> conditions, List<Effect> effects)
    {
        _conditions = conditions;
        _effects = effects;
    }
    
    // no es algo híbrido?
    public void UseConditionalEffect(Unit unit)
    {
        if (ConditionsAreMet(unit))
        {
            ApplyEffects(unit);
        };
    }
    
    public bool ConditionsAreMet(Unit unit)
    {
        foreach (ICondition condition in _conditions)
        {
            if (!condition.IsMet(unit))
            {
                return false;
            }
        }
        return true;
    }
    
    public void ApplyEffects(Unit unit)
    {
        foreach (Effect effect in _effects)
        {
            effect.Apply(unit);
        }
    }
}