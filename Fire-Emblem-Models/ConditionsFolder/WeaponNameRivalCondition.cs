namespace Fire_Emblem_Models.ConditionsFolder;

public class WeaponNameRivalCondition : WeaponNameCondition
{
    public WeaponNameRivalCondition(string weaponName) : base(weaponName) {}
    
    public override bool IsMet(Unit unit)
    {
        return base.IsMet(unit.GetRivalUnit());
    }
}