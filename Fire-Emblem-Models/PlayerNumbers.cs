namespace Fire_Emblem_Models;

public static class PlayerNumbers
{
    private static readonly List<int> _playerNumbers = new List<int>()
    {
        1, 2
    };

    public static List<int> GetAllPlayerNumbers()
    {
        return _playerNumbers;
    }
}