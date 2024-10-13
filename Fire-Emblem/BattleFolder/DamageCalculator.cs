using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class DamageCalculator
{
    public static int CalculateDamage(Unit attacker, Unit defender)
    {
        double WTB = AdvantageEvaluator.GetAdvantageWTB(attacker, defender);
        int attack = attacker.Stats["Atk"].GetStatWithEffects(attacker);
        Console.WriteLine($"{attacker.Name} attack: {attacker.Stats["Atk"].BaseStat}");
        Console.WriteLine($"{attacker.Name} attack: {attack}");
        Console.WriteLine($"{attacker.Name} attack bonus neutralized: {attacker.Stats["Atk"].AreBonusesNeutralized}");
        string defenseType = defender.GetDefenseFromWeaponType(attacker.Weapon);
        int defense = defender.Stats[defenseType].GetStatWithEffects(defender);
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