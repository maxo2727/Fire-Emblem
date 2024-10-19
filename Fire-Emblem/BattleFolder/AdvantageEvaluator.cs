using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

// LIMPIAR:
// atributos de unidades y WTB
// Unir funciones IsThereAnAdvantage con GetAdvantageWTB
// ta bien un || en la funcion if?


public class AdvantageEvaluator
{
    private GameInfo _gameInfo;
    private FireEmblemView _view;
    private Dictionary<string, string> _advantageousAgainst = AdvantageRelations.AdvantageousAgainst;

    public AdvantageEvaluator(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _gameInfo = gameInfo;
    }
    
    public void CheckAdvantage()
    {
        // atributos?
        Unit attacker = _gameInfo.AttackingUnit;
        Unit defender = _gameInfo.DefendingUnit;
        if (IsThereAnAdvantage(attacker, defender)) // GetAdvantage != 1
        {
            double WTB = GetAdvantageWTB(attacker, defender);
            Unit unitWithAdvantage = GetUnitWithAdvantage(attacker, defender, WTB);
            Unit unitWithDisadvantage = GetUnitWithDisadvantage(attacker, defender, WTB);
            _view.WriteLine($"{unitWithAdvantage.Name} ({unitWithAdvantage.Weapon.Name}) tiene ventaja con respecto a {unitWithDisadvantage.Name} ({unitWithDisadvantage.Weapon.Name})");
        }
        else
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
    }

    public bool IsThereAnAdvantage(Unit attacker, Unit defender)
    {
        string attackerWeapon = attacker.Weapon.Name;
        string defenderWeapon = defender.Weapon.Name;
        return defenderWeapon == _advantageousAgainst[attackerWeapon] ||
               attackerWeapon == _advantageousAgainst[defenderWeapon];
    }
    
    public double GetAdvantageWTB(Unit attacker, Unit defender)
    {
        string attackerWeapon = attacker.Weapon.Name;
        string defenderWeapon = defender.Weapon.Name;
        if (defenderWeapon == _advantageousAgainst[attackerWeapon])
            return 1.2;
        else if (attackerWeapon == _advantageousAgainst[defenderWeapon])
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