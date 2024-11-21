namespace Fire_Emblem_Models;

public static class DamageCalculator
{
    private static int _damage;
    private static void SetDamage(int value)
    {
        _damage = value < 0 ? 0 : value;
    }

    public static int GetBaseDamage(Unit attacker, Unit defender)
    {
        CalculateBaseDamage(attacker, defender);
        return _damage;
    }

    public static int CalculateDamageNew(Unit attacker, Unit defender)
    {
        CalculateBaseDamage(attacker, defender);
        CalculateModifiedDamage(attacker, defender);
        return _damage;
    }

    private static void CalculateBaseDamage(Unit attacker, Unit defender)
    {
        double WTB = AdvantageEvaluator.GetAdvantageWTB(attacker, defender);
        int attack = attacker.Stats.GetStat("Atk").GetStatWithEffects(attacker);
        string defenseType = WeaponDefenseGetter.GetDefenseFromWeaponType(attacker.Weapon);
        int defense = defender.Stats.GetStat(defenseType).GetStatWithEffects(defender);
        int baseDamage = (int)Math.Truncate(attack * WTB - defense);
        SetDamage(baseDamage);
    }

    private static void CalculateModifiedDamage(Unit attacker, Unit defender)
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