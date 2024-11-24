namespace Fire_Emblem_Models.StatsFolder;

public class Defense : Stat
{
    public override int GetStatWithEffects(Unit unit)
    {
        return CalculateStatWithEffectsWhenCheckingAttacksOf(unit.Rival);
    }
}