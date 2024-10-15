namespace Fire_Emblem_Models.ConditionsFolder;

public class WeaponTypeRivalCondition : WeaponTypeCondition
{
    public WeaponTypeRivalCondition(string weaponType) : base(weaponType) {}

    public override bool IsMet(Unit unit)
    {
        return base.IsMet(unit.GetRivalUnit());
    }
}