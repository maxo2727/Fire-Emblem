using Fire_Emblem_Models;
using Fire_Emblem_View;

namespace Fire_Emblem.BattleFolder;

public class BattleHandler
{
    private FireEmblemView _view;
    private GameInfo _gameInfo;
    private RoundHandler _roundHandler;

    public BattleHandler(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _gameInfo = gameInfo;
    }
    
    public void StartBattle()
    {
        InitializeBattle();
        HandleNextBattleRound();
    }
    
    public void InitializeBattle()
    {
        _roundHandler = new RoundHandler(_view, _gameInfo);
        _gameInfo.SetPlayerTurns(1,2);
        _gameInfo.RoundTurn = 1;
        // _gameInfo.AttackingPlayerNumber = 1;
        // _gameInfo.DefendingPlayerNumber = 2;
    }
    
    public void HandleNextBattleRound()
    {
        _roundHandler.BeginNewRound();
        if (CheckFinishCondition())
            FinishBattle();
        else
        {
            _roundHandler.WrapUpForNextRound();
            HandleNextBattleRound();
        }
    }
    
    // Player?
    public bool CheckFinishCondition()
    {
        foreach (Player player in _gameInfo.Players.GetAllPlayers())
            if (player.Team.HasLostAllItsUnits())
                return true;
        return false;
    }

    public void FinishBattle()
    {
        int winner = GetBattleWinner();
        _view.WriteLine($"Player {winner} ganó");
    }
    
    // GameInfo?
    public int GetBattleWinner()
    {
        int winner = 0;
        foreach (int playerID in PlayerNumbers.GetAllPlayerNumbers())
        {
            Player player = _gameInfo.Players.GetPlayerById(playerID);
            if (!player.Team.HasLostAllItsUnits())
            {
                winner = playerID;
            }
        }
        return winner;
    }
}