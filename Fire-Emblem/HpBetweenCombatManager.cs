using Fire_Emblem_Models;
using Fire_Emblem_Models.Functions;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class HpBetweenCombatManager
{
    private FireEmblemView _view;
    private GameInfo _gameInfo;

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

    public void ApplyHpModificationsAfterCombat(Unit unit)
    {
        if (unit.IsAlive())
        {
            ApplyHealAfterCombat(unit);
            ApplyDamageAfterCombat(unit);
        }
    }
    
    private void ApplyHealAfterCombat(Unit unit)
    {
        unit.ApplyHealAfterCombat();
        if (unit.HealingAfterCombat > 0)
            _view.PrintHealingAfterCombat(unit);
    }

    private void ApplyDamageAfterCombat(Unit unit)
    {
        int damage = unit.DamageAfterCombat;
        if (unit.HasMadeFirstAttack)
        {
            damage += unit.DamageAfterCombatIfHasAttacked;
        }
        unit.Hp.TakeDamageBetweenCombat(damage);
        if (damage > 0)
            _view.PrintDamageAfterCombat(unit, damage);
    }
}