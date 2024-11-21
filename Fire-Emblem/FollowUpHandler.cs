using Fire_Emblem_Models;
using Fire_Emblem_Models.Exceptions;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class FollowUpHandler
{
    private Unit _followUpAttacker;
    private Unit _followUpDefender;
    
    public void SetFollowUp(Unit attacker, Unit defender)
    {
        CheckFollowUp(attacker, defender);
        SetFollowUpUnits(attacker, defender);
        _followUpAttacker.InFollowUp = true;
        _followUpDefender.InFollowUp = true;
    }

    private void CheckFollowUp(Unit attacker, Unit defender)
    {
        if (!IsThereAFollowUp(attacker, defender))
            throw new NoFollowUpException();
    }
        
    private bool IsThereAFollowUp(Unit attacker, Unit defender)
    {
        return Math.Abs(attacker.Stats.GetStat("Spd").GetStatWithEffects() - defender.Stats.GetStat("Spd").GetStatWithEffects()) > 4;
    }

    private void SetFollowUpUnits(Unit attacker, Unit defender)
    {
        if (attacker.Stats.GetStat("Spd").GetStatWithEffects() >
            defender.Stats.GetStat("Spd").GetStatWithEffects())
        {
            _followUpAttacker = attacker; 
            _followUpDefender = defender;
        }
        else
        {
            _followUpAttacker = defender; 
            _followUpDefender = attacker;
        }
    }

    public Unit GetFollowUpAttacker()
    {
        return _followUpAttacker;
    }

    public Unit GetFollowUpDefender()
    {
        return _followUpDefender;
    }
        
    // private Unit GetFollowUpAttacker()
    // {
    //     if (_attackingUnit.Stats.GetStat("Spd").GetStatWithEffects() > _defendingUnit.Stats.GetStat("Spd").GetStatWithEffects())
    //         return _attackingUnit;
    //     else
    //         return _defendingUnit;
    // }
    //
    // private Unit GetFollowUpDefender()
    // {
    //     if (_attackingUnit.Stats.GetStat("Spd").GetStatWithEffects() > _defendingUnit.Stats.GetStat("Spd").GetStatWithEffects())
    //         return _defendingUnit;
    //     else
    //         return _attackingUnit;
    // }
}