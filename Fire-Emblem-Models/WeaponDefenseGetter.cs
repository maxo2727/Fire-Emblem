namespace Fire_Emblem_Models;

public class WeaponDefenseGetter
{
    private static readonly Dictionary<string, string> WeaponDefenses = new Dictionary<string, string>
    {
        { "Physical", "Def" },
        { "Magical", "Res" }
    };

    public static string GetDefenseFromWeaponType(Weapon weapon)
    {
        return WeaponDefenses[weapon.Type];
    }
}