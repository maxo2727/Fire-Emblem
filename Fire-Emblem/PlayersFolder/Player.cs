using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.PlayersFolder;

public class Player
{
    private Unit _selectedUnit;
    public List<Unit> Team = new List<Unit>();

    public void AddUnitToTeam(Unit unit)
    {
        Team.Add(unit);
    }

    public void SelectUnit(Unit selectedUnit)
    {
        _selectedUnit = selectedUnit;
    }

    public Unit GetSelectedUnit()
    {
        return _selectedUnit;
    }

    public List<Unit> GetAliveUnitsInCombat()
    {
        List<Unit> AliveUnitsInCombat = new List<Unit>();
        foreach (Unit unit in Team)
            if (unit.IsAlive())
                AliveUnitsInCombat.Add(unit);
        return AliveUnitsInCombat;
    }

    public bool HasLostAllItsUnits()
    {
        foreach (Unit unit in Team)
            if (unit.IsAlive())
                return false;
        return true;
    }
}