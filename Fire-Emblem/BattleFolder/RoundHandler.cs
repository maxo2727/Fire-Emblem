using Fire_Emblem_View;
using Fire_Emblem.PlayersFolder;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class RoundHandler
{
    // Crear acá algún diccionario round context?
    private View _view;
    private Players _players;
    private int _attackingPlayerNumber;
    private int _defendingPlayerNumber;
    private int _battleRound;
    private Unit _attackingUnit;
    private Unit _defendingUnit;
    private UnitSelector _unitSelector;
    private CombatSequencer _combatSequencer;

    public RoundHandler(View view, Players players)
    {
        _view = view;
        _players = players;
        _battleRound = 1;
        _unitSelector = new UnitSelector(players, view);
        _combatSequencer = new CombatSequencer(view, _battleRound);
    }
    
    public void BeginNewRound()
    {
        SetUpUnits();
        AdvantageEvaluator.CheckAdvantage(_attackingUnit, _defendingUnit, _view);
        _combatSequencer.CombatSequence(_attackingUnit, _defendingUnit);
        _view.WriteLine($"{_attackingUnit.Name} ({_attackingUnit.GetCurrentHP()}) : {_defendingUnit.Name} ({_defendingUnit.GetCurrentHP()})");
    }

    public void SetUpUnits()
    {
        _unitSelector.SelectUnitsForAllPlayers(_attackingPlayerNumber, _defendingPlayerNumber);
        _attackingUnit = _players.PlayersDict[_attackingPlayerNumber].GetSelectedUnit();
        _defendingUnit = _players.PlayersDict[_defendingPlayerNumber].GetSelectedUnit();
        _view.WriteLine($"Round {_battleRound}: {_attackingUnit.Name} (Player {_attackingPlayerNumber}) comienza");
    }

    public void WrapUpForNextRound()
    {
        IncreaseRoundNumber();
        ChangeTurns();
        ResetUnitRoundActions();
        SetMostRecentRivalForThisCombat();
    }

    public void IncreaseRoundNumber()
    {
        _battleRound++;
        _combatSequencer.IncreaseRoundNumber();
    }
    public void ChangeTurns()
    {
        if (_attackingPlayerNumber == 1)
            SetPlayerTurns(2,1);
        else
            SetPlayerTurns(1,2);
    }
    
    public void SetPlayerTurns(int attackingPlayerNumber, int defendingPlayerNumber)
    {
        _attackingPlayerNumber = attackingPlayerNumber;
        _defendingPlayerNumber = defendingPlayerNumber;
    }

    public void ResetUnitRoundActions()
    {
        _attackingUnit.ResetRoundActions();
        _defendingUnit.ResetRoundActions();
    }

    public void SetMostRecentRivalForThisCombat()
    {
        _attackingUnit.SetMostRecentRival(_defendingUnit);
        _defendingUnit.SetMostRecentRival(_attackingUnit);
    }
}