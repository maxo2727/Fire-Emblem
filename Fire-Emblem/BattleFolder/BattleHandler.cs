using Fire_Emblem_View;
using Fire_Emblem.PlayersFolder;

namespace Fire_Emblem.BattleFolder;

public class BattleHandler
{
    private View _view;
    private Players _players;
    private RoundHandler _roundHandler;

    public BattleHandler(View view, Players players)
    {
        _view = view;
        _players = players;
    }
    
    public void StartBattle()
    {
        InitializeBattle();
        HandleNextBattleRound();
    }
    
    public void InitializeBattle()
    {
        _roundHandler = new RoundHandler(_view, _players);
        _roundHandler.SetPlayerTurns(1,2);
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

    public bool CheckFinishCondition()
    {
        foreach (Player player in _players.PlayersDict.Values)
            if (player.Team.HasLostAllItsUnits())
                return true;
        return false;
    }

    public void FinishBattle()
    {
        int winner = GetBattleWinner();
        _view.WriteLine($"Player {winner} ganó");
    }
    
    public int GetBattleWinner()
    {
        int winner = 0;
        foreach (var (playerNumber, player) in _players.PlayersDict)
        {
            if (!player.Team.HasLostAllItsUnits())
            {
                winner = playerNumber;
            }
        }
        return winner;
    }
}