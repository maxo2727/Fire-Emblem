namespace Fire_Emblem.StatsFolder;

public class Stats
{
    public Dictionary<string, Stat> _stats = new Dictionary<string, Stat>()
    {
        { "Atk", new Attack() },
        { "Spd", new Speed() },
        { "Def", new Defense() },
        { "Res", new Resistence() }
    };
    
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
    
    // public void ModifyRivalBonuses(string stat, int bonus)
    // {
    //     _rival.ModifyBonuses(stat, bonus);
    // }
    //
    // public void ModifyRivalPenalties(string stat, int penalty)
    // {
    //     _rival.ModifyPenalties(stat, penalty);
    // }
    //
    // public void ModifyRivalFirstAttackBonuses(string stat, int penalty)
    // {
    //     _rival.ModifyFirstAttackBonuses(stat, penalty);
    // }
    // public void ModifyRivalFirstAttackPenalties(string stat, int penalty)
    // {
    //     _rival.ModifyFirstAttackPenalties(stat, penalty);
    // }
}