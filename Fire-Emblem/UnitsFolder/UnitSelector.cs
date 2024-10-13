using Fire_Emblem_View;
using Fire_Emblem.PlayersFolder;
using Fire_Emblem.ResponseHandlerFolder;

namespace Fire_Emblem.UnitsFolder;

// static?
public class UnitSelector
{
    private Players _players;
    private ResponseHandler.ResponseHandler _responseHandler;
    private View _view;

    public UnitSelector(Players players, View view)
    {
        _players = players;
        _responseHandler = new ResponseHandlerUnit(view);
        _view = view;
    }
    
    public void SelectUnitsForAllPlayers(int attackerPlayerNumber, int defenderPlayerNumber)
    {
        SelectUnitForBattle(attackerPlayerNumber, _players.PlayersDict[attackerPlayerNumber]);
        SelectUnitForBattle(defenderPlayerNumber, _players.PlayersDict[defenderPlayerNumber]);
    }
    
    public void SelectUnitForBattle(int playerNumber, Player player)
    {
        List<Unit> aliveUnitsInCombat = player.GetAliveUnitsInCombat();
        _view.WriteLine($"Player {playerNumber} selecciona una opción");
        _responseHandler.ShowArrayOfOptions(aliveUnitsInCombat); // esto dentro de USER CHOICE
        Unit selectedUnit = _responseHandler.AskUserForOption(aliveUnitsInCombat);
        player.SelectUnit(selectedUnit);
    }
}