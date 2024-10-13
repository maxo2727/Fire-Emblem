using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public class WeaponTypeRivalCondition : WeaponTypeCondition
{
    public WeaponTypeRivalCondition(string weaponType) : base(weaponType) {}

    public override bool IsMet(Unit unit)
    {
        return base.IsMet(unit.GetRivalUnit());
    }
}