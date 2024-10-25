using Fire_Emblem_Models;
using Fire_Emblem_View;

namespace Fire_Emblem.SkillsFolder;

public class SkillController
{
    private Unit _attackingUnit;
    private Unit _defendingUnit;
    private SkillEffectsPrinter _skillEffectsPrinter;
    private GameInfo _gameInfo;
    private List<ConditionalEffect> _conditionalEffectsToApply;
    
    public SkillController(FireEmblemView view, GameInfo gameInfo)
    {
        _skillEffectsPrinter = view.GetSkillEffectsPrinter();
        _gameInfo = gameInfo;
    }
    
    public void UseSkills()
    {
        _conditionalEffectsToApply = new List<ConditionalEffect>();
        _attackingUnit = _gameInfo.AttackingUnit;
        _defendingUnit = _gameInfo.DefendingUnit;
        GetConditionalEffects(_attackingUnit);
        GetConditionalEffects(_defendingUnit);
        SortConditionalEffects();
        ApplyConditionalEffectsToAllUnits();
        _skillEffectsPrinter.PrintSkillEffectsByUnit(_attackingUnit);
        _skillEffectsPrinter.PrintSkillEffectsByUnit(_defendingUnit);
        _attackingUnit.Hp.SetMaxHPForCombat();
        _defendingUnit.Hp.SetMaxHPForCombat();
    }

    private void GetConditionalEffects(Unit unit)
    {
        foreach (string skill in unit.Skills.GetAllSkills())
        {
            List<ConditionalEffect> conditionalEffects = SkillCatalog.GetConditionalEffectsFromSkill(skill);
            foreach (ConditionalEffect conditionalEffect in conditionalEffects)
            {
                conditionalEffect.SetTargetUnit(unit);
                _conditionalEffectsToApply.Add(conditionalEffect);
            }
        }
    }

    private void SortConditionalEffects()
    {
        _conditionalEffectsToApply.Sort(
            (p1, p2) =>
            {
                int priority1 = p1.GetPriority();
                int priority2 = p2.GetPriority();
                return priority1.CompareTo(priority2);
            }
        );
    }

    private void ApplyConditionalEffectsToAllUnits()
    {
        foreach (ConditionalEffect conditionalEffect in _conditionalEffectsToApply)
        {
            conditionalEffect.UseConditionalEffect();
        }
    }
}