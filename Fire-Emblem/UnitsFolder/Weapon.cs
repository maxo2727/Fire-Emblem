namespace Fire_Emblem.UnitsFolder;

public class Weapon
{
    public string Name;
    public string Type;

    public Weapon(string name)
    {
        Name = name;
        Type = WeaponTypeSetter.SetWeaponType(name);
    }
    
    public string GetDefenseFromWeaponType(Weapon attackingUnitWeapon)
    {
        return WeaponDefenseGetter.GetDefenseFromWeaponType(attackingUnitWeapon);
    }
}