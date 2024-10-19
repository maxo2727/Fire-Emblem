namespace Fire_Emblem_Models.ConditionsFolder;

public class AdvantageCondition : ICondition
{
    private Dictionary<string, string> _advantageousAgainst = AdvantageRelations.AdvantageousAgainst;
    
    public bool IsMet(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        string attackerWeapon = unit.Weapon.Name;
        string defenderWeapon = rival.Weapon.Name;
        return defenderWeapon == _advantageousAgainst[attackerWeapon];
    }
}