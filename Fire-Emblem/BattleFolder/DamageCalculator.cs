using Fire_Emblem_Models;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class DamageCalculator
{
    public static int CalculateDamage(Unit attacker, Unit defender)
    {
        double WTB = AdvantageEvaluator.GetAdvantageWTB(attacker, defender);
        int attack = attacker.Stats.GetStat("Atk").GetStatWithEffects(attacker);
        string defenseType = WeaponDefenseGetter.GetDefenseFromWeaponType(attacker.Weapon);
        int defense = defender.Stats.GetStat(defenseType).GetStatWithEffects(defender);
        int damage = (int)Math.Truncate(attack * WTB - defense);

        int modifiedDamage;
        if (!attacker.HasMadeFirstAttack)
        {
            modifiedDamage = attacker.DamageEffects.CalculateModifiedFirstAttackDamage(damage);
        }
        else if (attacker.InFollowUp)
        {
            modifiedDamage = attacker.DamageEffects.CalculateModifiedFollowUpDamage(damage);
        }
        else
        {
            modifiedDamage = attacker.DamageEffects.CalculateModifiedBaseDamage(damage);
        }
        
        if (modifiedDamage < 0)
            modifiedDamage = 0;
        // donde manejar eso?? Quizas afuera en un controller DamageController o AttackController
        if (!attacker.HasMadeFirstAttack)
        {
            attacker.HasMadeFirstAttack = true;
        }
        return modifiedDamage;
    }
}