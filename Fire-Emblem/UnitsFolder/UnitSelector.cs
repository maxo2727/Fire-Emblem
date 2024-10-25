using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.ResponseHandlerFolder;

namespace Fire_Emblem.UnitsFolder;

public class UnitSelector
{
    private Player _player;
    private List<Unit> _aliveUnitsInCombat;
    private GameInfo _gameInfo;
    private ResponseHandler _responseHandler;
    private FireEmblemView _view;

    public UnitSelector(GameInfo gameInfo, FireEmblemView view)
    {
        _gameInfo = gameInfo;
        _responseHandler = new ResponseHandler(view);
        _view = view;
    }
    
    public void SelectUnit(int playerNumber)
    {
        ShowAliveUnitsInCombat(playerNumber);
        SelectUnitForCombat();
    }

    private void ShowAliveUnitsInCombat(int playerNumber)
    {
        _player = _gameInfo.Players.GetPlayerById(playerNumber);
        _aliveUnitsInCombat = _player.Team.GetAliveUnitsInCombat();
        _view.ShowListOfUnits(playerNumber, _aliveUnitsInCombat);
    }

    private void SelectUnitForCombat()
    {
        Unit selectedUnit = _responseHandler.AskUserForUnit(_aliveUnitsInCombat);
        _player.SelectUnit(selectedUnit);
    }
}