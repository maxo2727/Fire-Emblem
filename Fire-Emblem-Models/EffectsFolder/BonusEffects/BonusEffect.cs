using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models.EffectsFolder.BonusEffects;

public class BonusEffect: Effect
{
    private string _stat;
    private int _bonus;

    public BonusEffect(string stat, int bonus)
    {
        _stat = stat;
        _bonus = bonus;
    }
    
    public override void Apply(Unit unit)
    {
        Stat stat = unit.Stats.GetStat(_stat);
        stat.Bonus += _bonus;
    }
}