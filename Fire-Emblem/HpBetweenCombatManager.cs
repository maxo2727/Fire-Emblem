using Fire_Emblem_Models;
using Fire_Emblem_Models.Functions;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class HpBetweenCombatManager
{
    private FireEmblemView _view;
    private GameInfo _gameInfo;
    private int _modificationAfterCombat;

    public HpBetweenCombatManager(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _gameInfo = gameInfo;
    }

    public void ApplyHealingAfterAttack(Unit attacker, int damage)
    {
        double healPercentage = attacker.HealingPercentageAfterAttack;
        int healBonus = TrueTruncator.Truncate(damage * healPercentage);
        if (healBonus > 0)
        {
            attacker.Hp.Heal(healBonus); 
            _view.PrintHealBonus(attacker, healBonus); 
        }
    }

    public void ApplyHpModificationsBeforeCombatForAllUnits()
    {
        ApplyHpModificationsBeforeCombat(_gameInfo.AttackingUnit);
        ApplyHpModificationsBeforeCombat(_gameInfo.DefendingUnit);
    }

    public void ApplyHpModificationsBeforeCombat(Unit unit)
    {
        ApplyDamageBeforeCombat(unit);
    }
    
    private void ApplyDamageBeforeCombat(Unit unit)
    {
        unit.TakeDamageBeforeCombat();
        if (unit.DamageBeforeCombat > 0)
            _view.PrintDamageBeforeCombat(unit);
    }

    public void ApplyHpModificationsAfterCombatForAllUnits()
    {
        ApplyHpModificationsAfterCombat(_gameInfo.AttackingUnit);
        ApplyHpModificationsAfterCombat(_gameInfo.DefendingUnit);
    }

    // HpModificationsAfterCombatCalculator nueva clase mas cohesiva (atributo _modificationAfterCombat)
    public void ApplyHpModificationsAfterCombat(Unit unit)
    {
        _modificationAfterCombat = 0;
        if (unit.IsAlive())
        {
            AddHealAfterCombat(unit);
            AddDamageAfterCombat(unit);
            ApplyModification(unit);
        }
    }
    
    private void AddHealAfterCombat(Unit unit)
    {
        _modificationAfterCombat += unit.HealingAfterCombat;
    }

    private void AddDamageAfterCombat(Unit unit)
    {
        _modificationAfterCombat -= unit.DamageAfterCombat;
        if (unit.HasMadeFirstAttack)
        {
            _modificationAfterCombat -= unit.DamageAfterCombatIfHasAttacked;
        }
    }

    private void ApplyModification(Unit unit)
    {
        if (_modificationAfterCombat > 0)
        {
            int healing = _modificationAfterCombat;
            unit.Hp.Heal(healing);
            _view.PrintHealingAfterCombat(unit, healing);
        }
        else if (_modificationAfterCombat < 0)
        {
            int damage = -_modificationAfterCombat;
            unit.Hp.TakeDamageBetweenCombat(damage);
            _view.PrintDamageAfterCombat(unit, damage);
        }
    }
}