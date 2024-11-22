using Fire_Emblem_Models;
using Fire_Emblem_Models.Exceptions;

namespace Fire_Emblem;

public class FollowUpHandler
{
    // Esta bien que almacene como privados estos valores, y después los rescate por afuera? No sería un objeto?
    // Dejar como diccionario?
    // Usar _gameInfo?
    private Unit _followUpAttacker;
    private Unit _followUpDefender;
    private GameInfo _gameInfo;
    private int _followUpSpdDifference = 4;

    public FollowUpHandler(GameInfo gameInfo)
    {
        _gameInfo = gameInfo;
    }
    
    public void SetFollowUp()
    {
        Unit attacker = _gameInfo.AttackingUnit;
        Unit defender = _gameInfo.DefendingUnit;
        CheckFollowUp(attacker, defender);
        SetFollowUpUnits(attacker, defender);
        CheckForCounterDenial(_followUpAttacker);
        _followUpAttacker.InFollowUp = true;
        _followUpDefender.InFollowUp = true;
    }

    private void CheckFollowUp(Unit attacker, Unit defender)
    {
        if (!IsThereAFollowUp(attacker, defender))
        {
            if (!defender.CanDoCounter())
            {
                throw new NoFollowUpForAttackerException();
            }
            throw new NoFollowUpForAllUnitsException();  
        }
    }
        
    private bool IsThereAFollowUp(Unit attacker, Unit defender)
    {
        return Math.Abs(attacker.Stats.GetStat("Spd").GetStatWithEffects() - defender.Stats.GetStat("Spd").GetStatWithEffects()) > _followUpSpdDifference;
    }
    
    private void CheckForCounterDenial(Unit followUpDefender)
    {
        if (!followUpDefender.CanDoCounter())
            throw new NoFollowUpForAttackerException();
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
}