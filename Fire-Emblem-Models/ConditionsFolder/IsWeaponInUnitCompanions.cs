namespace Fire_Emblem_Models.ConditionsFolder;

public class IsWeaponInUnitCompanions : ICondition
{
    private string _weaponName;
    
    public IsWeaponInUnitCompanions(string weaponName)
    {
        _weaponName = weaponName;
    }

    public bool IsMet(Unit unit)
    {
        return unit.Companions.IsThereAnyUnitInTeamWithWeaponName(_weaponName);
    }
}