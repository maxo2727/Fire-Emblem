namespace Fire_Emblem.PlayersFolder;

public class Players
{
    public Dictionary<int, Player> PlayersDict;

    public Players()
    {
        Player player1 = new Player();
        Player player2 = new Player();
        PlayersDict = new Dictionary<int, Player>();
        PlayersDict.Add(1, player1);
        PlayersDict.Add(2, player2);
    }
}

// almacenar flujo de turnos aca por ej