namespace Fire_Emblem_Models.StatsFolder;

public class Resistence : Stat
{
    public override int GetStatWithEffects(Unit unit)
    {
        return CalculateStatWithEffectsWhenCheckingAttacksOf(unit.GetRivalUnit());
    }
}