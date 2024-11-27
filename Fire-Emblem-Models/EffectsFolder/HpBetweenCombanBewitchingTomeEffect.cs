using Fire_Emblem_Models.Functions;
using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models.EffectsFolder;

public class HpBetweenCombanBewitchingTomeEffect : Effect
{
    public override void Apply(Unit unit)
    {
        double percentageDamage = 0.2;
        Unit rival = unit.Rival;
        Stat rivalAtk = rival.Stats.GetStat("Atk");
        int rivalAtkValue = rivalAtk.GetStatWithEffects();
        if (BewitchingTomeDamageConditionsAreMet(unit, rival))
        {
            percentageDamage = 0.4;
        }
        double damage = rivalAtkValue * percentageDamage;
        int truncatedDamage = TrueTruncator.Truncate(damage);
        Console.WriteLine($"{rival.Name}: {rivalAtkValue} * {percentageDamage} = {truncatedDamage}");
        rival.DamageBeforeCombat += truncatedDamage;
    }

    private bool BewitchingTomeDamageConditionsAreMet(Unit unit, Unit rival)
    {
        return IsUnitAdvantageous(unit, rival) || HasUnitMoreSpeed(unit, rival);
    }

    private bool IsUnitAdvantageous(Unit unit, Unit rival)
    {
        return AdvantageEvaluator.GetAdvantageWTB(unit, rival) == 1.2;
    }

    private bool HasUnitMoreSpeed(Unit unit, Unit rival)
    {
        int unitSpd = GetSpdValueWithBonuses(unit);
        int rivalSpd = GetSpdValueWithBonuses(rival);
        return unitSpd > rivalSpd;
    }

    private int GetSpdValueWithBonuses(Unit unit)
    {
        Stat spdStat = unit.Stats.GetStat("Spd");
        int spdValue = spdStat.BaseStat + spdStat.Bonus + spdStat.FirstAttackBonus + spdStat.FollowUpBonus;
        return spdValue;
    }
}