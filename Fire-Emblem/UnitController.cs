using Fire_Emblem_Models;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class UnitController
{
    private Unit _unit;
    private FireEmblemView _view;

    public UnitController(Unit unit, FireEmblemView view)
    {
        _unit = unit;
        _view = view;
    }

    public void HealAfterAttack(int damage)
    {
        int healBonus = (int)(damage * _unit.HealingPercentageAfterAttack);
        _unit.Hp.Heal(healBonus);
        if (healBonus > 0)
        {
            _view.PrintHealBonus(_unit, healBonus); 
        }
    }
    
    public void ResetRoundActions()
    {
        _unit.IsStartingCombat = false;
        _unit.HasMadeFirstAttack = false;
        _unit.InFollowUp = false;
        _unit.Stats.ClearEffectsForEveryStat();
        _unit.DamageEffects.ResetDamageEffects();
    }
}