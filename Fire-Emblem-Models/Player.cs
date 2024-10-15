namespace Fire_Emblem_Models;

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