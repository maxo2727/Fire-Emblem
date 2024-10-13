using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.StatsFolder;

public class Defense : Stat
{
    public override int GetStatWithEffects(Unit unit)
    {
        return CalculateStatWithEffectsWhenCheckingAttacksOf(unit.GetRivalUnit());
    }
}