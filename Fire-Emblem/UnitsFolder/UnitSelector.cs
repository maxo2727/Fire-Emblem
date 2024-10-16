using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.ResponseHandlerFolder;

namespace Fire_Emblem.UnitsFolder;

// static?
public class UnitSelector
{
    private GameInfo _gameInfo;
    private ResponseHandler.ResponseHandler _responseHandler;
    private FireEmblemView _view;

    public UnitSelector(GameInfo gameInfo, FireEmblemView view)
    {
        _gameInfo = gameInfo;
        _responseHandler = new ResponseHandlerUnit(view);
        _view = view;
    }
    
    public void SelectUnitsForAllPlayers()
    {
        int attackingPlayerNumber = _gameInfo.AttackingPlayerNumber;
        int defenderPlayerNumber = _gameInfo.DefendingPlayerNumber;
        SelectUnitForBattle(attackingPlayerNumber, _gameInfo.Players.GetPlayerById(attackingPlayerNumber));
        SelectUnitForBattle(defenderPlayerNumber, _gameInfo.Players.GetPlayerById(defenderPlayerNumber));
        _gameInfo.SaveBattleUnitChoice();
    }
    
    public void SelectUnitForBattle(int playerNumber, Player player)
    {
        List<Unit> aliveUnitsInCombat = player.Team.GetAliveUnitsInCombat();
        _view.WriteLine($"Player {playerNumber} selecciona una opción");
        _responseHandler.ShowArrayOfOptions(aliveUnitsInCombat); // esto dentro de USER CHOICE
        Unit selectedUnit = _responseHandler.AskUserForOption(aliveUnitsInCombat);
        player.SelectUnit(selectedUnit);
    }
}