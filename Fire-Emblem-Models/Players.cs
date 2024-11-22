namespace Fire_Emblem_Models;

public class Players
{
    private readonly Dictionary<int, Player> _playersDict = new Dictionary<int, Player>()
    {
        {1, new Player()},
        {2, new Player()},
    };

    public Player GetPlayerById(int id)
    {
        return _playersDict[id];
    }

    public List<Player> GetAllPlayers()
    {
        return _playersDict.Values.ToList();
    }
}