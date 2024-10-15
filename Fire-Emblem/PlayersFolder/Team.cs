using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.PlayersFolder;

public class Team
{
    private readonly List<Unit> _team = new List<Unit>();

    public List<Unit> GetAllUnits()
    {
        return _team;
    }
    
    public void AddUnit(Unit unit)
    {
        _team.Add(unit);
    }
    
    public List<Unit> GetAliveUnitsInCombat()
    {
        List<Unit> AliveUnitsInCombat = new List<Unit>();
        foreach (Unit unit in _team)
            if (unit.IsAlive())
                AliveUnitsInCombat.Add(unit);
        return AliveUnitsInCombat;
    }

    public bool HasLostAllItsUnits()
    {
        foreach (Unit unit in _team)
            if (unit.IsAlive())
                return false;
        return true;
    }
    
    public bool IsTeamOutsideSizeRange()
    {
        int teamLength = _team.Count;
        return teamLength < 1 || 3 < teamLength;
    }

    public bool AreThereAnyRepeatedUnits()
    {
        HashSet<string> uniqueUnitNames = new HashSet<string>();
        foreach (Unit unit in _team)
        {
            if (!uniqueUnitNames.Add(unit.Name))
                return true;
        }
        return false;
    }
}