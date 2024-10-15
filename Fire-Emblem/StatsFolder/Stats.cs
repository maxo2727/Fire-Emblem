namespace Fire_Emblem.StatsFolder;

public class Stats
{
    private readonly Dictionary<string, Stat> _stats = new Dictionary<string, Stat>()
    {
        { "Atk", new Attack() },
        { "Spd", new Speed() },
        { "Def", new Defense() },
        { "Res", new Resistence() }
    };

    public Stat GetStat(string stat)
    {
        return _stats[stat];
    }

    public IEnumerable<KeyValuePair<string, Stat>> GetAllStats()
    {
        return _stats;
    }

    public IEnumerable<string> GetStatNames()
    {
        return _stats.Keys;
    }

    public IEnumerable<Stat> GetStatValues()
    {
        return _stats.Values;
    }
    
    public void ClearEffectsForEveryStat()
    {
        foreach (Stat stat in _stats.Values)
        {
            stat.ClearStatEffects();
        }
    }
    
    // Necesario? O trainwreck noma?
    public void ModifyBonuses(string stat, int bonus)
    {
        _stats[stat].Bonus += bonus;
    }
    
    public void ModifyPenalties(string stat, int penalty)
    {
        _stats[stat].Penalty += penalty;
    }
    
    public void ModifyFirstAttackBonuses(string stat, int bonus)
    {
        _stats[stat].FirstAttackBonus += bonus;
    }
    
    public void ModifyFirstAttackPenalties(string stat, int penalty)
    {
        _stats[stat].FirstAttackPenalty += penalty;   
    }

    public void ModifyFollowUpBonuses(string stat, int bonus)
    {
        _stats[stat].FollowUpBonus += bonus;
    }
    
    public void ModifyFollowUpPenalties(string stat, int penalty)
    {
        _stats[stat].FollowUpPenalty += penalty;
    }
}