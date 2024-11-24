namespace Fire_Emblem_Models;

public class Companions
{
    private List<Unit> _companions = new List<Unit>();

    public void Add(Unit unit)
    {
        _companions.Add(unit);
    }
    
    public bool IsThereAnyUnitInTeamWithWeaponName(string weaponName)
    {
        foreach (Unit unit in _companions)
        {
            if (unit.IsAlive())
            {
                if (unit.IsWeaponNameEqualTo(weaponName))
                {
                    return true;
                }
            }
            
        }
        return false;
    }
}