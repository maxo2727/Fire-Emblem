using Fire_Emblem_Models;
using Fire_Emblem_Models.Exceptions;
using Fire_Emblem_View;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

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
        Unit attacker = _gameInfo.AttackingUnit;
        Unit defender = _gameInfo.DefendingUnit;
        if (IsThereAnAdvantage(attacker, defender))
        {
            double WTB = GetAdvantageWTB(attacker, defender);
            Unit unitWithAdvantage = GetUnitWithAdvantage(attacker, defender, WTB);
            Unit unitWithDisadvantage = GetUnitWithDisadvantage(attacker, defender, WTB);
            _view.PrintAdvantage(unitWithAdvantage, unitWithDisadvantage);
        }
        else
            _view.PrintNoAdvantage();
    }

    private bool IsThereAnAdvantage(Unit attacker, Unit defender)
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

    private static Unit GetUnitWithAdvantage(Unit attacker, Unit defender, double WBT)
    {
        if (WBT == 1.2)
            return attacker;
        else
            return defender;
    }
    
    private static Unit GetUnitWithDisadvantage(Unit attacker, Unit defender, double WBT)
    {
        if (WBT == 1.2)
            return defender;
        else
            return attacker;
    }
}