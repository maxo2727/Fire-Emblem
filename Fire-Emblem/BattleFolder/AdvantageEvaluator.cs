using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class AdvantageEvaluator
{
    private static Dictionary<string, string> AdvantageousAgainst = new Dictionary<string, string>
    {
        { "Sword", "Axe" },
        { "Axe", "Lance" },
        { "Lance", "Sword" },
        { "Magic", "" },
        { "Bow", "" }
    };
    
    public static void CheckAdvantage(Unit attacker, Unit defender, FireEmblemView view)
    {
        if (AdvantageEvaluator.IsThereAnAdvantage(attacker, defender))
        {
            double WTB = AdvantageEvaluator.GetAdvantageWTB(attacker, defender);
            Unit unitWithAdvantage = AdvantageEvaluator.GetUnitWithAdvantage(attacker, defender, WTB);
            Unit unitWithDisadvantage = AdvantageEvaluator.GetUnitWithDisadvantage(attacker, defender, WTB);
            view.WriteLine($"{unitWithAdvantage.Name} ({unitWithAdvantage.Weapon.Name}) tiene ventaja con respecto a {unitWithDisadvantage.Name} ({unitWithDisadvantage.Weapon.Name})");
        }
        else
            view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
    }

    public static bool IsThereAnAdvantage(Unit attacker, Unit defender)
    {
        string attackerWeapon = attacker.Weapon.Name;
        string defenderWeapon = defender.Weapon.Name;
        if (defenderWeapon == AdvantageousAgainst[attackerWeapon] ||
            attackerWeapon == AdvantageousAgainst[defenderWeapon])
            return true;
        else
            return false;
    }
    
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

    public static Unit GetUnitWithAdvantage(Unit attacker, Unit defender, double WBT)
    {
        if (WBT == 1.2)
            return attacker;
        else
            return defender;
    }
    
    public static Unit GetUnitWithDisadvantage(Unit attacker, Unit defender, double WBT)
    {
        if (WBT == 1.2)
            return defender;
        else
            return attacker;
    }
}

// utilizar el numero obtenido altiro, y ver si no es 1
// equilibrar con codigo entendible, y cambios innecesarios