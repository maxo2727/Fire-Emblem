namespace Fire_Emblem_Models.EffectsFolder;

public class DamageReductionPercentageStatDifference : Effect
{
    private string _stat;

    public DamageReductionPercentageStatDifference(string stat)
    {
        _stat = stat;
    }

    public override void Apply(Unit unit)
    {
        Unit rival = unit.Rival;
        int unitStatValue = unit.Stats.GetStat(_stat).GetStatWithBaseEffects();
        int rivalStatValue = rival.Stats.GetStat(_stat).GetStatWithBaseEffects();
        int statDifference = Math.Abs(unitStatValue - rivalStatValue);
        int statDifferencePonderated = statDifference * 4;
        if (statDifferencePonderated > 40)
        {
            statDifferencePonderated = 40;
        }

        double statDifferencePonderatedPercentage = statDifferencePonderated / 100.0;
        unit.DamageEffects.IncreaseBasePercentageDamageReduction(statDifferencePonderatedPercentage);
    }
}