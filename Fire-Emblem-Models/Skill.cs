using Fire_Emblem_Models.ConditionsFolder;
using Fire_Emblem_Models.EffectsFolder;

namespace Fire_Emblem_Models;

public class Skill
{
    public string Name;
    private List<ICondition> _conditions;
    private List<Effect> _effects;

    public Skill(string name, List<ICondition> conditionsList, List<Effect> effectsList)
    {
        Name = name;
        _conditions = conditionsList;
        _effects = effectsList;
    }

    public void UseSkill(Unit unit)
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