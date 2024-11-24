using Fire_Emblem_Models.Functions;

namespace Fire_Emblem_Models.ConditionsFolder;

public class AdvantageCondition : ICondition
{
    private Dictionary<string, string> _advantageousAgainst = AdvantageEvaluator.AdvantageousAgainst;
    
    public bool IsMet(Unit unit)
    {
        Unit rival = unit.Rival;
        string attackerWeapon = unit.Weapon.Name;
        string defenderWeapon = rival.Weapon.Name;
        return defenderWeapon == _advantageousAgainst[attackerWeapon];
    }
}