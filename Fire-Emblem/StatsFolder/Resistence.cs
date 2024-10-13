using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.StatsFolder;

public class Resistence : Stat
{
    public override int GetStatWithEffects(Unit unit)
    {
        return CalculateStatWithEffectsWhenCheckingAttacksOf(unit.GetRivalUnit());
    }
}