using Fire_Emblem_Models;
using Fire_Emblem_Models.Exceptions;
using Fire_Emblem_Models.StatsFolder;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class FollowUpHandler
{
    private GameInfo _gameInfo;
    private int _followUpSpdDifferenceMin = 4;
    private UnitStateManager _unitStateManager;
    private FireEmblemView _view;

    public FollowUpHandler(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _gameInfo = gameInfo;
        _unitStateManager = new UnitStateManager(_view);
    }

    public void SetFollowUpForAllUnits()
    {
        CheckFollowUp(_gameInfo.AttackingUnit, _gameInfo.DefendingUnit);
        CheckFollowUp(_gameInfo.DefendingUnit, _gameInfo.AttackingUnit);
        CheckCanDoFollowUpStateForUnits(_gameInfo.AttackingUnit, _gameInfo.DefendingUnit);
        SetUnitsInFollowUp();
    }
    
    public void CheckFollowUp(Unit unit, Unit rival)
    {
        try
        {
            CheckForDefendingCounterDenial(unit);
            CheckForNaturalFollowUp(unit, rival);
            CheckIfUnitCanDoFollowUp(unit);
        }
        catch (FollowUpDeniedException) {}
    }
    
    public void CheckForNaturalFollowUp(Unit unit, Unit rival)
    {
        if (CanUnitDoNaturalFollowUp(unit, rival))
        {
            unit.CanDoFollowUp = true;
        }
    }
    
    public bool CanUnitDoNaturalFollowUp(Unit attacker, Unit defender)
    {
        Stat attackerSpd = attacker.Stats.GetStat("Spd");
        Stat defenderSpd = defender.Stats.GetStat("Spd");
        int combatSpdDifference = attackerSpd.GetStatWithEffects() - defenderSpd.GetStatWithEffects();
        return combatSpdDifference > _followUpSpdDifferenceMin;
    }
    
    public void CheckIfUnitCanDoFollowUp(Unit unit)
    {
        if (unit.CanDoFollowUp)
        {
            return;
        }
        if (unit.NumberOfGuaranteedFollowUps > 0)
        {
            unit.CanDoFollowUp = true;
        }
    }
    
    private void CheckForDefendingCounterDenial(Unit followUpDefender)
    {
        if (!_unitStateManager.CanDoCounter(followUpDefender) && followUpDefender.IsDefending)
            throw new FollowUpDeniedException();
    }
    
    public void CheckCanDoFollowUpStateForUnits(Unit attacker, Unit defender)
    {
        if (IsThereAFollowUp(attacker, defender))
        {
            return;
        }
        if (!_unitStateManager.CanDoCounter(defender))
        {
            throw new NoFollowUpForAttackerException();
        }
        throw new NoFollowUpForAllUnitsException(); 
    }
    
    public bool IsThereAFollowUp(Unit unit, Unit rival)
    {
        return unit.CanDoFollowUp || rival.CanDoFollowUp;
    }
    
    public void SetUnitsInFollowUp()
    {
        _gameInfo.AttackingUnit.InFollowUp = true;
        _gameInfo.DefendingUnit.InFollowUp = true;
    }
}