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
    private SkillEffectsPrinter _skillEffectsPrinter;
    private SkillController _skillController;
    private GameInfo _gameInfo;

    public CombatSequencer(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _gameInfo = gameInfo;
        _skillController = new SkillController(_view, _gameInfo);
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
    
    // in gameInfo? -> Reset
    public void SetCombatUnits()
    {
        _attackingUnit = _gameInfo.AttackingUnit;
        _defendingUnit = _gameInfo.DefendingUnit;
    }
    
    public void Attack()
    {
        int damage = DamageCalculator.CalculateDamage(_attackingUnit, _defendingUnit);
        _view.WriteLine($"{_attackingUnit.Name} ataca a {_defendingUnit.Name} con {damage} de daño");
        _defendingUnit.TakeDamage(damage);
    }
    
    public void CounterAttack()
    {
        int damage = DamageCalculator.CalculateDamage(_defendingUnit, _attackingUnit);
        _view.WriteLine($"{_defendingUnit.Name} ataca a {_attackingUnit.Name} con {damage} de daño");
        _attackingUnit.TakeDamage(damage);
    }
    
    public void FollowUp()
    {
        if (IsThereAFollowUp())
        {
            Unit followUpAttacker = GetFollowUpAttacker();
            Unit followUpDefender = GetFollowUpDefender();
            followUpAttacker.InFollowUp = true;
            followUpDefender.InFollowUp = true;
            int damage = DamageCalculator.CalculateDamage(followUpAttacker, followUpDefender);
            _view.WriteLine($"{followUpAttacker.Name} ataca a {followUpDefender.Name} con {damage} de daño");
            followUpDefender.TakeDamage(damage);
        }
        else
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
    }
    
    public bool IsThereAFollowUp()
    {
        return Math.Abs(_attackingUnit.Stats.GetStat("Spd").GetStatWithEffects() - _defendingUnit.Stats.GetStat("Spd").GetStatWithEffects()) > 4;
    }
    
    public Unit GetFollowUpAttacker()
    {
        if (_attackingUnit.Stats.GetStat("Spd").GetStatWithEffects() > _defendingUnit.Stats.GetStat("Spd").GetStatWithEffects())
            return _attackingUnit;
        else
            return _defendingUnit;
    }

    public Unit GetFollowUpDefender()
    {
        if (_attackingUnit.Stats.GetStat("Spd").GetStatWithEffects() > _defendingUnit.Stats.GetStat("Spd").GetStatWithEffects())
            return _defendingUnit;
        else
            return _attackingUnit;
    }
    
    public bool IsThereAnyUnitDead()
    {
        return (!_attackingUnit.IsAlive() || !_defendingUnit.IsAlive());
    }
}