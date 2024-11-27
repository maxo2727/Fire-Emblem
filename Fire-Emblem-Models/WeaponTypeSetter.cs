namespace Fire_Emblem_Models;

public static class WeaponTypeSetter
{
    private static readonly Dictionary<string, string> WeaponTypes = new Dictionary<string, string>
    {
        { "Sword", "Physical" },
        { "Axe", "Physical" },
        { "Lance", "Physical" },
        { "Bow", "Physical" },
        { "Magic", "Magical" }
    };

    public static string SetWeaponType(string weapon)
    {
        return WeaponTypes[weapon];
    }
    
}