using Fire_Emblem_Models.Functions;
using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageExtra;

public class DamageExtraSumOfAllBonusesAndPenalties : Effect
{
    private double _percentage;
    
    public DamageExtraSumOfAllBonusesAndPenalties(double percentage)
    {
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        int bonuses = 0;
        int penalties = 0;
        Unit rival = unit.Rival;
        List<string> statNames = new List<string>() { "Atk", "Def", "Res", "Spd" }; //ENCAPSULAR EN STATCALCULATOR, models?
        foreach (string statName in statNames)
        {
            Stat stat = unit.Stats.GetStat(statName);
            if (!stat.AreBonusesNeutralized)
            {
                bonuses += stat.Bonus;
            }

            Stat rivalStat = rival.Stats.GetStat(statName);
            if (!rivalStat.ArePenaltiesNeutralized)
            {
                penalties -= rivalStat.Penalty;
            }
        }
        double percentageBonuses = bonuses * _percentage;
        int truncatedBonuses = TrueTruncator.Truncate(percentageBonuses);
        double percentagePenalties = penalties * _percentage;
        int truncatedPenalties = TrueTruncator.Truncate(percentagePenalties);
        int damageExtra = truncatedBonuses + truncatedPenalties;
        unit.DamageEffects.BaseDamageBonus += damageExtra;
    }
}