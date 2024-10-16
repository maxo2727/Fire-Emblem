using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class RoundHandler
{
    // Crear acá algún diccionario round context?
    private FireEmblemView _view;
    private GameInfo _gameInfo;
    private UnitSelector _unitSelector;
    private CombatSequencer _combatSequencer;

    public RoundHandler(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _gameInfo = gameInfo;
        _unitSelector = new UnitSelector(_gameInfo, view);
        _combatSequencer = new CombatSequencer(view, _gameInfo);
    }
    
    public void BeginNewRound()
    {
        SetUpUnits();
        AdvantageEvaluator.CheckAdvantage(_gameInfo, _view);
        _combatSequencer.CombatSequence();
        _view.WriteLine($"{_gameInfo.AttackingUnit.Name} ({_gameInfo.AttackingUnit.GetCurrentHP()}) : {_gameInfo.DefendingUnit.Name} ({_gameInfo.DefendingUnit.GetCurrentHP()})");
    }
    
    //LIMPIAR!!
    public void SetUpUnits()
    {
        _unitSelector.SelectUnitsForAllPlayers();
        _view.WriteLine($"Round {_gameInfo.RoundTurn}: {_gameInfo.AttackingUnit.Name} (Player {_gameInfo.AttackingPlayerNumber}) comienza");
    }

    public void WrapUpForNextRound()
    {
        ChangeTurns();
        _gameInfo.IncreaseRoundNumber();
        _gameInfo.ResetUnitRoundActions();
        _gameInfo.SetMostRecentRivalForThisCombat();
    }
    
    // metodos de GameInfo??
    public void ChangeTurns()
    {
        if (_gameInfo.AttackingPlayerNumber == 1)
            _gameInfo.SetPlayerTurns(2,1);
        else
            _gameInfo.SetPlayerTurns(1,2);
    }
}