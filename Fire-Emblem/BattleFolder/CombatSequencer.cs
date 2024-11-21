using Fire_Emblem_Models;
using Fire_Emblem_Models.EffectsFolder;
using Fire_Emblem_Models.StatsFolder;
using Fire_Emblem_View;
using Fire_Emblem.SkillsFolder;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class CombatSequencer
{
    private Unit _attackingUnit;
    private Unit _defendingUnit;
    private FireEmblemView _view;
    private DamageHandler _damageHandler;
    private GameInfo _gameInfo;

    public CombatSequencer(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _gameInfo = gameInfo;
        _damageHandler = new DamageHandler(_view, _gameInfo);
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
        _attackingUnit = _gameInfo.AttackingUnit;
        _defendingUnit = _gameInfo.DefendingUnit;
    }
    
    private void Attack()
    {
        int damage = _damageHandler.CalculateDamage(_attackingUnit, _defendingUnit);
        _defendingUnit.TakeDamage(damage);
        _attackingUnit.HasMadeFirstAttack = true;
    }
    
    private void CounterAttack()
    {
        int damage = _damageHandler.CalculateDamage(_defendingUnit, _attackingUnit);
        _attackingUnit.TakeDamage(damage);
        _defendingUnit.HasMadeFirstAttack = true;
    }
    
    private void FollowUp()
    {
        if (IsThereAFollowUp())
        {
            Unit followUpAttacker = GetFollowUpAttacker();
            Unit followUpDefender = GetFollowUpDefender();
            followUpAttacker.InFollowUp = true;
            followUpDefender.InFollowUp = true;
            int damage = _damageHandler.CalculateDamage(followUpAttacker, followUpDefender);
            followUpDefender.TakeDamage(damage);
        }
        else
            _view.PrintNoFollowUp();
    }
    
    private bool IsThereAFollowUp()
    {
        return Math.Abs(_attackingUnit.Stats.GetStat("Spd").GetStatWithEffects() - _defendingUnit.Stats.GetStat("Spd").GetStatWithEffects()) > 4;
    }
    
    private Unit GetFollowUpAttacker()
    {
        if (_attackingUnit.Stats.GetStat("Spd").GetStatWithEffects() > _defendingUnit.Stats.GetStat("Spd").GetStatWithEffects())
            return _attackingUnit;
        else
            return _defendingUnit;
    }

    private Unit GetFollowUpDefender()
    {
        if (_attackingUnit.Stats.GetStat("Spd").GetStatWithEffects() > _defendingUnit.Stats.GetStat("Spd").GetStatWithEffects())
            return _defendingUnit;
        else
            return _attackingUnit;
    }
    
    private bool IsThereAnyUnitDead()
    {
        return (!_attackingUnit.IsAlive() || !_defendingUnit.IsAlive());
    }
}