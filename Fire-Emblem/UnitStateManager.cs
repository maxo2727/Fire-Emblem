using Fire_Emblem_Models;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class UnitStateManager
{
    private FireEmblemView _view;
    
    public UnitStateManager(FireEmblemView view)
    {
        _view = view;
    }
    public void UpdateAttackingCombatStatus(Unit unit)
    {
        if (!unit.IsAttacking)
        {
            unit.IsAttacking = true;
            unit.IsDefending = false;
        }
    }
    
    public void UpdateDefendingCombatStatus(Unit unit)
    {
        if (!unit.IsDefending)
        {
            unit.IsAttacking = false;
            unit.IsDefending = true;
        }
    }
    
    public void UpdateFirstAttackingCombatStatus(Unit unit)
    {
        if (unit.IsFirstAttackingCombat)
        {
            unit.IsFirstAttackingCombat = false;
        }
    }
    
    public void UpdateFirstDefendingCombatStatus(Unit unit)
    {
        if (unit.IsFirstDefendingCombat)
        {
            unit.IsFirstDefendingCombat = false;
        }
    }
    
    public void ResetUnitRoundActions(Unit unit)
    {
        unit.IsStartingCombat = false;
        unit.HasMadeFirstAttack = false;
        unit.InFollowUp = false;
        unit.Stats.ClearEffectsForEveryStat();
        unit.DamageEffects.ResetDamageEffects();
        unit.HealingPercentageAfterAttack = 0;
        unit.IsCounterDenied = false;
        unit.IsCounterDenialAnnulled = false;
        unit.HealingBeforeCombat = 0;
        unit.DamageBeforeCombat = 0;
        unit.HealingAfterCombat = 0;
        unit.DamageAfterCombat = 0;
        unit.DamageAfterCombatIfHasAttacked = 0;
    }
    
    public void CheckForCounterDenial(Unit defender)
    {
        if (IsCounterDeniedAndDenialAnnulled(defender))
        {
            _view.PrintCounterDenialAnnulled(defender);
        }

        if (IsCounterDeniedButNotDenialAnnulled(defender))
        {
            _view.PrintCounterDenied(defender);
        }
    }
    
    public bool CanDoCounter(Unit unit)
    {
        if (unit.IsCounterDenied)
        {
            if (unit.IsCounterDenialAnnulled)
            {
                return true;
            }
            return false;
        }
        return true;
    }

    public bool IsCounterDeniedAndDenialAnnulled(Unit unit)
    {
        return unit.IsCounterDenied && unit.IsCounterDenialAnnulled;
    }

    public bool IsCounterDeniedButNotDenialAnnulled(Unit unit)
    {
        return unit.IsCounterDenied && !unit.IsCounterDenialAnnulled;
    }

    public void SetAliveUnitStatus(Unit unit)
    {
        if (unit.Hp.IsHpBelowOrEqualToCero())
        {
            unit.IsAlive = false;
        }
    }
}