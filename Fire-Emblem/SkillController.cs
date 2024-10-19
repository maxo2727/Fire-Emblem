using Fire_Emblem_Models;
using Fire_Emblem_Models.EffectsFolder;
using Fire_Emblem_View;
using Fire_Emblem.SkillsFolder;

namespace Fire_Emblem;

public class SkillController
{
    private Unit _attackingUnit;
    private Unit _defendingUnit;
    private FireEmblemView _view;
    private SkillEffectsPrinter _skillEffectsPrinter;
    private GameInfo _gameInfo;
    private List<ConditionalEffect> _conditionalEffectsToApply;
    
    public SkillController(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _skillEffectsPrinter = new SkillEffectsPrinter(_view);
        _gameInfo = gameInfo;
    }

    public void UseSkills()
    {
        _attackingUnit = _gameInfo.AttackingUnit;
        _defendingUnit = _gameInfo.DefendingUnit;
        CheckIfUnitCanUseSkills(_attackingUnit);
        CheckIfUnitCanUseSkills(_defendingUnit);
        _skillEffectsPrinter.PrintSkillEffectsByUnit(_attackingUnit);
        _skillEffectsPrinter.PrintSkillEffectsByUnit(_defendingUnit);
        _attackingUnit.Hp.SetMaxHPForCombat();
        _defendingUnit.Hp.SetMaxHPForCombat();
    }

    public void CheckIfUnitCanUseSkills(Unit unit)
    {
        _conditionalEffectsToApply = new List<ConditionalEffect>();
        foreach (string skill in unit.Skills.GetAllSkills())
        {
            List<ConditionalEffect> conditionalEffects = SkillCatalog.GetConditionalEffects(skill);
            foreach (ConditionalEffect conditionalEffect in conditionalEffects)
            {
                _conditionalEffectsToApply.Add(conditionalEffect);
            }
        }

        foreach (ConditionalEffect conditionalEffect in _conditionalEffectsToApply)
        {
            conditionalEffect.UseConditionalEffect(unit);
        }
    }
}