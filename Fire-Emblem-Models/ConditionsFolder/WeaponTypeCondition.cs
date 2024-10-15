namespace Fire_Emblem_Models.ConditionsFolder;

public class WeaponTypeCondition : ICondition
{
    private string _weaponType;

    public WeaponTypeCondition(string weaponType)
    {
        _weaponType = weaponType;
    }
    
    public virtual bool IsMet(Unit unit)
    {
        return unit.Weapon.Type == _weaponType;
    }
}