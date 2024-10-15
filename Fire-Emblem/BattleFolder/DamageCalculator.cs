using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class DamageCalculator
{
    public static int CalculateDamage(Unit attacker, Unit defender)
    {
        double WTB = AdvantageEvaluator.GetAdvantageWTB(attacker, defender);
        int attack = attacker.Stats.GetStat("Atk").GetStatWithEffects(attacker);
        string defenseType = defender.Weapon.GetDefenseFromWeaponType(attacker.Weapon);
        int defense = defender.Stats.GetStat(defenseType).GetStatWithEffects(defender);
        int damage = (int)Math.Truncate(attack * WTB - defense);
        if (damage < 0)
            damage = 0;
        if (!attacker.HasMadeFirstAttack)
        {
            attacker.HasMadeFirstAttack = true;
        }
        return damage;
    }
}