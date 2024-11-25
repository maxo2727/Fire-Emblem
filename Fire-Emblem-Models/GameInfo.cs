namespace Fire_Emblem_Models;

public class GameInfo
{
    public Players Players;
    public int RoundTurn;
    public int AttackingPlayerNumber;
    public int DefendingPlayerNumber;
    public Unit AttackingUnit;
    public Unit DefendingUnit;

    public GameInfo(Players players)
    {
        Players = players;
    }

    public void IncreaseRoundNumber()
    {
        RoundTurn++;
    }
    
    public void SetPlayerTurns(int attackingPlayerNumber, int defendingPlayerNumber)
    {
        AttackingPlayerNumber = attackingPlayerNumber;
        DefendingPlayerNumber = defendingPlayerNumber;
    }

    public void SaveBattleUnitChoice()
    {
        AttackingUnit = Players.GetPlayerById(AttackingPlayerNumber).GetSelectedUnit();
        DefendingUnit = Players.GetPlayerById(DefendingPlayerNumber).GetSelectedUnit();
    }

    public void SetMostRecentRivalForThisCombat()
    {
        AttackingUnit.MostRecentRival = DefendingUnit;
        DefendingUnit.MostRecentRival = AttackingUnit;
    }
}