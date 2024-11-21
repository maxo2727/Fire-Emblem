namespace Fire_Emblem_Models;

public static class AdvantageEvaluator
{
    public static readonly Dictionary<string, string> AdvantageousAgainst = new Dictionary<string, string>
    {
        { "Sword", "Axe" },
        { "Axe", "Lance" },
        { "Lance", "Sword" },
        { "Magic", "" },
        { "Bow", "" }
    };
    
    public static double GetAdvantageWTB(Unit attacker, Unit defender)
    {
        string attackerWeapon = attacker.Weapon.Name;
        string defenderWeapon = defender.Weapon.Name;
        if (defenderWeapon == AdvantageousAgainst[attackerWeapon])
            return 1.2;
        else if (attackerWeapon == AdvantageousAgainst[defenderWeapon])
            return 0.8;
        else
            return 1.0;
    }
}