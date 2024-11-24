using Fire_Emblem_Models;
using Fire_Emblem_Models.Functions;
using Fire_Emblem_View;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class DamageHandler
{
    private FireEmblemView _view;
    private int _damage;

    public DamageHandler(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
    }

    private void SetDamage(int value)
    {
        _damage = value < 0 ? 0 : value;
    }

    public int CalculateDamage(Unit attacker, Unit defender)
    {
        CalculateBaseDamage(attacker, defender);
        CalculateModifiedDamage(attacker, defender);
        _view.PrintCombatEvent(attacker.Name, defender.Name, _damage);
        return _damage;
    }

    private void CalculateBaseDamage(Unit attacker, Unit defender)
    {
        double WTB = AdvantageEvaluator.GetAdvantageWTB(attacker, defender);
        int attack = attacker.Stats.GetStat("Atk").GetStatWithEffects(attacker);
        string defenseType = WeaponDefenseGetter.GetDefenseFromWeaponType(attacker.Weapon);
        int defense = defender.Stats.GetStat(defenseType).GetStatWithEffects(defender);
        int baseDamage = (int)Math.Truncate(attack * WTB - defense);
        SetDamage(baseDamage);
    }

    private void CalculateModifiedDamage(Unit attacker, Unit defender)
    {
        if (!attacker.HasMadeFirstAttack)
        {
            SetDamage(attacker.DamageEffects.CalculateModifiedFirstAttackDamage(_damage));
            attacker.HasMadeFirstAttack = true;
        }
        else if (attacker.InFollowUp)
        {
            SetDamage(attacker.DamageEffects.CalculateModifiedFollowUpDamage(_damage));
        }
        else
        {
            SetDamage(attacker.DamageEffects.CalculateModifiedBaseDamage(_damage));
        }
    }
}