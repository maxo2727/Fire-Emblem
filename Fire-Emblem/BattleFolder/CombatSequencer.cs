using Fire_Emblem_Models;
using Fire_Emblem_Models.EffectsFolder;
using Fire_Emblem_Models.Exceptions;
using Fire_Emblem_Models.StatsFolder;
using Fire_Emblem_View;
using Fire_Emblem.SkillsFolder;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class CombatSequencer
{
    private UnitController _attackerController;
    private UnitController _defenderController;
    private FireEmblemView _view;
    private DamageHandler _damageHandler;
    private FollowUpHandler _followUpHandler;
    private GameInfo _gameInfo;
    private HpBetweenCombatManager _hpBetweenCombatManager;
    private UnitStateManager _unitStateManager;

    public CombatSequencer(FireEmblemView view, GameInfo gameInfo, HpBetweenCombatManager hpBetweenCombatManager)
    {
        _view = view;
        _gameInfo = gameInfo;
        _hpBetweenCombatManager = hpBetweenCombatManager;
        _damageHandler = new DamageHandler(_view, _gameInfo);
        _followUpHandler = new FollowUpHandler(_view, _gameInfo);
        _unitStateManager = new UnitStateManager(_view);
    }
    
    public void CombatSequence()
    {
        SetCombatUnits();
        Attack();
        if (IsThereAnyUnitDead())
            return;
        CounterAttack();
        if (IsThereAnyUnitDead())
            return;
        FollowUp();
    }
    
    private void SetCombatUnits()
    {
        _attackerController = new UnitController(_gameInfo.AttackingUnit, _view);
        _defenderController = new UnitController(_gameInfo.DefendingUnit, _view);
    }
    
    private void Attack()
    {
        Unit attacker = _gameInfo.AttackingUnit;
        Unit defender = _gameInfo.DefendingUnit;
        DoCombatEventBetween(attacker, defender);
    }
    
    private void DoCombatEventBetween(Unit attacker, Unit defender)
    {
        int damage = _damageHandler.CalculateDamage(attacker, defender);
        defender.Hp.TakeDamage(damage);
        attacker.HasMadeFirstAttack = true;
        _hpBetweenCombatManager.ApplyHealingAfterAttack(attacker, damage);
        SetAliveStatusForAllUnits();
    }

    private void SetAliveStatusForAllUnits()
    {
        _unitStateManager.SetAliveUnitStatus(_gameInfo.AttackingUnit);
        _unitStateManager.SetAliveUnitStatus(_gameInfo.DefendingUnit);
    }
    
    private void CounterAttack()
    {
        Unit attacker = _gameInfo.DefendingUnit;
        Unit defender = _gameInfo.AttackingUnit;
        if (CanUnitDoCounter(attacker))
        {
            DoCombatEventBetween(attacker, defender);
        }
    }

    private bool CanUnitDoCounter(Unit unit)
    {
        return _unitStateManager.CanDoCounter(unit);
    }
    
    private void FollowUp()
    {
        try
        {
            _followUpHandler.SetFollowUpForAllUnits();
            ExecuteFollowUpForAllUnits();
        }
        catch (NoFollowUpForAllUnitsException e)
        {
            HandleNoFollowUpException(e);
        }
    }

    private void ExecuteFollowUpForAllUnits()
    {
        ExecuteFollowUp(_gameInfo.AttackingUnit, _gameInfo.DefendingUnit); 
        ExecuteFollowUp(_gameInfo.DefendingUnit, _gameInfo.AttackingUnit);
    }

    private void ExecuteFollowUp(Unit attacker, Unit defender)
    {
        if (attacker.CanDoFollowUp)
        {
            DoCombatEventBetween(attacker, defender);
        }
    }

    private void HandleNoFollowUpException(NoFollowUpForAllUnitsException e)
    {
        if (e.IsDefenderCounterDenied)
        {
            _view.PrintNoFollowUpForAttacker(_gameInfo.AttackingUnit);
        }
        else
        {
            _view.PrintNoFollowUpForAllUnits();
        }
    }

    // private void HandleNoFollowUpException(NoFollowUpForAllUnitsException e)
    // {
    //     e.Handle(_view, _gameInfo.AttackingUnit);
    // }
    
    private bool IsThereAnyUnitDead()
    {
        Unit attacker = _gameInfo.AttackingUnit;
        Unit defender = _gameInfo.DefendingUnit;
        return (!attacker.IsAlive || !defender.IsAlive);
    }
}