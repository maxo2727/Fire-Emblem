using Fire_Emblem.UnitsFolder;
using Fire_Emblem.PlayersFolder;

namespace Fire_Emblem.PlayersFolder;

public class Player
{
    private Unit _selectedUnit;
    public Team Team = new Team();

    public void SelectUnit(Unit selectedUnit)
    {
        _selectedUnit = selectedUnit;
    }

    public Unit GetSelectedUnit()
    {
        return _selectedUnit;
    }
}