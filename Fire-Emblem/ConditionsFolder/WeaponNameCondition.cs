using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public class WeaponNameCondition : ICondition
{
    private string _weaponName;

    public WeaponNameCondition(string weaponName)
    {
        _weaponName = weaponName;
    }
    
    public virtual bool IsMet(Unit unit)
    {
        return unit.Weapon.Name == _weaponName;
    }
}