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

    public CombatSequencer(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _gameInfo = gameInfo;
        _damageHandler = new DamageHandler(_view, _gameInfo);
        _followUpHandler = new FollowUpHandler();
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
        DoCombatEventBetween(_gameInfo.AttackingUnit, _gameInfo.DefendingUnit);
    }
    
    private void DoCombatEventBetween(Unit attacker, Unit defender)
    {
        int damage = _damageHandler.CalculateDamage(attacker, defender);
        defender.TakeDamage(damage);
        attacker.HasMadeFirstAttack = true;
        HealAfterAttack(attacker, damage);
    }
    
    private void CounterAttack()
    {
        DoCombatEventBetween(_gameInfo.DefendingUnit, _gameInfo.AttackingUnit);
    }
    
    private void FollowUp()
    {
        try
        {
            Unit attacker = _gameInfo.AttackingUnit;
            Unit defender = _gameInfo.DefendingUnit;
            _followUpHandler.SetFollowUp(attacker, defender);
            Unit followUpAttacker = _followUpHandler.GetFollowUpAttacker();
            Unit followUpDefender = _followUpHandler.GetFollowUpDefender();
            DoCombatEventBetween(followUpAttacker, followUpDefender);
        }
        catch (NoFollowUpException)
        {
            _view.PrintNoFollowUp();
        }
    }
    
    private bool IsThereAnyUnitDead()
    {
        Unit attacker = _gameInfo.AttackingUnit;
        Unit defender = _gameInfo.DefendingUnit;
        return (!attacker.IsAlive() || !defender.IsAlive());
    }

    private void HealAfterAttack(Unit attacker, int damage)
    {
        int healBonus = attacker.HealAfterAttack(damage);
        if (healBonus > 0)
        {
           _view.PrintHealBonus(attacker, healBonus); 
        }
    }
}