using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public class WeaponNameRivalCondition : WeaponNameCondition
{
    public WeaponNameRivalCondition(string weaponName) : base(weaponName) {}
    
    public override bool IsMet(Unit unit)
    {
        return base.IsMet(unit.GetRivalUnit());
    }
}