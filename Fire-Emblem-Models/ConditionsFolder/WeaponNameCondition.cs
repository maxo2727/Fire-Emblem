namespace Fire_Emblem_Models.ConditionsFolder;

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